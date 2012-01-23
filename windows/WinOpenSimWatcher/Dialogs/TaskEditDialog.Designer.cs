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

namespace OpenSimWatcher
{
    partial class TaskEditDialog
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskEditDialog));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textApp = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.killCounter = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.httpInterval = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.taskInterval = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.textPort = new System.Windows.Forms.NumericUpDown();
            this.textUrl = new System.Windows.Forms.TextBox();
            this.checkHTTP = new System.Windows.Forms.CheckBox();
            this.checkEnabled = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textParameter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textFolder = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.killCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.httpInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPort)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Image = global::OpenSimWatcher.Properties.Resources.IconSave;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.toolTip.SetToolTip(this.btnOK, resources.GetString("btnOK.ToolTip"));
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::OpenSimWatcher.Properties.Resources.IconDelete;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.toolTip.SetToolTip(this.btnCancel, resources.GetString("btnCancel.ToolTip"));
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // textName
            // 
            this.textName.AcceptsTab = true;
            this.textName.BackColor = System.Drawing.Color.Cornsilk;
            this.textName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textName, "textName");
            this.textName.Name = "textName";
            this.toolTip.SetToolTip(this.textName, resources.GetString("textName.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // textApp
            // 
            this.textApp.AcceptsTab = true;
            this.textApp.BackColor = System.Drawing.Color.Cornsilk;
            this.textApp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textApp, "textApp");
            this.textApp.Name = "textApp";
            this.toolTip.SetToolTip(this.textApp, resources.GetString("textApp.ToolTip"));
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightGray;
            this.groupBox1.Controls.Add(this.killCounter);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.httpInterval);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.taskInterval);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textPort);
            this.groupBox1.Controls.Add(this.textUrl);
            this.groupBox1.Controls.Add(this.checkHTTP);
            this.groupBox1.Controls.Add(this.checkEnabled);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textParameter);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textFolder);
            this.groupBox1.Controls.Add(this.btnSelectFile);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textApp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textName);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // killCounter
            // 
            this.killCounter.BackColor = System.Drawing.Color.Cornsilk;
            this.killCounter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.killCounter, "killCounter");
            this.killCounter.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.killCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.killCounter.Name = "killCounter";
            this.toolTip.SetToolTip(this.killCounter, resources.GetString("killCounter.ToolTip"));
            this.killCounter.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            this.toolTip.SetToolTip(this.label8, resources.GetString("label8.ToolTip"));
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // httpInterval
            // 
            this.httpInterval.BackColor = System.Drawing.Color.Cornsilk;
            this.httpInterval.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.httpInterval, "httpInterval");
            this.httpInterval.Maximum = new decimal(new int[] {
            86400000,
            0,
            0,
            0});
            this.httpInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.httpInterval.Name = "httpInterval";
            this.toolTip.SetToolTip(this.httpInterval, resources.GetString("httpInterval.ToolTip"));
            this.httpInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // taskInterval
            // 
            this.taskInterval.BackColor = System.Drawing.Color.Cornsilk;
            this.taskInterval.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.taskInterval, "taskInterval");
            this.taskInterval.Maximum = new decimal(new int[] {
            86400000,
            0,
            0,
            0});
            this.taskInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.taskInterval.Name = "taskInterval";
            this.toolTip.SetToolTip(this.taskInterval, resources.GetString("taskInterval.ToolTip"));
            this.taskInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // textPort
            // 
            this.textPort.BackColor = System.Drawing.Color.Cornsilk;
            this.textPort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textPort, "textPort");
            this.textPort.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.textPort.Name = "textPort";
            this.toolTip.SetToolTip(this.textPort, resources.GetString("textPort.ToolTip"));
            // 
            // textUrl
            // 
            this.textUrl.AcceptsTab = true;
            this.textUrl.BackColor = System.Drawing.Color.Cornsilk;
            this.textUrl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textUrl, "textUrl");
            this.textUrl.Name = "textUrl";
            this.toolTip.SetToolTip(this.textUrl, resources.GetString("textUrl.ToolTip"));
            // 
            // checkHTTP
            // 
            resources.ApplyResources(this.checkHTTP, "checkHTTP");
            this.checkHTTP.Name = "checkHTTP";
            this.toolTip.SetToolTip(this.checkHTTP, resources.GetString("checkHTTP.ToolTip"));
            this.checkHTTP.UseVisualStyleBackColor = true;
            this.checkHTTP.CheckedChanged += new System.EventHandler(this.checkHTTP_CheckedChanged);
            // 
            // checkEnabled
            // 
            resources.ApplyResources(this.checkEnabled, "checkEnabled");
            this.checkEnabled.Name = "checkEnabled";
            this.checkEnabled.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // textParameter
            // 
            this.textParameter.AcceptsTab = true;
            this.textParameter.BackColor = System.Drawing.Color.Cornsilk;
            this.textParameter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textParameter, "textParameter");
            this.textParameter.Name = "textParameter";
            this.toolTip.SetToolTip(this.textParameter, resources.GetString("textParameter.ToolTip"));
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // textFolder
            // 
            this.textFolder.AcceptsTab = true;
            this.textFolder.BackColor = System.Drawing.Color.Cornsilk;
            this.textFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textFolder, "textFolder");
            this.textFolder.Name = "textFolder";
            this.textFolder.TabStop = false;
            this.toolTip.SetToolTip(this.textFolder, resources.GetString("textFolder.ToolTip"));
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnSelectFile, "btnSelectFile");
            this.btnSelectFile.Image = global::OpenSimWatcher.Properties.Resources.IconOpenFile;
            this.btnSelectFile.Name = "btnSelectFile";
            this.toolTip.SetToolTip(this.btnSelectFile, resources.GetString("btnSelectFile.ToolTip"));
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 300;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ShowAlways = true;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Hint";
            // 
            // TaskEditDialog
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::OpenSimWatcher.Properties.Resources.TrayIcon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskEditDialog";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.killCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.httpInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textApp;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox textFolder;
        private System.Windows.Forms.TextBox textParameter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkEnabled;
        private System.Windows.Forms.TextBox textUrl;
        private System.Windows.Forms.CheckBox checkHTTP;
        private System.Windows.Forms.NumericUpDown textPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown taskInterval;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown httpInterval;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown killCounter;
        private System.Windows.Forms.Label label9;
    }
}