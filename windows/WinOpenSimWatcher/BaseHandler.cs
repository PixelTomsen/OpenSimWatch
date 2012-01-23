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
using System.Reflection;
using System.Text;
using log4net;

namespace OpenSimWatcher
{
    #region TaskEventArgs
    public class TaskEventArgs : EventArgs
    {
        private string m;

        public TaskEventArgs(string message)
        {
            m = message;
        }

        public string Message
        {
            get { return m; }
            set { m = value; }
        }

    }
    #endregion

    public class BaseHandler
    {
        private static readonly ILog m_log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region Delegates

        public delegate void OnTaskStartDelegate(TaskItem item, string message);
        public event OnTaskStartDelegate OnTaskStart;

        public delegate void OnTaskStopDelegate(TaskItem item, string message);
        public event OnTaskStopDelegate OnTaskStop;

        public delegate void OnTaskProcessStartDelegate(TaskItem item, string message);
        public event OnTaskProcessStartDelegate OnTaskProcessStart;

        public delegate void OnTaskProcessStopDelegate(TaskItem item, string message);
        public event OnTaskProcessStopDelegate OnTaskProcessStop;

        #endregion

        #region Trigger
        public void TriggerOnTaskStart(TaskItem item, string message)
        {
            OnTaskStartDelegate handlerTaskStart = OnTaskStart;
            if (handlerTaskStart != null)
            {
                foreach (OnTaskStartDelegate d in handlerTaskStart.GetInvocationList())
                {
                    try
                    {
                        d(item, message);
                    }
                    catch (Exception e)
                    {
                        m_log.ErrorFormat(
                            ": Delegate for TriggerOnTaskStart failed - continuing.  {0} {1}",
                            e.Message, e.StackTrace);
                    }
                }
            }

        }

        public void TriggerOnTaskProcessStart(TaskItem item, string message)
        {
            OnTaskProcessStartDelegate handlerTaskProcessStart = OnTaskProcessStart;
            if (handlerTaskProcessStart != null)
            {
                foreach (OnTaskProcessStartDelegate d in handlerTaskProcessStart.GetInvocationList())
                {
                    try
                    {
                        d(item, message);
                    }
                    catch (Exception e)
                    {
                        m_log.ErrorFormat(
                            ": Delegate for TriggerOnTaskProcessStart failed - continuing.  {0} {1}",
                            e.Message, e.StackTrace);
                    }
                }
            }
        }

        public void TriggerOnTaskStop(TaskItem item, string message)
        {
            OnTaskStopDelegate handlerTaskStop = OnTaskStop;
            if (handlerTaskStop != null)
            {
                foreach (OnTaskStopDelegate d in handlerTaskStop.GetInvocationList())
                {
                    try
                    {
                        d(item, message);
                    }
                    catch (Exception e)
                    {
                        m_log.ErrorFormat(
                            ": Delegate for TriggerOnTaskStop failed - continuing.  {0} {1}",
                            e.Message, e.StackTrace);
                    }
                }
            }
        }

        public void TriggerOnTaskProcessStop(TaskItem item, string message)
        {
            OnTaskProcessStopDelegate handlerTaskProcessStop = OnTaskProcessStop;
            if (handlerTaskProcessStop != null)
            {
                foreach (OnTaskProcessStopDelegate d in handlerTaskProcessStop.GetInvocationList())
                {
                    try
                    {
                        d(item, message);
                    }
                    catch (Exception e)
                    {
                        m_log.ErrorFormat(
                            ": Delegate for TriggerOnTaskProcessStop failed - continuing.  {0} {1}",
                            e.Message, e.StackTrace);
                    }
                }
            }
        }

        #endregion
    }
}