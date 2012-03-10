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
using System.IO;
using System.Net;
using System.Reflection;
using log4net;

namespace OpenSimWatcher
{
    public class ActionOpenSimHttpCheck : IActionHTTPCheckMethode
    {
        private static readonly ILog m_log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        public string Name { get { return "OS HTTP-Check"; } }
        public string Description { get { return "Calls an given URL"; } }

        private int m_count = 0;
        public int Count { get { return m_count; } }

        private string m_response = String.Empty;
        public string Response { get { return m_response; } }

        private HttpParameter m_parameter = new HttpParameter();
        public HttpParameter Parameter
        {
            get { m_parameter.PartURL = "/simstatus/"; return m_parameter; }
            set { m_parameter = value; }
        }

        public bool Execute()
        {
            HttpWebRequest request;
            HttpWebResponse response;

            m_count++;

            try
            {
                request = (HttpWebRequest)WebRequest.Create(m_parameter.URL);
            }

            catch (Exception e)
            {
                m_log.ErrorFormat("[EXECUTE] Call Url:{0}; Count:{1}; Message:{2}", m_parameter.URL, m_count, e.Message);
                return false;
            }

            try
            {
                response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream);
                
                m_response = streamReader.ReadToEnd();
                streamReader.Close();
                responseStream.Close();
                if (m_response.Contains("OK"))
                    return true;
            }

            catch (Exception e)
            {
                m_log.ErrorFormat("[EXECUTE] Get Response Url:{0}; Count:{1}; Message:{2}", m_parameter.URL, m_count, e.Message);
                return false;
            }
            return false;
        }

    }

}
