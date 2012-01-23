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
    partial class MainDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDialog));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusClock = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView = new System.Windows.Forms.ListView();
            this.columnNr = new System.Windows.Forms.ColumnHeader();
            this.columnDesc = new System.Windows.Forms.ColumnHeader();
            this.columnTaskStatus = new System.Windows.Forms.ColumnHeader();
            this.columnProcessStatus = new System.Windows.Forms.ColumnHeader();
            this.columnRestart = new System.Windows.Forms.ColumnHeader();
            this.columnCount = new System.Windows.Forms.ColumnHeader();
            this.listViewMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.caddTask = new System.Windows.Forms.ToolStripMenuItem();
            this.ceditTask = new System.Windows.Forms.ToolStripMenuItem();
            this.cdeleteTask = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.cStartStopTask = new System.Windows.Forms.ToolStripMenuItem();
            this.cStartStopProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.listViewMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "*.exe";
            this.openFileDialog.FileName = "openFileDialog";
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            this.openFileDialog.ShowReadOnly = true;
            this.openFileDialog.SupportMultiDottedExtensions = true;
            // 
            // statusBar
            // 
            this.statusBar.AccessibleDescription = null;
            this.statusBar.AccessibleName = null;
            resources.ApplyResources(this.statusBar, "statusBar");
            this.statusBar.BackColor = System.Drawing.Color.Silver;
            this.statusBar.BackgroundImage = null;
            this.statusBar.Font = null;
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusClock});
            this.statusBar.Name = "statusBar";
            // 
            // statusClock
            // 
            this.statusClock.AccessibleDescription = null;
            this.statusClock.AccessibleName = null;
            resources.ApplyResources(this.statusClock, "statusClock");
            this.statusClock.BackgroundImage = null;
            this.statusClock.Name = "statusClock";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AccessibleDescription = null;
            this.statusStrip1.AccessibleName = null;
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.BackColor = System.Drawing.Color.Linen;
            this.statusStrip1.BackgroundImage = null;
            this.statusStrip1.Font = null;
            this.statusStrip1.Name = "statusStrip1";
            // 
            // menuMain
            // 
            this.menuMain.AccessibleDescription = null;
            this.menuMain.AccessibleName = null;
            resources.ApplyResources(this.menuMain, "menuMain");
            this.menuMain.BackgroundImage = null;
            this.menuMain.Font = null;
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem1,
            this.menuAbout});
            this.menuMain.Name = "menuMain";
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.AccessibleDescription = null;
            this.editToolStripMenuItem1.AccessibleName = null;
            resources.ApplyResources(this.editToolStripMenuItem1, "editToolStripMenuItem1");
            this.editToolStripMenuItem1.BackgroundImage = null;
            this.editToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTaskToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitMenu});
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.ShortcutKeyDisplayString = null;
            // 
            // addTaskToolStripMenuItem
            // 
            this.addTaskToolStripMenuItem.AccessibleDescription = null;
            this.addTaskToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.addTaskToolStripMenuItem, "addTaskToolStripMenuItem");
            this.addTaskToolStripMenuItem.BackgroundImage = null;
            this.addTaskToolStripMenuItem.Image = global::OpenSimWatcher.Properties.Resources.IconNew;
            this.addTaskToolStripMenuItem.Name = "addTaskToolStripMenuItem";
            this.addTaskToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.addTaskToolStripMenuItem.Click += new System.EventHandler(this.caddTask_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.AccessibleDescription = null;
            this.toolStripMenuItem2.AccessibleName = null;
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            // 
            // exitMenu
            // 
            this.exitMenu.AccessibleDescription = null;
            this.exitMenu.AccessibleName = null;
            resources.ApplyResources(this.exitMenu, "exitMenu");
            this.exitMenu.BackgroundImage = null;
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.ShortcutKeyDisplayString = null;
            this.exitMenu.Click += new System.EventHandler(this.exitMenu_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.AccessibleDescription = null;
            this.menuAbout.AccessibleName = null;
            resources.ApplyResources(this.menuAbout, "menuAbout");
            this.menuAbout.BackgroundImage = null;
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.ShortcutKeyDisplayString = null;
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.AccessibleDescription = null;
            this.editToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            this.editToolStripMenuItem.BackgroundImage = null;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.ShortcutKeyDisplayString = null;
            // 
            // addNewTaskToolStripMenuItem
            // 
            this.addNewTaskToolStripMenuItem.AccessibleDescription = null;
            this.addNewTaskToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.addNewTaskToolStripMenuItem, "addNewTaskToolStripMenuItem");
            this.addNewTaskToolStripMenuItem.BackgroundImage = null;
            this.addNewTaskToolStripMenuItem.Name = "addNewTaskToolStripMenuItem";
            this.addNewTaskToolStripMenuItem.ShortcutKeyDisplayString = null;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.AccessibleDescription = null;
            this.toolStripMenuItem1.AccessibleName = null;
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.AccessibleDescription = null;
            this.closeToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.closeToolStripMenuItem, "closeToolStripMenuItem");
            this.closeToolStripMenuItem.BackgroundImage = null;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeyDisplayString = null;
            // 
            // listView
            // 
            this.listView.AccessibleDescription = null;
            this.listView.AccessibleName = null;
            this.listView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            resources.ApplyResources(this.listView, "listView");
            this.listView.BackgroundImage = null;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNr,
            this.columnDesc,
            this.columnTaskStatus,
            this.columnProcessStatus,
            this.columnRestart,
            this.columnCount});
            this.listView.ContextMenuStrip = this.listViewMenu;
            this.listView.Font = null;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseDoubleClick);
            this.listView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseClick);
            this.listView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView_MouseClick);
            // 
            // columnNr
            // 
            resources.ApplyResources(this.columnNr, "columnNr");
            // 
            // columnDesc
            // 
            resources.ApplyResources(this.columnDesc, "columnDesc");
            // 
            // columnTaskStatus
            // 
            resources.ApplyResources(this.columnTaskStatus, "columnTaskStatus");
            // 
            // columnProcessStatus
            // 
            resources.ApplyResources(this.columnProcessStatus, "columnProcessStatus");
            // 
            // columnRestart
            // 
            resources.ApplyResources(this.columnRestart, "columnRestart");
            // 
            // columnCount
            // 
            resources.ApplyResources(this.columnCount, "columnCount");
            // 
            // listViewMenu
            // 
            this.listViewMenu.AccessibleDescription = null;
            this.listViewMenu.AccessibleName = null;
            resources.ApplyResources(this.listViewMenu, "listViewMenu");
            this.listViewMenu.BackgroundImage = null;
            this.listViewMenu.Font = null;
            this.listViewMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.caddTask,
            this.ceditTask,
            this.cdeleteTask,
            this.toolStripMenuItem3,
            this.cStartStopTask,
            this.cStartStopProcess});
            this.listViewMenu.Name = "listViewMenu";
            // 
            // caddTask
            // 
            this.caddTask.AccessibleDescription = null;
            this.caddTask.AccessibleName = null;
            resources.ApplyResources(this.caddTask, "caddTask");
            this.caddTask.BackgroundImage = null;
            this.caddTask.Image = global::OpenSimWatcher.Properties.Resources.IconNew;
            this.caddTask.Name = "caddTask";
            this.caddTask.ShortcutKeyDisplayString = null;
            this.caddTask.Click += new System.EventHandler(this.caddTask_Click);
            // 
            // ceditTask
            // 
            this.ceditTask.AccessibleDescription = null;
            this.ceditTask.AccessibleName = null;
            resources.ApplyResources(this.ceditTask, "ceditTask");
            this.ceditTask.BackgroundImage = null;
            this.ceditTask.Image = global::OpenSimWatcher.Properties.Resources.IconEdit;
            this.ceditTask.Name = "ceditTask";
            this.ceditTask.ShortcutKeyDisplayString = null;
            this.ceditTask.Click += new System.EventHandler(this.ceditTask_Click);
            // 
            // cdeleteTask
            // 
            this.cdeleteTask.AccessibleDescription = null;
            this.cdeleteTask.AccessibleName = null;
            resources.ApplyResources(this.cdeleteTask, "cdeleteTask");
            this.cdeleteTask.BackgroundImage = null;
            this.cdeleteTask.Image = global::OpenSimWatcher.Properties.Resources.IconDelete;
            this.cdeleteTask.Name = "cdeleteTask";
            this.cdeleteTask.ShortcutKeyDisplayString = null;
            this.cdeleteTask.Click += new System.EventHandler(this.cdeleteTask_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.AccessibleDescription = null;
            this.toolStripMenuItem3.AccessibleName = null;
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            // 
            // cStartStopTask
            // 
            this.cStartStopTask.AccessibleDescription = null;
            this.cStartStopTask.AccessibleName = null;
            resources.ApplyResources(this.cStartStopTask, "cStartStopTask");
            this.cStartStopTask.BackgroundImage = null;
            this.cStartStopTask.Name = "cStartStopTask";
            this.cStartStopTask.ShortcutKeyDisplayString = null;
            // 
            // cStartStopProcess
            // 
            this.cStartStopProcess.AccessibleDescription = null;
            this.cStartStopProcess.AccessibleName = null;
            resources.ApplyResources(this.cStartStopProcess, "cStartStopProcess");
            this.cStartStopProcess.BackgroundImage = null;
            this.cStartStopProcess.Name = "cStartStopProcess";
            this.cStartStopProcess.ShortcutKeyDisplayString = null;
            // 
            // MainDialog
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.listView);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuMain);
            this.Font = null;
            this.Icon = global::OpenSimWatcher.Properties.Resources.TrayIcon;
            this.MainMenuStrip = this.menuMain;
            this.MaximizeBox = false;
            this.Name = "MainDialog";
            this.VisibleChanged += new System.EventHandler(this.MainDialog_VisibleChanged);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainDialog_FormClosed);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.listViewMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.ColumnHeader columnNr;
        private System.Windows.Forms.ColumnHeader columnDesc;
        private System.Windows.Forms.ColumnHeader columnRestart;
        private System.Windows.Forms.ColumnHeader columnTaskStatus;
        private System.Windows.Forms.ContextMenuStrip listViewMenu;
        private System.Windows.Forms.ToolStripMenuItem ceditTask;
        private System.Windows.Forms.ToolStripMenuItem caddTask;
        private System.Windows.Forms.ToolStripMenuItem cdeleteTask;
        private System.Windows.Forms.ColumnHeader columnCount;
        private System.Windows.Forms.ToolStripStatusLabel statusClock;
        private System.Windows.Forms.ColumnHeader columnProcessStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem cStartStopTask;
        private System.Windows.Forms.ToolStripMenuItem cStartStopProcess;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
    }
}