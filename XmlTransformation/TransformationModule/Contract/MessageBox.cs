using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TransformationModule.Contract
{
    public partial class MessageBox : Form
    {
        private const string DetailsFormat = "Dettagli {0}";

        /// <returns>Stringa "Dettagli ▴"</returns>
        private string UpArrow
        {
            get
            {
                return string.Format(DetailsFormat, char.ConvertFromUtf32(0x25B4));
            }
        }

        /// <returns>Stringa "Dettagli ▾"</returns>
        private string DownArrow
        {
            get
            {
                return string.Format(DetailsFormat, char.ConvertFromUtf32(0x25BE));
            }
        }

        /// <summary>
        /// Costruttore della classe MessageBox
        /// </summary>
        /// <param name="title">Titolo della finestra</param>
        /// <param name="message">Contenuto principale della finstra</param>
        /// <param name="details">Approfondimento del contenuto principale</param>
        public MessageBox(string title, string message, string details = null)
        {
            InitializeComponent();

            messageTextLabel.Text = message;
            this.Text = title;

            if (details != null)
            {
                detailsBtn.Enabled = true;
                detailsBtn.Text = DownArrow;
                detailsTextBox.Text = details;
            }
        }

        /// <summary>
        /// Costruttore della classe MessageBox
        /// </summary>
        /// <param name="title">Titolo della finestra</param>
        /// <param name="message">Contenuto principale della finstra</param>
        /// <param name="details">Approfondimento del contenuto principale suddiviso in più punti</param>
        public MessageBox(string title, string message, List<string> details)
        {
            InitializeComponent();

            messageTextLabel.Text = message;
            this.Text = title;

            detailsBtn.Enabled = true;
            detailsBtn.Text = DownArrow;

            detailsTextBox.Text = details[0];
            details.RemoveAt(0);
            foreach (string commandString in details)
                detailsTextBox.Text += $"\r\n\r\n{commandString}";
        }
        
        /// <summary>
        /// Imposta l'altezza del MessageBox
        /// </summary>
        /// <param name="heightChange">Altezza da impostare in pixel</param>
        private void SetMessageBoxHeight(int heightChange)
        {
            this.Height += heightChange;
            if (this.Height < 150)
                this.Height = 150;
        }

        /// <summary>
        /// Chiude il MessageBox
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void CloseBtnClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Apre o chiude la text box dei dettagli a seconda dello stato in cui si trova
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void DetailsBtnClicked(object sender, EventArgs e)
        {
            // per evidare lo spostamento delle componenti dopo l'apertura o la chiusura della text box dei dettagli
            copyBtn.Anchor = AnchorStyles.Top;
            closeBtn.Anchor = AnchorStyles.Top;
            detailsBtn.Anchor = AnchorStyles.Top;
            detailsTextBox.Anchor = AnchorStyles.Top;

            detailsTextBox.Visible = !detailsTextBox.Visible;
            copyBtn.Visible = !copyBtn.Visible;

            detailsBtn.Text = detailsTextBox.Visible ? UpArrow : DownArrow;

            SetMessageBoxHeight(detailsTextBox.Visible ? detailsTextBox.Height + 10 : -detailsTextBox.Height - 10);
        }

        /// <summary>
        /// Copia il contenuto della text box dei dettagli
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void CopyBtnClicked(object sender, EventArgs e)
        {
            Clipboard.SetText(detailsTextBox.Text);
        }
    }
}