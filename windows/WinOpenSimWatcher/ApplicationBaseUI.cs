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
using System.Text;
using System.Reflection;
using log4net;

namespace OpenSimWatcher
{
    public partial class ApplicationBase
    {      
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyMenu;
        private System.Windows.Forms.ToolStripMenuItem menuSetup;
        private System.Windows.Forms.ToolStripSeparator menuSeperator;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private MainDialog mainDialog;
      
        private void InitializeUI()
        {         
            this.components = new System.ComponentModel.Container();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeperator = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyMenu;
            this.notifyIcon.Text = "OpenSimWatcher [Disabled]";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Icon = global::OpenSimWatcher.Properties.Resources.TrayIconDisabled;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.menuSetup_Click);
            // 
            // notifyMenu
            // 
            this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSetup, this.menuSeperator, this.menuExit});
            this.notifyMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.notifyMenu.Name = "notifyMenu";
            this.notifyMenu.Size = new System.Drawing.Size(145, 26);
            this.notifyMenu.Text = "OpenSimWatcher";
            // 
            // menuSetup
            // 
            this.menuSetup.Name = "menuSetup";
            this.menuSetup.Size = new System.Drawing.Size(144, 22);
            this.menuSetup.Text = "View";
            this.menuSetup.Image = global::OpenSimWatcher.Properties.Resources.IconSetup;
            this.notifyMenu.ResumeLayout(false);
            this.menuSetup.Click += new System.EventHandler(this.menuSetup_Click);
            // 
            // menuSeperator
            // 
            this.menuSeperator.Name = "menuSeperator";
            this.menuSeperator.Size = new System.Drawing.Size(131, 6);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(144, 22);
            this.menuExit.Text = "Exit";
            this.menuExit.Image = global::OpenSimWatcher.Properties.Resources.IconExit;
            this.notifyMenu.ResumeLayout(false);
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
        }

        private void DisableWatcher()
        {
            this.notifyIcon.Icon = global::OpenSimWatcher.Properties.Resources.TrayIconDisabled;
            this.notifyIcon.Text = "OpenSimWatcher [Disabled]";
        }

        private void DisableWatcher(string message)
        {    
            this.notifyIcon.Icon = global::OpenSimWatcher.Properties.Resources.TrayIconDisabled;
            this.notifyIcon.ShowBalloonTip(30, "Warning", message, System.Windows.Forms.ToolTipIcon.Warning);
            this.notifyIcon.Text = "OpenSimWatcher [Disabled]";
        }

        private void EnableWatcher()
        {
            this.notifyIcon.Icon = global::OpenSimWatcher.Properties.Resources.TrayIcon;
            this.notifyIcon.Text = "OpenSimWatcher";
        }

        private void EnableWatcher(string message)
        {
            this.notifyIcon.Icon = global::OpenSimWatcher.Properties.Resources.TrayIcon;
            this.notifyIcon.ShowBalloonTip(30, "Info", message, System.Windows.Forms.ToolTipIcon.Info);
            this.notifyIcon.Text = "OpenSimWatcher";
        }

        private void menuSetup_Click(object sender, EventArgs e)
        {
            if (!mainDialog.Visible)
                mainDialog.ShowDialog();
            else
                mainDialog.BringToFront();
        }


        private void menuExit_Click(object sender, EventArgs e)
        {
            ApplicationBase.Instance.StopTaskWorker();
            this.notifyIcon.Dispose();
            SaveOptions();
            SaveTaskOptions();
            m_log.Info("Exit Application");
            Environment.Exit(0);     
        }
    }
}
