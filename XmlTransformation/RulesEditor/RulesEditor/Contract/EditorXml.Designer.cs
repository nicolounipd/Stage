namespace RulesEditor
{
    partial class EditorXml
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compilerContainer = new System.Windows.Forms.ToolStripSeparator();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorContainer = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearConsoleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.container = new System.Windows.Forms.SplitContainer();
            this.editorTabControl = new System.Windows.Forms.TabControl();
            this.compilerTextBox = new System.Windows.Forms.TextBox();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.container)).BeginInit();
            this.container.Panel1.SuspendLayout();
            this.container.Panel2.SuspendLayout();
            this.container.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileStripMenuItem,
            this.buildStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1247, 30);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip";
            // 
            // fileStripMenuItem
            // 
            this.fileStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMenuItem,
            this.openMenuItem,
            this.removeMenuItem,
            this.compilerContainer,
            this.saveMenuItem,
            this.saveAsMenuItem,
            this.editorContainer,
            this.exitMenuItem});
            this.fileStripMenuItem.Name = "fileStripMenuItem";
            this.fileStripMenuItem.Size = new System.Drawing.Size(46, 26);
            this.fileStripMenuItem.Text = "File";
            // 
            // newMenuItem
            // 
            this.newMenuItem.Image = global::RulesEditor.Properties.Resources._new;
            this.newMenuItem.Name = "newMenuItem";
            this.newMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newMenuItem.Size = new System.Drawing.Size(321, 26);
            this.newMenuItem.Text = "Nuovo";
            this.newMenuItem.Click += new System.EventHandler(this.NewBtnClicked);
            // 
            // openMenuItem
            // 
            this.openMenuItem.Image = global::RulesEditor.Properties.Resources.open;
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openMenuItem.Size = new System.Drawing.Size(321, 26);
            this.openMenuItem.Text = "Apri";
            this.openMenuItem.Click += new System.EventHandler(this.OpenBtnClicked);
            // 
            // removeMenuItem
            // 
            this.removeMenuItem.Image = global::RulesEditor.Properties.Resources.remove;
            this.removeMenuItem.Name = "removeMenuItem";
            this.removeMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.removeMenuItem.Size = new System.Drawing.Size(321, 26);
            this.removeMenuItem.Text = "Rimuovi";
            this.removeMenuItem.Click += new System.EventHandler(this.RemoveBtnClicked);
            // 
            // compilerContainer
            // 
            this.compilerContainer.Name = "compilerContainer";
            this.compilerContainer.Size = new System.Drawing.Size(318, 6);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Image = global::RulesEditor.Properties.Resources.save;
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMenuItem.Size = new System.Drawing.Size(321, 26);
            this.saveMenuItem.Text = "Salva";
            this.saveMenuItem.Click += new System.EventHandler(this.SaveBtnClicked);
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.Image = global::RulesEditor.Properties.Resources.save_as;
            this.saveAsMenuItem.Name = "saveAsMenuItem";
            this.saveAsMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsMenuItem.Size = new System.Drawing.Size(321, 26);
            this.saveAsMenuItem.Text = "Salva con nome";
            this.saveAsMenuItem.Click += new System.EventHandler(this.SaveAsBtnClicked);
            // 
            // editorContainer
            // 
            this.editorContainer.Name = "editorContainer";
            this.editorContainer.Size = new System.Drawing.Size(318, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Image = global::RulesEditor.Properties.Resources.exit;
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(321, 26);
            this.exitMenuItem.Text = "Esci";
            this.exitMenuItem.Click += new System.EventHandler(this.ExitBtnClicked);
            // 
            // buildStripMenuItem
            // 
            this.buildStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildMenuItem,
            this.clearConsoleMenuItem});
            this.buildStripMenuItem.Name = "buildStripMenuItem";
            this.buildStripMenuItem.Size = new System.Drawing.Size(115, 26);
            this.buildStripMenuItem.Text = "Compilazione";
            // 
            // buildMenuItem
            // 
            this.buildMenuItem.Image = global::RulesEditor.Properties.Resources.build;
            this.buildMenuItem.Name = "buildMenuItem";
            this.buildMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.buildMenuItem.Size = new System.Drawing.Size(224, 26);
            this.buildMenuItem.Text = "Compila";
            this.buildMenuItem.Click += new System.EventHandler(this.BuildBtnClicked);
            // 
            // clearConsoleMenuItem
            // 
            this.clearConsoleMenuItem.Image = global::RulesEditor.Properties.Resources.clear;
            this.clearConsoleMenuItem.Name = "clearConsoleMenuItem";
            this.clearConsoleMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.clearConsoleMenuItem.Size = new System.Drawing.Size(224, 26);
            this.clearConsoleMenuItem.Text = "Pulisci";
            this.clearConsoleMenuItem.Click += new System.EventHandler(this.ClearConsoleBtnClicked);
            // 
            // container
            // 
            this.container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.container.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.container.Location = new System.Drawing.Point(0, 30);
            this.container.Name = "container";
            this.container.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // container.Panel1
            // 
            this.container.Panel1.Controls.Add(this.editorTabControl);
            // 
            // container.Panel2
            // 
            this.container.Panel2.Controls.Add(this.compilerTextBox);
            this.container.Size = new System.Drawing.Size(1247, 703);
            this.container.SplitterDistance = 594;
            this.container.TabIndex = 0;
            // 
            // editorTabControl
            // 
            this.editorTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorTabControl.Location = new System.Drawing.Point(0, 0);
            this.editorTabControl.Margin = new System.Windows.Forms.Padding(4);
            this.editorTabControl.Name = "editorTabControl";
            this.editorTabControl.SelectedIndex = 0;
            this.editorTabControl.Size = new System.Drawing.Size(1247, 594);
            this.editorTabControl.TabIndex = 1;
            // 
            // compilerTextBox
            // 
            this.compilerTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.compilerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compilerTextBox.Location = new System.Drawing.Point(0, 0);
            this.compilerTextBox.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.compilerTextBox.Multiline = true;
            this.compilerTextBox.Name = "compilerTextBox";
            this.compilerTextBox.ReadOnly = true;
            this.compilerTextBox.Size = new System.Drawing.Size(1247, 105);
            this.compilerTextBox.TabIndex = 2;
            // 
            // EditorXml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 733);
            this.Controls.Add(this.container);
            this.Controls.Add(this.menu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "EditorXml";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor delle regole";
            this.Load += new System.EventHandler(this.ApplicationStarted);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.container.Panel1.ResumeLayout(false);
            this.container.Panel2.ResumeLayout(false);
            this.container.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.container)).EndInit();
            this.container.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearConsoleMenuItem;
        private System.Windows.Forms.SplitContainer container;
        private System.Windows.Forms.ToolStripSeparator compilerContainer;
        private System.Windows.Forms.ToolStripSeparator editorContainer;
        private System.Windows.Forms.TabControl editorTabControl;
        private System.Windows.Forms.TextBox compilerTextBox;
    }
}