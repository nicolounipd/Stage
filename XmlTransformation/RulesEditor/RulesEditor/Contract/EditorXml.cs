using RulesEditor.Model.Validators;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RulesEditor
{
    public partial class EditorXml : Form
    {
        private int tabCount;

        /// <summary>
        /// Costruttore della classe EditorXml
        /// </summary>
        public EditorXml()
        {
            InitializeComponent();
            tabCount = 0;
        }

        /// <summary>
        /// Ritorna l'EditorUserControl necessario per la gestione dell'XML
        /// </summary>
        /// <returns>Istanza della classe EditorUserControl necessario per la gestione dell'XML</returns>
        private EditorUserControl GetXmlEditor()
        {
            return (EditorUserControl)editorTabControl.SelectedTab.Controls["body"];
        }

        /// <summary>
        /// Aggiunge una nuova scheda vuota
        /// </summary>
        private void AddTab()
        {
            var body = new EditorUserControl { Name = "body", Dock = DockStyle.Fill };

            body.SetText("");
            var newPage = new TabPage();
            tabCount += 1;

            string documentText = $"File {tabCount}";
            newPage.Name = documentText;
            newPage.Text = documentText;
            newPage.Controls.Add(body);

            editorTabControl.TabPages.Add(newPage);
        }

        /// <summary>
        /// Aggiunge una nuova scheda vuota
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void ApplicationStarted(object sender, EventArgs e)
        {
            AddTab();
        }

        /// <summary>
        /// Aggiunge una nuova scheda vuota
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void NewBtnClicked(object sender, EventArgs e)
        {
            AddTab();
            editorTabControl.SelectedIndex += 1;
        }

        /// <summary>
        /// Permette di aprire un file XML nella scheda in rilievo
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void OpenBtnClicked(object sender, EventArgs e) {
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = @"XML|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AddTab();
                editorTabControl.SelectedIndex += 1;
                editorTabControl.SelectedTab.Text = openFileDialog.SafeFileName;

                StreamReader streamReader = new StreamReader(openFileDialog.FileName);
                GetXmlEditor().SetText(streamReader.ReadToEnd());
                streamReader.Close();
            }
        }

        /// <summary>
        /// Rimuove la scheda in rilievo
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void RemoveBtnClicked(object sender, EventArgs e)
        {
            if (editorTabControl.TabPages.Count > 1)
                editorTabControl.TabPages.Remove(editorTabControl.SelectedTab);
            else if (editorTabControl.TabPages.Count == 1)
            {
                AddTab();
                editorTabControl.TabPages.Remove(editorTabControl.SelectedTab);
            }
        }

        /// <summary>
        /// Permette di salvare il contenuto della scheda aperta in rilievo
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void SaveBtnClicked(object sender, EventArgs e) {
            if (openFileDialog.FileName == "")
                SaveAsBtnClicked(sender, e);
            else
            {
                StreamWriter streamWriter = new StreamWriter(openFileDialog.FileName, false, Encoding.UTF8);
                streamWriter.WriteLine(GetXmlEditor().GetText());
                streamWriter.Close();
            }
        }

        /// <summary>
        /// Permette di salvare con nome il contenuto della scheda aperta in rilievo
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void SaveAsBtnClicked(object sender, EventArgs e) {
            saveFileDialog.FileName = editorTabControl.SelectedTab.Name;
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog.Filter = @"XML|*.xml";
            saveFileDialog.Title = @"Save As";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.WriteLine(GetXmlEditor().GetText());
                streamWriter.Close();
            }
        }

        /// <summary>
        /// Chiude l'applicazione
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void ExitBtnClicked(object sender, EventArgs e) {
            Application.Exit();
        }

        /// <summary>
        /// Compila il contenuto della scheda in rilevo e ne stampa l'esito
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void BuildBtnClicked(object sender, EventArgs e) {
            compilerTextBox.Text = "\r\n    " + RulesValidator.Use().Validate(GetXmlEditor().GetText());
        }

        /// <summary>
        /// Rimuove la stampa dell'esito della compilazione
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void ClearConsoleBtnClicked(object sender, EventArgs e)
        {
            compilerTextBox.Text = "";
        }
    }
}
