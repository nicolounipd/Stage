namespace TransformationModule.Contract
{
    partial class MessageBox
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
            this.closeBtn = new System.Windows.Forms.Button();
            this.detailsBtn = new System.Windows.Forms.Button();
            this.copyBtn = new System.Windows.Forms.Button();
            this.messageTextLabel = new System.Windows.Forms.Label();
            this.detailsTextBox = new System.Windows.Forms.TextBox();
            this.background = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.Location = new System.Drawing.Point(391, 60);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(100, 28);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.Text = "Chiudi";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.CloseBtnClicked);
            // 
            // detailsBtn
            // 
            this.detailsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.detailsBtn.Enabled = false;
            this.detailsBtn.Location = new System.Drawing.Point(16, 60);
            this.detailsBtn.Margin = new System.Windows.Forms.Padding(4);
            this.detailsBtn.Name = "detailsBtn";
            this.detailsBtn.Size = new System.Drawing.Size(100, 28);
            this.detailsBtn.TabIndex = 1;
            this.detailsBtn.Text = "Dettagli";
            this.detailsBtn.UseVisualStyleBackColor = true;
            this.detailsBtn.Click += new System.EventHandler(this.DetailsBtnClicked);
            // 
            // copyBtn
            // 
            this.copyBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.copyBtn.Location = new System.Drawing.Point(124, 60);
            this.copyBtn.Margin = new System.Windows.Forms.Padding(4);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(100, 28);
            this.copyBtn.TabIndex = 4;
            this.copyBtn.Text = "Copia";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Visible = false;
            this.copyBtn.Click += new System.EventHandler(this.CopyBtnClicked);
            // 
            // messageTextLabel
            // 
            this.messageTextLabel.AutoSize = true;
            this.messageTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageTextLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.messageTextLabel.Location = new System.Drawing.Point(16, 11);
            this.messageTextLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.messageTextLabel.MaximumSize = new System.Drawing.Size(413, 0);
            this.messageTextLabel.Name = "messageTextLabel";
            this.messageTextLabel.Size = new System.Drawing.Size(46, 20);
            this.messageTextLabel.TabIndex = 5;
            this.messageTextLabel.Text = "testo";
            // 
            // detailsTextBox
            // 
            this.detailsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailsTextBox.Location = new System.Drawing.Point(16, 98);
            this.detailsTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.detailsTextBox.Multiline = true;
            this.detailsTextBox.Name = "detailsTextBox";
            this.detailsTextBox.ReadOnly = true;
            this.detailsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.detailsTextBox.Size = new System.Drawing.Size(475, 122);
            this.detailsTextBox.TabIndex = 6;
            this.detailsTextBox.Visible = false;
            // 
            // MessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 103);
            this.Controls.Add(this.detailsTextBox);
            this.Controls.Add(this.messageTextLabel);
            this.Controls.Add(this.copyBtn);
            this.Controls.Add(this.detailsBtn);
            this.Controls.Add(this.closeBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button detailsBtn;
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.Label messageTextLabel;
        private System.Windows.Forms.TextBox detailsTextBox;
        private System.ComponentModel.BackgroundWorker background;
    }
}