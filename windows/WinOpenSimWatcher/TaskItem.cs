/* Project-Start 2011-11
 * (c)Pixel Tomsen (chk) pixel.tomsen[at]gridnet.info
 * https://github.com/PixelTomsen/OpenSimWatch
 * 
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *     * Redistributions of source code must retain the above copyright
 *       notice, this list of conditions and the following disclaimer.
 *     * Redistributions in binary form must reproduce the above copyright
 *       notice, this list of conditions and the following disclaimer in the
 *       documentation and/or other materials provided with the distribution.
 *     * Neither the name of the OpenSimulator Project nor the
 *       names of its contributors may be used to endorse or promote products
 *       derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE DEVELOPERS ``AS IS'' AND ANY
 * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE CONTRIBUTORS BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Net;
using log4net;


namespace OpenSimWatcher
{
    public partial class TaskItem
    {
        private static readonly ILog m_log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private TaskParameter m_taskParameter;
        public TaskParameter ParameterTask
        {
            get { return m_taskParameter; }
            set { m_taskParameter = value; }
        }

        public TaskProcessState GetTaskProcessState { get { return m_taskProcessState; } }
        public int RestartCounter { get { return m_restartCount; } }

        public ProcessStartInfo StartInfo { get { return m_startInfo; } }
        public Process RunningProcess { get { return m_process; } }

        private int m_restartCount = 0;
        private ProcessStartInfo m_startInfo;
        private Process m_process = null;
        private Thread m_thread = null;

        private TaskState m_taskState = TaskState.Stop;
        public TaskState GetTaskState { get { return m_taskState; } }

        private TaskProcessState m_taskProcessState = TaskProcessState.Stop;

        private int m_threadWait = 5; // 5 seconds delay for first start

        private IActionHTTPCheckMethode m_httpCheckAction;
        private int m_httpWait = 120;// 2 minutes intitial wait
        private int m_httpFail = 3; 


        public TaskItem()
        {
            m_startInfo = new ProcessStartInfo();
        }

        internal bool FillStartup()
        {
            if (File.Exists(m_taskParameter.StartupParameter.FullPath))
            {
                m_startInfo.WorkingDirectory = m_taskParameter.StartupParameter.StartupPath;
                m_startInfo.FileName = m_taskParameter.StartupParameter.FullPath;
                m_startInfo.Arguments = m_taskParameter.StartupParameter.Args;
                m_startInfo.WindowStyle = ProcessWindowStyle.Minimized;
                m_startInfo.UseShellExecute = true;
                m_startInfo.RedirectStandardOutput = false;
                m_startInfo.RedirectStandardError = false;
                m_taskState = TaskState.Stop;
                return true;
            }

            m_taskState = TaskState.Invalidate;
            ApplicationBase.Instance.EventHandler.TriggerOnTaskStop(this, "File not found");

            m_log.FatalFormat(":[{0}] Application not found - '{1}'", m_taskParameter.Description, m_taskParameter.StartupParameter.FullPath);

            return false;
        }

        internal void Worker()
        {
            m_log.DebugFormat(":[{0}] Task running for {1}", m_taskParameter.Description, m_taskParameter.StartupParameter.FullPath);
            m_taskState = TaskState.Run;
            ApplicationBase.Instance.EventHandler.TriggerOnTaskStart(this, "Start");

            m_httpWait = m_taskParameter.CheckURIInterval;
            m_httpFail = m_taskParameter.CheckURICount;
            if (m_taskParameter.CheckURI)
            {
                m_httpCheckAction = new ActionOpenSimHttpCheck();
                m_httpCheckAction.Parameter = m_taskParameter.HttpConfig;
            }

            while (m_taskState == TaskState.Run)
            {
                if (m_taskProcessState != TaskProcessState.Run)
                {
                    m_threadWait--;
                    if (m_threadWait <= 0)
                        Run();
                }
                else
                {
                    if (m_taskParameter.CheckURI)
                    {
                        m_httpWait--;
                        if (m_httpWait <= 0)
                            if (!m_httpCheckAction.Execute())
                            {
                                m_httpFail--;
                                m_httpWait = m_taskParameter.CheckURIInterval;
                                m_log.WarnFormat(":[{0}] http response are missed", m_taskParameter.Description);
                                if (m_httpFail <= 0)
                                {
                                    m_log.WarnFormat(":[{0}] http response are missed ({1} count(s), killing process!", m_taskParameter.Description, m_taskParameter.CheckURICount);
                                    StopProcess();
                                }
                            }
                            else
                            {
                                m_httpFail = m_taskParameter.CheckURICount;
                                m_httpWait = m_taskParameter.CheckURIInterval;
                            }
                    }
                }

                Thread.Sleep(1000);            
            }
            m_taskState = TaskState.Stop;
        }

        internal void Run()
        {
            if (!FillStartup())
            {
                return;
            }

            m_process = Process.Start(m_startInfo);
            if (!m_process.HasExited)
            {
                m_process.EnableRaisingEvents = true;
                m_process.Exited += new EventHandler(OnProcessExited);
                m_taskParameter.LastStart = Util.CurrentUnix;
                m_restartCount++;
                m_taskProcessState = TaskProcessState.Run;
                m_taskState = TaskState.Run;
                ApplicationBase.Instance.EventHandler.TriggerOnTaskProcessStart(this, "Task Process started");
                m_log.InfoFormat(":[{0}] (re)starting {1}", m_taskParameter.Description, m_taskParameter.StartupParameter.FullPath);
                return;
            }
            m_taskProcessState = TaskProcessState.Stop;
        }

        internal bool CheckProcessPresence()
        {
            m_process = Util.FindProcess(this.m_taskParameter.StartupParameter.FullPath);
            if (m_process == null)
            {
                m_taskProcessState = TaskProcessState.Stop;
                return false;
            }
            m_process.Exited += new EventHandler(OnProcessExited);
            m_taskProcessState = TaskProcessState.Run;
            ApplicationBase.Instance.EventHandler.TriggerOnTaskProcessStart(this, "Task Process is running");
            m_log.InfoFormat(":[{0}] found running instance for {1}", m_taskParameter.Description, m_taskParameter.StartupParameter.FullPath);
            return true;
        }

        public void StartTask()
        {
            CheckProcessPresence();
            if (m_taskParameter.TaskEnabled)
            {
                m_thread = new Thread(this.Worker);
                m_thread.Start();
            }
            else
            {
                m_taskState = TaskState.Disabled;
            }
        }

        public void StopTask()
        {
            if (m_thread != null)
                m_thread.Abort();
            m_thread = null;
            m_taskState = TaskState.Stop;
            ApplicationBase.Instance.EventHandler.TriggerOnTaskStop(this, "Task stopped");
        }

        public void StopProcess()
        {
            if (null != m_process)
            {
                if (m_process.Id != 0)
                    m_process.Kill();

                m_process.WaitForExit();
                m_process.Exited -= OnProcessExited;
                m_process.Dispose();
                m_process = null;
                m_taskProcessState = TaskProcessState.Stop;
                ApplicationBase.Instance.EventHandler.TriggerOnTaskProcessStop(this, "Task Process stopped");
            }
        }

        void OnProcessExited(object sender, EventArgs e)
        {
            m_log.WarnFormat(":[{0}] Process exited: {1}", m_taskParameter.Description, m_taskParameter.StartupParameter.FullPath);
            m_process.Exited -= OnProcessExited;
            m_process.Dispose();
            m_threadWait = m_taskParameter.CheckInterval;
            m_httpWait = m_taskParameter.CheckURIInterval;
            m_httpFail = m_taskParameter.CheckURICount;
            m_taskProcessState = TaskProcessState.Exit;
            ApplicationBase.Instance.EventHandler.TriggerOnTaskProcessStop(this, "Task Process exited");
        }

    }
}
