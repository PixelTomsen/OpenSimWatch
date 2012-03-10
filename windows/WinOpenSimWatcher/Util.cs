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
using System.ComponentModel;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using log4net;

namespace OpenSimWatcher
{
    
    public static class Util
    {
        private static readonly ILog m_log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region TimeDate Util
        public static int CurrentUnix
        {
            get
            {
                TimeSpan t = (DateTime.Now - new DateTime(1970, 1, 1));
                return (int)t.TotalSeconds;
            }
        }

        public static string UnixToDate(int unix)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dt = dt.AddSeconds(unix);
            return String.Format("{0}-{1}", dt.ToShortDateString(), dt.ToLongTimeString());
        }

        #endregion

   
        #region FileUtil

        public static string LogFile = "OpenSimWatcher.log";

        private static string m_logFolder = HomeFolder + "logs" + Path.DirectorySeparatorChar;
        private static string m_configFolder = HomeFolder + "configs" + Path.DirectorySeparatorChar;

        public static string HomeFolder
        {
            get { return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar; }
        }

        public static string LogFolder
        {
            get { CheckFolder(m_logFolder, true); return m_logFolder; } 
        }

        public static string ConfigFolder
        {
            get { CheckFolder(m_configFolder, true); return m_configFolder; }
        }


        public static bool CheckFolder(string Folder, bool doCreate)
        {
            bool bResult = Directory.Exists(Folder);

            if (!bResult && doCreate == true) 
            {
                try
                {
                    Directory.CreateDirectory(Folder);
                }
                catch (System.IO.IOException ex)
                {
                    Util.ExceptionFile(String.Format("{0}", ex.Message));
                    return false;
                }
                return true;
            }
            return bResult;
        }

        public static void MoveLog()
        {
            if(File.Exists(HomeFolder + LogFile))
            {
                string tempFile = String.Format("{0}_{1}.log", Path.GetFileNameWithoutExtension(LogFile), CurrentUnix);
                if (CheckFolder(LogFolder, true))
                {
                    try
                    {
                        File.Move(HomeFolder + LogFile, LogFolder + tempFile);
                    }

                    catch (System.IO.IOException ex)
                    {
                      Util.ExceptionFile(String.Format("{0}", ex.Message));
                    }                  
                }
            }
        }


        public static void ExceptionFile(string message)
        {
            System.IO.StreamWriter io = new System.IO.StreamWriter(String.Format("{0}OpenSimWatcher_Exception.log", HomeFolder), true);
            io.WriteLine(String.Format("{0} - Exception : {1}", UnixToDate(CurrentUnix), message));
            io.Flush();
            io.Close();
            io.Dispose();
        }

        #endregion

        #region ProcessUtil

        public static Process[] ProcessList { get { return Process.GetProcesses(); } }
                
        public static Process FindProcess(string ModulName)
        {
            foreach (Process p in ProcessList)
            {
                try
                {
                    if (p.MainModule.FileName.Equals(ModulName))
                    {
                        p.EnableRaisingEvents = true;
                        return p;
                    }
                }
                catch(Win32Exception e)
                {
                  // here some access-denied exceptions for parsed System-Processes
                  // we hide this
                  // ExceptionFile(e.ErrorCode.ToString() + ":" + e.Message);  
                }
            }
            return null;
        }
        #endregion
    }   
}
