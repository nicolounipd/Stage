namespace RulesEditor
{
    internal partial class EditorUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contexMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.undoContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cutContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addRepeatContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRuleContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateRuleContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRuleContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textEditorControl = new ICSharpCode.TextEditor.TextEditorControl();
            this.contexMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contexMenuStrip
            // 
            this.contexMenuStrip.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.contexMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contexMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoContextMenuItem,
            this.redoContextMenuItem,
            this.menuSeparator1,
            this.cutContextMenuItem,
            this.copyMenuItem,
            this.pasteContextMenuItem,
            this.deleteContextMenuItem,
            this.selectAllContextMenuItem,
            this.menuSeparator2,
            this.addRepeatContextMenuItem,
            this.addRuleContextMenuItem,
            this.updateRuleContextMenuItem,
            this.deleteRuleContextMenuItem});
            this.contexMenuStrip.Name = "contextMenuStrip1";
            this.contexMenuStrip.Size = new System.Drawing.Size(254, 308);
            this.contexMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuOpening);
            // 
            // undoContextMenuItem
            // 
            this.undoContextMenuItem.Name = "undoContextMenuItem";
            this.undoContextMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoContextMenuItem.Size = new System.Drawing.Size(253, 24);
            this.undoContextMenuItem.Text = "Annulla";
            this.undoContextMenuItem.Click += new System.EventHandler(this.UndoBtnClicked);
            // 
            // redoContextMenuItem
            // 
            this.redoContextMenuItem.Name = "redoContextMenuItem";
            this.redoContextMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoContextMenuItem.Size = new System.Drawing.Size(253, 24);
            this.redoContextMenuItem.Text = "Ripeti";
            this.redoContextMenuItem.Click += new System.EventHandler(this.RedoBtnClicked);
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            this.menuSeparator1.Size = new System.Drawing.Size(250, 6);
            // 
            // cutContextMenuItem
            // 
            this.cutContextMenuItem.Name = "cutContextMenuItem";
            this.cutContextMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutContextMenuItem.Size = new System.Drawing.Size(253, 24);
            this.cutContextMenuItem.Text = "Taglia";
            this.cutContextMenuItem.Click += new System.EventHandler(this.CutBtnClicked);
            // 
            // copyMenuItem
            // 
            this.copyMenuItem.Name = "copyMenuItem";
            this.copyMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyMenuItem.Size = new System.Drawing.Size(253, 24);
            this.copyMenuItem.Text = "Copia";
            this.copyMenuItem.Click += new System.EventHandler(this.CopyBtnClicked);
            // 
            // pasteContextMenuItem
            // 
            this.pasteContextMenuItem.Name = "pasteContextMenuItem";
            this.pasteContextMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteContextMenuItem.Size = new System.Drawing.Size(253, 24);
            this.pasteContextMenuItem.Text = "Incolla";
            this.pasteContextMenuItem.Click += new System.EventHandler(this.PasteBtnClicked);
            // 
            // deleteContextMenuItem
            // 
            this.deleteContextMenuItem.Name = "deleteContextMenuItem";
            this.deleteContextMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteContextMenuItem.Size = new System.Drawing.Size(253, 24);
            this.deleteContextMenuItem.Text = "Cancella";
            this.deleteContextMenuItem.Click += new System.EventHandler(this.DeleteBtnClicked);
            // 
            // selectAllContextMenuItem
            // 
            this.selectAllContextMenuItem.Name = "selectAllContextMenuItem";
            this.selectAllContextMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllContextMenuItem.Size = new System.Drawing.Size(253, 24);
            this.selectAllContextMenuItem.Text = "Seleziona Tutto";
            this.selectAllContextMenuItem.Click += new System.EventHandler(this.SelectAllBtnClicked);
            // 
            // menuSeparator2
            // 
            this.menuSeparator2.Name = "menuSeparator2";
            this.menuSeparator2.Size = new System.Drawing.Size(250, 6);
            // 
            // addRepeatContextMenuItem
            // 
            this.addRepeatContextMenuItem.Name = "addRepeatContextMenuItem";
            this.addRepeatContextMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.addRepeatContextMenuItem.Size = new System.Drawing.Size(253, 24);
            this.addRepeatContextMenuItem.Text = "Inserisci Repeat";
            this.addRepeatContextMenuItem.Click += new System.EventHandler(this.AddRepeatBtnClicked);
            // 
            // addRuleContextMenuItem
            // 
            this.addRuleContextMenuItem.Name = "addRuleContextMenuItem";
            this.addRuleContextMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.addRuleContextMenuItem.Size = new System.Drawing.Size(253, 24);
            this.addRuleContextMenuItem.Text = "Inserisci Regola";
            this.addRuleContextMenuItem.Click += new System.EventHandler(this.AddRuleBtnClicked);
            // 
            // updateRuleContextMenuItem
            // 
            this.updateRuleContextMenuItem.Name = "updateRuleContextMenuItem";
            this.updateRuleContextMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.updateRuleContextMenuItem.Size = new System.Drawing.Size(253, 24);
            this.updateRuleContextMenuItem.Text = "Aggiorna Regola";
            this.updateRuleContextMenuItem.Click += new System.EventHandler(this.UpdateRuleBtnClicked);
            // 
            // deleteRuleContextMenuItem
            // 
            this.deleteRuleContextMenuItem.Name = "deleteRuleContextMenuItem";
            this.deleteRuleContextMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.deleteRuleContextMenuItem.Size = new System.Drawing.Size(253, 24);
            this.deleteRuleContextMenuItem.Text = "Rimuovi Regola";
            this.deleteRuleContextMenuItem.Click += new System.EventHandler(this.DeleteRuleBtnClicked);
            // 
            // textEditorControl
            // 
            this.textEditorControl.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textEditorControl.ContextMenuStrip = this.contexMenuStrip;
            this.textEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditorControl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textEditorControl.IsReadOnly = false;
            this.textEditorControl.Location = new System.Drawing.Point(0, 0);
            this.textEditorControl.Margin = new System.Windows.Forms.Padding(4);
            this.textEditorControl.Name = "textEditorControl";
            this.textEditorControl.Size = new System.Drawing.Size(656, 342);
            this.textEditorControl.TabIndex = 1;
            // 
            // EditorUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.textEditorControl);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EditorUserControl";
            this.Size = new System.Drawing.Size(656, 342);
            this.contexMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contexMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem redoContextMenuItem;
        private ICSharpCode.TextEditor.TextEditorControl textEditorControl;
        private System.Windows.Forms.ToolStripMenuItem undoContextMenuItem;
        private System.Windows.Forms.ToolStripSeparator menuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cutContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllContextMenuItem;
        private System.Windows.Forms.ToolStripSeparator menuSeparator2;
        private System.Windows.Forms.ToolStripMenuItem addRepeatContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRuleContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateRuleContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteRuleContextMenuItem;
    }
}
