/* Project-Start 2011-11
 * (c)Pixel Tomsen (Christian Kurzhals) pixel.tomsen[at]gridnet.info
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

namespace OpenSimWatcher
{
    #region States Enum

    public enum TaskState
    {
        Disabled = -2,
        Invalidate = -1,
        Stop = 0,
        Run = 1
    };

    public enum TaskProcessState
    {
        Disabled = -2,
        Exit = -1,
        Stop = 0,
        Run = 1
    };

    #endregion

    #region StartupInfo
    public class StartupInfo
    {
        private string m_startupPath = String.Empty;
        private string m_appName = String.Empty;
        private string m_args = String.Empty;

        public string StartupPath
        {
            get { return m_startupPath; }
            set { m_startupPath = value; }
        }

        public string AppName
        {
            get { return m_appName; }
            set { m_appName = value; }
        }

        public string Args
        {
            get { return m_args; }
            set { m_args = value; }
        }

        public string FullPath { get { return StartupPath + AppName; } }

    }
    #endregion

    #region TaskAction
    public class TaskAction
    {
        public int ID
        { get; set; }

        private string m_description = "My TaskAction";
        public string Description
        {
            get { return m_description; }
            set { m_description = value; }
        }

        private StartupInfo m_startInfo;
        public StartupInfo StartParameter
        {
            get { return m_startInfo; }
            set { m_startInfo = value; }
        }
    }

    #endregion

    #region TaskParameter
    public class TaskParameter
    {
        public int ID
        { get; set; }

        private string m_description = "My Task";
        public string Description
        {
            get { return m_description; }
            set { m_description = value; }
        }

        private string m_host = "http://127.0.0.1";
        public string Host
        {
            get { return m_host; }
            set { m_host = value; }
        }

        private int m_port = 9000;
        public int Port
        {
            get { return m_port; }
            set { m_port = value; }
        }

        public string URI { get { return String.Format("{0}:{1}/simstatus/", m_host, m_port); } }

        private bool m_taskEnabled = true;
        public bool TaskEnabled
        {
            get { return m_taskEnabled; }
            set { m_taskEnabled = value; }
        }

        private bool m_checkURI = true;
        public bool CheckURI
        {
            get { return m_checkURI; }
            set { m_checkURI = value; }
        }

        private int m_checkURIInterval = 300; //5 minutes
        public int CheckURIInterval
        {
            get { return m_checkURIInterval; }
            set { m_checkURIInterval = value; }
        }

        private int m_checkURICount = 3; 
        public int CheckURICount
        {
            get { return m_checkURICount; }
            set { m_checkURICount = value; }
        }

        private StartupInfo m_startupInfo;
        public StartupInfo StartupParameter
        {
            get { return m_startupInfo; }
            set { m_startupInfo = value; }
        }

        private List<TaskAction> m_startBefore;
        public List<TaskAction> StartBefore
        {
            get { return m_startBefore; }
            set { m_startBefore = value; }
        }

        private List<TaskAction> m_startAfter;
        public List<TaskAction> StartAfter
        {
            get { return m_startAfter; }
            set { m_startAfter = value; }
        }

        private int m_checkTime = 60; // default 1 Minute
        public int CheckInterval
        {
            get { return m_checkTime; }
            set { m_checkTime = value; }
        }

        private int m_lastStart = 0;
        public int LastStart
        {
            get { return m_lastStart; }
            set { m_lastStart = value; }
        }

        public TaskParameter()
            : base()
        {
            m_startAfter = new List<TaskAction>();
            m_startBefore = new List<TaskAction>();
            m_startupInfo = new StartupInfo();
        }

    }
    #endregion
}
