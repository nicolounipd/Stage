namespace TransformationModule.Contract
{
    partial class TrasformtaionForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewContainer = new System.Windows.Forms.TableLayoutPanel();
            this.outputContainer = new System.Windows.Forms.TabControl();
            this.rulesContainer = new System.Windows.Forms.TabControl();
            this.xmlContainer = new System.Windows.Forms.TabControl();
            this.btnContainer = new System.Windows.Forms.TableLayoutPanel();
            this.transformXmlBtn = new System.Windows.Forms.Button();
            this.loadRulesBtn = new System.Windows.Forms.Button();
            this.loadXmlbtn = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menu.SuspendLayout();
            this.viewContainer.SuspendLayout();
            this.btnContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1579, 28);
            this.menu.TabIndex = 4;
            this.menu.Text = "menu";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveMenuItem,
            this.exitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileMenuItem.Text = "File";
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Image = global::TransformationModule.Properties.Resources.save;
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMenuItem.Size = new System.Drawing.Size(187, 26);
            this.saveMenuItem.Text = "Salva";
            this.saveMenuItem.Click += new System.EventHandler(this.SaveBtnClicked);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Image = global::TransformationModule.Properties.Resources.exit;
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(187, 26);
            this.exitMenuItem.Text = "Esci";
            this.exitMenuItem.Click += new System.EventHandler(this.ExitBtnClicked);
            // 
            // viewContainer
            // 
            this.viewContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewContainer.ColumnCount = 3;
            this.viewContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.viewContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.viewContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.26911F));
            this.viewContainer.Controls.Add(this.outputContainer, 0, 0);
            this.viewContainer.Controls.Add(this.rulesContainer, 0, 0);
            this.viewContainer.Controls.Add(this.xmlContainer, 0, 0);
            this.viewContainer.Location = new System.Drawing.Point(13, 31);
            this.viewContainer.Name = "viewContainer";
            this.viewContainer.RowCount = 1;
            this.viewContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.viewContainer.Size = new System.Drawing.Size(1554, 608);
            this.viewContainer.TabIndex = 5;
            // 
            // outputContainer
            // 
            this.outputContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputContainer.Location = new System.Drawing.Point(1040, 4);
            this.outputContainer.Margin = new System.Windows.Forms.Padding(4);
            this.outputContainer.Name = "outputContainer";
            this.outputContainer.SelectedIndex = 0;
            this.outputContainer.Size = new System.Drawing.Size(510, 600);
            this.outputContainer.TabIndex = 6;
            // 
            // rulesContainer
            // 
            this.rulesContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rulesContainer.Location = new System.Drawing.Point(522, 4);
            this.rulesContainer.Margin = new System.Windows.Forms.Padding(4);
            this.rulesContainer.Name = "rulesContainer";
            this.rulesContainer.SelectedIndex = 0;
            this.rulesContainer.Size = new System.Drawing.Size(510, 600);
            this.rulesContainer.TabIndex = 5;
            // 
            // xmlContainer
            // 
            this.xmlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xmlContainer.Location = new System.Drawing.Point(4, 4);
            this.xmlContainer.Margin = new System.Windows.Forms.Padding(4);
            this.xmlContainer.Name = "xmlContainer";
            this.xmlContainer.SelectedIndex = 0;
            this.xmlContainer.Size = new System.Drawing.Size(510, 600);
            this.xmlContainer.TabIndex = 4;
            // 
            // btnContainer
            // 
            this.btnContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContainer.ColumnCount = 3;
            this.btnContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.37621F));
            this.btnContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.44051F));
            this.btnContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.24759F));
            this.btnContainer.Controls.Add(this.transformXmlBtn, 0, 0);
            this.btnContainer.Controls.Add(this.loadRulesBtn, 0, 0);
            this.btnContainer.Controls.Add(this.loadXmlbtn, 0, 0);
            this.btnContainer.Location = new System.Drawing.Point(12, 642);
            this.btnContainer.Name = "btnContainer";
            this.btnContainer.RowCount = 1;
            this.btnContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.btnContainer.Size = new System.Drawing.Size(1555, 37);
            this.btnContainer.TabIndex = 6;
            // 
            // transformXmlBtn
            // 
            this.transformXmlBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transformXmlBtn.Location = new System.Drawing.Point(1041, 4);
            this.transformXmlBtn.Margin = new System.Windows.Forms.Padding(4);
            this.transformXmlBtn.Name = "transformXmlBtn";
            this.transformXmlBtn.Size = new System.Drawing.Size(510, 29);
            this.transformXmlBtn.TabIndex = 3;
            this.transformXmlBtn.Tag = "blockable";
            this.transformXmlBtn.Text = "Trasforma XML";
            this.transformXmlBtn.UseVisualStyleBackColor = true;
            this.transformXmlBtn.Click += new System.EventHandler(this.TransformXmlBtnClicked);
            // 
            // loadRulesBtn
            // 
            this.loadRulesBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadRulesBtn.Location = new System.Drawing.Point(522, 4);
            this.loadRulesBtn.Margin = new System.Windows.Forms.Padding(4);
            this.loadRulesBtn.Name = "loadRulesBtn";
            this.loadRulesBtn.Size = new System.Drawing.Size(511, 29);
            this.loadRulesBtn.TabIndex = 2;
            this.loadRulesBtn.Tag = "blockable";
            this.loadRulesBtn.Text = "Carica regole";
            this.loadRulesBtn.UseVisualStyleBackColor = true;
            this.loadRulesBtn.Click += new System.EventHandler(this.LoadRulesBtnClicked);
            // 
            // loadXmlbtn
            // 
            this.loadXmlbtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadXmlbtn.Location = new System.Drawing.Point(4, 4);
            this.loadXmlbtn.Margin = new System.Windows.Forms.Padding(4);
            this.loadXmlbtn.Name = "loadXmlbtn";
            this.loadXmlbtn.Size = new System.Drawing.Size(510, 29);
            this.loadXmlbtn.TabIndex = 1;
            this.loadXmlbtn.Tag = "blockable";
            this.loadXmlbtn.Text = "Carica tracciato XML";
            this.loadXmlbtn.UseVisualStyleBackColor = false;
            this.loadXmlbtn.Click += new System.EventHandler(this.LoadXmlBtnClicked);
            // 
            // TrasformtaionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1579, 683);
            this.Controls.Add(this.btnContainer);
            this.Controls.Add(this.viewContainer);
            this.Controls.Add(this.menu);
            this.Name = "TrasformtaionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modulo di trasformazione";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.viewContainer.ResumeLayout(false);
            this.btnContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.TableLayoutPanel viewContainer;
        private System.Windows.Forms.TabControl xmlContainer;
        private System.Windows.Forms.TabControl rulesContainer;
        private System.Windows.Forms.TabControl outputContainer;
        private System.Windows.Forms.TableLayoutPanel btnContainer;
        private System.Windows.Forms.Button loadXmlbtn;
        private System.Windows.Forms.Button loadRulesBtn;
        private System.Windows.Forms.Button transformXmlBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

