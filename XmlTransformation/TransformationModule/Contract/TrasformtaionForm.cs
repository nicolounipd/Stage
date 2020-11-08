using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using TransformationModule.Model;
using TransformationModule.Model.Validators;

namespace TransformationModule.Contract
{
    public partial class TrasformtaionForm : Form
    {
        XDocument xml;
        XDocument rules;

        /// <summary>
        /// Costruttore della classe TrasformtaionForm
        /// </summary>
        public TrasformtaionForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Salva il nuovo file XML ottenuto dalla trasformazione
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void SaveBtnClicked(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "Output.xml";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog.Filter = @"XML|*.xml";
            saveFileDialog.Title = @"Salva";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.WriteLine(GetOutputContainer().GetText());
                streamWriter.Close();
            }
        }

        /// <summary>
        /// Chiude l'appicazione
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void ExitBtnClicked(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Ritorna l'XmlVisualizer che gestisce il contenitore dell'XML di input
        /// </summary>
        /// <returns>XmlVisualizer che gestisce il contenitore dell'XML di input</returns>
        private XmlVisualizer GetXmlContainer()
        {
            return (XmlVisualizer)xmlContainer.SelectedTab.Controls["body"];
        }

        /// <summary>
        /// Ritorna l'XmlVisualizer che gestisce il contenitore dell'XML delle regole
        /// </summary>
        /// <returns>XmlVisualizer che gestisce il contenitore dell'XML delle regole</returns>
        private XmlVisualizer GetRulesContainer()
        {
            return (XmlVisualizer)rulesContainer.SelectedTab.Controls["body"];
        }

        /// <summary>
        /// Ritorna l'XmlVisualizer che gestisce il contenitore dell'XML di output
        /// </summary>
        /// <returns>XmlVisualizer che gestisce il contenitore dell'XML di output</returns>
        private XmlVisualizer GetOutputContainer()
        {
            return (XmlVisualizer)outputContainer.SelectedTab.Controls["body"];
        }

        /// <summary>
        /// Carica il file XML di input e ne mostra il contenuto se il caricamento va a buon fine
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void LoadXmlBtnClicked(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = @"XML|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog.FileName);
                try
                {
                    xml = XDocument.Load(streamReader);

                    XmlVisualizer body = new XmlVisualizer { Name = "body", Dock = DockStyle.Fill };
                    TabPage newPage = new TabPage();

                    string documentText = openFileDialog.SafeFileName;
                    newPage.Name = documentText;
                    newPage.Text = documentText;
                    newPage.Controls.Add(body);

                    // solo una file aperto alla volta
                    if (xmlContainer.TabPages.Count > 0)
                        xmlContainer.TabPages.RemoveAt(0);
                    xmlContainer.TabPages.Add(newPage);

                    // il metodo ToString() non tiene conto della dichiarazione dell'XML -> se c'è va aggiunta manulamente
                    if (xml.Declaration != null)
                        GetXmlContainer().SetText($"{xml.Declaration}\n{xml}");
                    else
                        GetXmlContainer().SetText(xml.ToString());
                }
                catch (Exception invalidFile)
                {
                    MessageBox errorDialog = new MessageBox("Caricamento fallito", "File XML non valido.", invalidFile.Message);
                    errorDialog.ShowDialog();
                }

                streamReader.Close();
            }
        }

        /// <summary>
        /// Carica il file delle regole e ne mostra il contenuto se il caricamento va a buon fine
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void LoadRulesBtnClicked(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = @"XML|*.xml";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog.FileName);
                try
                {
                    XDocument newRules = XDocument.Load(streamReader);
                    string rulesValidationMessage = RulesValidator.Use().Validate($"{newRules.Declaration}{newRules}");
                    if (rulesValidationMessage == "Regole valide")
                    {
                        rules = newRules;

                        XmlVisualizer body = new XmlVisualizer { Name = "body", Dock = DockStyle.Fill };
                        TabPage newPage = new TabPage();

                        string documentText = openFileDialog.SafeFileName;
                        newPage.Name = documentText;
                        newPage.Text = documentText;
                        newPage.Controls.Add(body);

                        // solo una file aperto alla volta
                        if (rulesContainer.TabPages.Count > 0)
                            rulesContainer.TabPages.RemoveAt(0);
                        rulesContainer.TabPages.Add(newPage);

                        // il metodo ToString() non tiene conto della dichiarazione dell'XML -> se c'è va aggiunta manulamente
                        if (rules.Declaration != null)
                            GetRulesContainer().SetText($"{rules.Declaration}\n{rules}");
                        else
                            GetRulesContainer().SetText(rules.ToString());
                    }
                    else
                        throw new Exception(rulesValidationMessage);
                }
                catch (Exception invalidFile)
                {
                    rules = null;
                    MessageBox errorDialog = new MessageBox(
                        "Caricamento fallito",
                        "File delle regole non valido.",
                        invalidFile.Message
                    );
                    errorDialog.ShowDialog();
                }

                streamReader.Close();
            }
        }

        /// <summary>
        /// Esegue la trasformazione del file XML di input e ne mostra il risultato se va a buon fine
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void TransformXmlBtnClicked(object sender, EventArgs e)
        {
            if (xml == null || rules == null)
            {
                MessageBox errorDialog = new MessageBox(
                    "Trasformazione fallita",
                    "Non ci sono abbastanza informazioni per poter elaborare una trasformazione.",
                    "Per poter avviare la trasformazione è necessario inserire sia il tracciato XML che il file di regole."
                );
                errorDialog.ShowDialog();
                return;
            }

            string xmlString = xml.Declaration != null ? $"{xml.Declaration}\n{xml}" : xml.ToString();
            string rulesString = xml.Declaration != null ? $"{rules.Declaration}\n{rules}" : rules.ToString();
            Transformer xmlTransformer = new Transformer(xmlString, rulesString);
            try
            {
                xmlTransformer.Transfrom();

                XmlVisualizer body = new XmlVisualizer { Name = "body", Dock = DockStyle.Fill };
                TabPage newPage = new TabPage();

                newPage.Name = "Output.xml";
                newPage.Text = "Output.xml";
                newPage.Controls.Add(body);

                // solo una trasformazione aperta alla volta
                if (outputContainer.TabPages.Count > 0)
                    outputContainer.TabPages.RemoveAt(0);
                outputContainer.TabPages.Add(newPage);

                GetOutputContainer().SetText(xmlTransformer.GetOutputXml());

                List<string> unnecessaryRules = xmlTransformer.UnnecessaryRules();
                if (unnecessaryRules.Count > 0)
                {
                    MessageBox errorDialog = null;
                    if (unnecessaryRules.Count == 1)
                        errorDialog = new MessageBox(
                            "Attenzione!",
                            "1 regola non hanno prodotto cambiamenti",
                            unnecessaryRules
                        );
                    else
                        errorDialog = new MessageBox(
                            "Attenzione!",
                            $"{unnecessaryRules.Count} regole non hanno prodotto cambiamenti.",
                            unnecessaryRules
                        );
                    errorDialog.ShowDialog();
                }
            }
            catch (Exception transformationError)
            {
                string error = null;
                if (transformationError.Message.Contains("XSLT"))
                    error = "Le regole fanno riferimento a namespace non presenti nel tracciato XML.";
                else
                    error = transformationError.Message;
                MessageBox errorDialog = new MessageBox(
                    "Trasformazione fallita",
                    "Si è verificato un errore durante la trasformazione.",
                    error
                );
                errorDialog.ShowDialog();
            }
        }
    }
}
