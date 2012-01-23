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
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace OpenSimWatcher
{
    #region ApplicationOptions
    [XmlRoot("AppSettings")]
    public class ApplicationOptions
    {
        private string _language = "English";
 
        [XmlElement("WindowSize")]
        public System.Drawing.Size WindowSize
        { get; set; }

        [XmlElement("WindowLocation")]
        public System.Drawing.Point WindowLocation
        { get; set; }

        [XmlElement("Language")]
        public string Language
        {
            get { return this._language; }
            set { this._language = value; }
        }

    }
    #endregion

    #region TaskListOptions
    [XmlRoot("TaskListSettings")]
    public class TaskListOptions
    {
        [XmlArray("Tasks")]
        [XmlArrayItem("Item", typeof(TaskParameter))]

        public ArrayList TaskListItems;

        public TaskListOptions() 
        {
            TaskListItems = new ArrayList();
        }

        public void AddTask(TaskParameter task)
        {
            TaskListItems.Add(task);
        }

        public void RemoveTask(TaskParameter task)
        {
            TaskListItems.Remove(task);
            int i = 1;
            foreach (TaskParameter t in TaskListItems)
            {
                t.ID = i;
                i++;
            }
        }

        public int GetNextID()
        {
            if (TaskListItems.Count == 0)
                return 1;
            return ((TaskParameter)TaskListItems[TaskListItems.Count - 1]).ID + 1;
        }

    }

    #endregion

    public partial class ApplicationBase
    {
        private string ConfigFile = Util.ConfigFolder + "OpenSimWatcher.xml";
        private string TaskListFile = Util.ConfigFolder + "OpenSimWatcherTasks.xml";

        #region Load/Save ApplicationOptions
        public void LoadOptions()
        {
            if (File.Exists(ConfigFile))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(ApplicationOptions));
                TextReader textReader = new StreamReader(ConfigFile);
                AppOptions = (ApplicationOptions)deserializer.Deserialize(textReader);
                textReader.Close();
                textReader.Dispose();
            }
            else
            {
                AppOptions = new ApplicationOptions();
                SaveOptions();
            }
        }

        public void SaveOptions()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ApplicationOptions));
            TextWriter textWriter = new StreamWriter(ConfigFile);
            serializer.Serialize(textWriter, AppOptions);
            textWriter.Close();
            textWriter.Dispose();
        }
        #endregion

        #region Load/Save TaskOptions

        public void LoadTaskOptions()
        {
            if (File.Exists(TaskListFile))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(TaskListOptions));
                TextReader textReader = new StreamReader(TaskListFile);
                TaskListOptions = (TaskListOptions)deserializer.Deserialize(textReader);
                textReader.Close();
                textReader.Dispose();
            }
            else
            {
                TaskListOptions = new TaskListOptions();
            }
        }

        public void SaveTaskOptions()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TaskListOptions));
            TextWriter textWriter = new StreamWriter(TaskListFile);
            serializer.Serialize(textWriter, TaskListOptions);
            textWriter.Close();
            textWriter.Dispose();
        }
        #endregion


    }
}