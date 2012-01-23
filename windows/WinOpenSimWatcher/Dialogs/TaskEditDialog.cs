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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenSimWatcher
{
    public partial class TaskEditDialog : Form
    {
        private TaskParameter Parameter;

        public TaskEditDialog()
        {
            InitializeComponent();
        }

        public TaskEditDialog(string title, TaskParameter task)
        {
            InitializeComponent();
            this.Text = title;
            Parameter = task;
            InitData();
        }


        private void InitData()
        {
            this.checkEnabled.Checked = Parameter.TaskEnabled;
            this.taskInterval.Value = Convert.ToDecimal(Parameter.CheckInterval);
            this.textName.Text = Parameter.Description;
            this.textApp.Text = Parameter.StartupParameter.AppName;
            this.textFolder.Text = Parameter.StartupParameter.StartupPath;
            this.textParameter.Text = Parameter.StartupParameter.Args;
            this.textUrl.Text = Parameter.Host;
            this.textPort.Value = Convert.ToDecimal(Parameter.Port);
            this.checkHTTP.Checked = Parameter.CheckURI;
            this.httpInterval.Value = Convert.ToDecimal(Parameter.CheckURIInterval);
            this.killCounter.Value = Convert.ToDecimal(Parameter.CheckURICount);
            this.textUrl.Enabled = checkHTTP.Checked;
            this.textPort.Enabled = checkHTTP.Checked;
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (Parameter.StartupParameter.StartupPath.Length != 0)
                openFileDialog.InitialDirectory = Parameter.StartupParameter.StartupPath;
            if (Parameter.StartupParameter.AppName.Length != 0)
                openFileDialog.FileName = Parameter.StartupParameter.AppName;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Parameter.StartupParameter.AppName = Path.GetFileName(openFileDialog.FileName);
                Parameter.StartupParameter.StartupPath = Path.GetDirectoryName(openFileDialog.FileName) + Path.DirectorySeparatorChar;
                this.textApp.Text = Parameter.StartupParameter.AppName;
                this.textFolder.Text = Parameter.StartupParameter.StartupPath;
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Parameter.TaskEnabled = this.checkEnabled.Checked;
            Parameter.CheckInterval = Convert.ToInt32(this.taskInterval.Value);
            Parameter.Description = this.textName.Text;
            Parameter.StartupParameter.AppName = this.textApp.Text;
            Parameter.StartupParameter.StartupPath = this.textFolder.Text;
            Parameter.StartupParameter.Args = this.textParameter.Text;
            Parameter.Host = this.textUrl.Text;
            Parameter.Port = Convert.ToInt32(this.textPort.Value);
            Parameter.CheckURI = this.checkHTTP.Checked;
            Parameter.CheckURIInterval = Convert.ToInt32(this.httpInterval.Value);
            Parameter.CheckURICount = Convert.ToInt32(this.killCounter.Value);
        }

        private void checkHTTP_CheckedChanged(object sender, EventArgs e)
        {
            this.httpInterval.Enabled = checkHTTP.Checked;
            this.textUrl.Enabled = checkHTTP.Checked;
            this.textPort.Enabled = checkHTTP.Checked;
            this.killCounter.Enabled = checkHTTP.Checked;
        }

    }
}
