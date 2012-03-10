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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using log4net;

namespace OpenSimWatcher
{
    public partial class MainDialog : Form
    {
        private static readonly ILog m_log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private Color SetColor(int p)
        {
            switch (p)
            {
                case -2: return Color.Gray;
                case -1 : return Color.Red;
                case 0: return Color.Yellow;
                case 1: return Color.Green;
                default: return Color.Transparent;
            }         
        }       

        private string TaskProcessString(TaskProcessState p)
        {
            switch (p)
            {
                case TaskProcessState.Disabled : return "Disabled";
                case TaskProcessState.Exit: return "Exited";
                case TaskProcessState.Run : return "Run";
                case TaskProcessState.Stop : return "Stopped";
                default: return "Unknow"; 
            }
        }

        private string TaskString(TaskState p)
        {
            switch (p)
            {
                case TaskState.Disabled: return "Disabled";
                case TaskState.Invalidate: return "Invalidate";
                case TaskState.Run: return "Run";
                case TaskState.Stop: return "Stopped";
                default: return "Unknow";
            }
        }


        public MainDialog()
        {
            InitializeComponent();
            ApplicationBase.Instance.EventHandler.OnTaskStart += OnTaskStart;
            ApplicationBase.Instance.EventHandler.OnTaskProcessStart += OnTaskProcessStart;
            ApplicationBase.Instance.EventHandler.OnTaskStop += OnTaskStop;
            ApplicationBase.Instance.EventHandler.OnTaskProcessStop += OnTaskProcessStop;
        }


        private void FillList()
        {
            ListViewItem item;
            listView.Items.Clear();
            foreach (TaskItem t in ApplicationRuntime.AppBase.TaskList)
            {
                item = this.listView.Items.Add(t.ParameterTask.ID.ToString());
                item.UseItemStyleForSubItems = false;
                item.Tag = t.ParameterTask;
                item.SubItems.Add(t.ParameterTask.Description);
                item.SubItems.Add(TaskString(t.GetTaskState));
                item.SubItems.Add(TaskProcessString(t.GetTaskProcessState));
                item.SubItems.Add(Util.UnixToDate(t.ParameterTask.LastStart));
                item.SubItems.Add(t.RestartCounter.ToString());
                item.SubItems[this.columnProcessStatus.Index].BackColor = SetColor((int)t.GetTaskProcessState);
                item.SubItems[this.columnTaskStatus.Index].BackColor = SetColor((int)t.GetTaskState);              
            }
        }

        private void UpdateItem(TaskItem task)
        {
            // Disables Application Hang on Update 
            if (!this.Visible)
                return;

            ListViewItem item = listView.FindItemWithText(task.ParameterTask.ID.ToString());
            if (item != null)
            {
                item.SubItems[this.columnTaskStatus.Index].Text = TaskString(task.GetTaskState);
                item.SubItems[this.columnProcessStatus.Index].Text = TaskProcessString(task.GetTaskProcessState);
                item.SubItems[this.columnRestart.Index].Text = Util.UnixToDate(task.ParameterTask.LastStart);
                item.SubItems[this.columnCount.Index].Text = task.RestartCounter.ToString();
                item.SubItems[this.columnProcessStatus.Index].BackColor = SetColor((int)task.GetTaskProcessState);
                item.SubItems[this.columnTaskStatus.Index].BackColor = SetColor((int)task.GetTaskState);              

            }
        }


        private void exitMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem select = listView.GetItemAt(e.X, e.Y);

            if (select != null)
            {
                caddTask.Enabled = false;
                cdeleteTask.Enabled = true;
                ceditTask.Enabled = true;
            }
            else
            {
                caddTask.Enabled = true;
                cdeleteTask.Enabled = false;
                ceditTask.Enabled = false;
            }
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem select = listView.GetItemAt(e.X, e.Y);
            if (select != null)
            {
                TaskEditDialog dlg = new TaskEditDialog("Edit Task", (TaskParameter)select.Tag);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ApplicationBase.Instance.SaveTaskOptions();
                    ApplicationBase.Instance.ReloadTasks();
                    FillList();
                    ApplicationBase.Instance.StartTaskWorker();
                }

                dlg.Dispose();
            }
        }

        private void caddTask_Click(object sender, EventArgs e)
        {
            TaskParameter task = new TaskParameter();
            task.ID = ApplicationBase.Instance.TaskListOptions.GetNextID();
            task.Description = task.Description + task.ID.ToString();
            TaskEditDialog dlg = new TaskEditDialog("New Task", task);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ApplicationBase.Instance.TaskListOptions.AddTask(task);
                ApplicationBase.Instance.SaveTaskOptions();
                ApplicationBase.Instance.ReloadTasks();
                FillList();
                ApplicationBase.Instance.StartTaskWorker();
            }
        }

        private void ceditTask_Click(object sender, EventArgs e)
        {
            if (this.listView.SelectedItems != null)
            {
                ListViewItem item = this.listView.SelectedItems[0];
                TaskEditDialog dlg = new TaskEditDialog("Edit Task", (TaskParameter)item.Tag);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ApplicationBase.Instance.SaveTaskOptions();
                    ApplicationBase.Instance.ReloadTasks();
                    FillList();
                    ApplicationBase.Instance.StartTaskWorker();
                }

                dlg.Dispose();
            }
        }

        private void cdeleteTask_Click(object sender, EventArgs e)
        {
            if (this.listView.SelectedItems != null)
            {
                ListViewItem item = this.listView.SelectedItems[0];
                ApplicationBase.Instance.TaskListOptions.RemoveTask((TaskParameter)item.Tag);
                ApplicationBase.Instance.SaveTaskOptions();
                ApplicationBase.Instance.ReloadTasks();
                FillList();
                ApplicationBase.Instance.StartTaskWorker();
            }

        }

         void OnTaskStart(TaskItem t, string message)
        {
            UpdateItem(t);
        }

        void OnTaskProcessStart(TaskItem t, string message)
        {
            UpdateItem(t);
        }


        void OnTaskStop(TaskItem t, string message)
        {
            UpdateItem(t);
        }

        void OnTaskProcessStop(TaskItem t, string message)
        {
            UpdateItem(t);
        }

        private void MainDialog_VisibleChanged(object sender, EventArgs e)
        {
            FillList();
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            AboutBox dlg = new AboutBox();
            dlg.ShowDialog();
        }

        private void MainDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

     }
}
