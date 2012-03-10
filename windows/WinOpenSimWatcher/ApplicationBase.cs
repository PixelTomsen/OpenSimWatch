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
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Reflection;
using log4net;

namespace OpenSimWatcher
{
    public partial class ApplicationBase
    {
        private static readonly ILog m_log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static ApplicationBase instance = null;
        private ApplicationOptions AppOptions;

        protected BaseHandler m_eventHandler;
        public BaseHandler EventHandler
        {
            get { return m_eventHandler; }
        }

        public TaskListOptions TaskListOptions;
        public List<TaskItem> TaskList;

        public static ApplicationBase Instance { get { return instance; } }

        public ApplicationBase()
        {
            instance = this;
            m_eventHandler = new BaseHandler();
            LoadOptions();
            InitializeUI();
            Initialize();
        }

        private void Initialize()
        {
            m_eventHandler.OnTaskStart += OnTaskStart;
            m_eventHandler.OnTaskProcessStart += OnTaskProcessStart;
            m_eventHandler.OnTaskStop += OnTaskStop;
            m_eventHandler.OnTaskProcessStop += OnTaskProcessStop;

            TaskList = new List<TaskItem>();
            LoadTaskOptions();
            ReloadTasks();
            this.mainDialog = new MainDialog();
            StartTaskWorker();
        }

        private int CountWorkers()
        {
            int i = 0;
            foreach (TaskItem t in TaskList)
            {
                if (t.GetTaskState == TaskState.Run || t.GetTaskState == TaskState.Stop)
                    i++;
            }
            return i;
        }

        public void ReloadTasks()
        {
            StopTaskWorker();
            TaskList.Clear();
            m_log.DebugFormat(":[BASE] Reloading Tasks");
            foreach (TaskParameter task in TaskListOptions.TaskListItems)
            {
                TaskItem m_item = new TaskItem();
                m_item.ParameterTask = task;
                TaskList.Add(m_item);
            }
            if (TaskList.Count == 0)
            {
                DisableWatcher("No Tasks loaded !");
            }
        }

        public void StartTaskWorker()
        {
            foreach (TaskItem t in TaskList)
            {
                t.StartTask();
            }
        }

        private void StartTaskWorker(TaskItem t)
        {
            if (TaskList.Contains(t))
                t.StartTask();
        }


        public void StopTaskWorker()
        {
            foreach (TaskItem t in TaskList)
            {
                t.StopTask();
            }
        }

        private void StopTaskWorker(TaskItem t)
        {
            if (TaskList.Contains(t))
                t.StopTask();
        }

        void OnTaskStart(TaskItem t, string message)
        {
            EnableWatcher();
        }

        void OnTaskProcessStart(TaskItem t, string message)
        {
        }


        void OnTaskStop(TaskItem t, string message)
        {
            if (CountWorkers() == 0)
                DisableWatcher();
            else
                EnableWatcher();
        }

        void OnTaskProcessStop(TaskItem t, string message)
        {
        }

    }
}
