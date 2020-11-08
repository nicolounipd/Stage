namespace TransformationModule.Contract
{
    internal partial class XmlVisualizer
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
            this.textContainer = new ICSharpCode.TextEditor.TextEditorControl();
            this.SuspendLayout();
            // 
            // textContainer
            // 
            this.textContainer.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textContainer.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textContainer.IsReadOnly = true;
            this.textContainer.Location = new System.Drawing.Point(0, 0);
            this.textContainer.Margin = new System.Windows.Forms.Padding(4);
            this.textContainer.Name = "textContainer";
            this.textContainer.Size = new System.Drawing.Size(656, 342);
            this.textContainer.TabIndex = 1;
            // 
            // XmlVisualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.textContainer);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "XmlVisualizer";
            this.Size = new System.Drawing.Size(656, 342);
            this.ResumeLayout(false);
        }

        #endregion

        private ICSharpCode.TextEditor.TextEditorControl textContainer;
    }
}
