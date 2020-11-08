using RulesEditor.Model.Rules;
using System;
using System.Windows.Forms;

namespace RulesEditor
{
    public partial class RuleCreatorForm : Form
    {
        /// <returns>Stringa che rappresenta la regola creata</returns>
        public string XmlRuleStr { get; private set; }

        /// <summary>
        /// Costruttore della classe RuleCreatorForm
        /// </summary>
        public RuleCreatorForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Attiva i campi compilabili per la tipologia di regola selezionata
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void RuleActionChanged(object sender, EventArgs e)
        {
            actionTextBox.Text = actionComboBox.Text;

            switch (actionComboBox.Text) {
                case "add":
                    typeComboBox.Enabled = true;
                    nameTextBox.ReadOnly = false;
                    fromTextBox.ReadOnly = true;
                    fromWhereTextBox.ReadOnly = true;
                    inTextBox.ReadOnly = false;
                    whereTextBox.ReadOnly = false;
                    toTextBox.ReadOnly = true;
                    toWhereTextBox.ReadOnly = true;
                    beforeTextBox.ReadOnly = false;
                    afterTextBox.ReadOnly = false;
                    ifTextBox.ReadOnly = false;
                    currentTextBox.ReadOnly = true;
                    valueTextBox.ReadOnly = false;

                    nameNeededLabel.Visible = true;
                    fromNeededLabel.Visible = false;
                    inNeededLabel.Visible = true;
                    toNeededLabel.Visible = false;
                    currentNeededLabel.Visible = false;
                    valueNeededLabel.Visible = false;
                    break;

                case "change":
                    typeComboBox.Enabled = true;
                    nameTextBox.ReadOnly = false;
                    fromTextBox.ReadOnly = true;
                    fromWhereTextBox.ReadOnly = true;
                    inTextBox.ReadOnly = false;
                    whereTextBox.ReadOnly = false;
                    toTextBox.ReadOnly = true;
                    toWhereTextBox.ReadOnly = true;
                    beforeTextBox.ReadOnly = true;
                    afterTextBox.ReadOnly = true;
                    ifTextBox.ReadOnly = false;
                    currentTextBox.ReadOnly = true;
                    valueTextBox.ReadOnly = false;

                    nameNeededLabel.Visible = true;
                    fromNeededLabel.Visible = false;
                    inNeededLabel.Visible = true;
                    toNeededLabel.Visible = false;
                    currentNeededLabel.Visible = false;
                    valueNeededLabel.Visible = true;
                    break;

                case "copy":
                    typeComboBox.Enabled = true;
                    nameTextBox.ReadOnly = false;
                    fromTextBox.ReadOnly = false;
                    fromWhereTextBox.ReadOnly = false;
                    inTextBox.ReadOnly = true;
                    whereTextBox.ReadOnly = true;
                    toTextBox.ReadOnly = false;
                    toWhereTextBox.ReadOnly = false;
                    beforeTextBox.ReadOnly = false;
                    afterTextBox.ReadOnly = false;
                    ifTextBox.ReadOnly = false;
                    currentTextBox.ReadOnly = true;
                    valueTextBox.ReadOnly = true;

                    nameNeededLabel.Visible = true;
                    fromNeededLabel.Visible = true;
                    inNeededLabel.Visible = false;
                    toNeededLabel.Visible = true;
                    currentNeededLabel.Visible = false;
                    valueNeededLabel.Visible = false;
                    break;

                case "delete":
                    typeComboBox.Enabled = true;
                    nameTextBox.ReadOnly = false;
                    fromTextBox.ReadOnly = true;
                    fromWhereTextBox.ReadOnly = true;
                    inTextBox.ReadOnly = false;
                    whereTextBox.ReadOnly = false;
                    toTextBox.ReadOnly = true;
                    toWhereTextBox.ReadOnly = true;
                    beforeTextBox.ReadOnly = true;
                    afterTextBox.ReadOnly = true;
                    ifTextBox.ReadOnly = false;
                    currentTextBox.ReadOnly = true;
                    valueTextBox.ReadOnly = true;

                    nameNeededLabel.Visible = true;
                    fromNeededLabel.Visible = false;
                    inNeededLabel.Visible = true;
                    toNeededLabel.Visible = false;
                    currentNeededLabel.Visible = false;
                    valueNeededLabel.Visible = false;
                    break;

                case "move":
                    typeComboBox.Enabled = true;
                    nameTextBox.ReadOnly = false;
                    fromTextBox.ReadOnly = false;
                    fromWhereTextBox.ReadOnly = false;
                    inTextBox.ReadOnly = true;
                    whereTextBox.ReadOnly = true;
                    toTextBox.ReadOnly = false;
                    toWhereTextBox.ReadOnly = false;
                    beforeTextBox.ReadOnly = false;
                    afterTextBox.ReadOnly = false;
                    ifTextBox.ReadOnly = false;
                    currentTextBox.ReadOnly = true;
                    valueTextBox.ReadOnly = true;

                    nameNeededLabel.Visible = true;
                    fromNeededLabel.Visible = true;
                    inNeededLabel.Visible = false;
                    toNeededLabel.Visible = true;
                    currentNeededLabel.Visible = false;
                    valueNeededLabel.Visible = false;
                    break;

                case "rename":
                    typeComboBox.Enabled = true;
                    nameTextBox.ReadOnly = false;
                    fromTextBox.ReadOnly = true;
                    fromWhereTextBox.ReadOnly = true;
                    inTextBox.ReadOnly = false;
                    whereTextBox.ReadOnly = false;
                    toTextBox.ReadOnly = true;
                    toWhereTextBox.ReadOnly = true;
                    beforeTextBox.ReadOnly = true;
                    afterTextBox.ReadOnly = true;
                    ifTextBox.ReadOnly = false;
                    currentTextBox.ReadOnly = true;
                    valueTextBox.ReadOnly = false;

                    nameNeededLabel.Visible = true;
                    fromNeededLabel.Visible = false;
                    inNeededLabel.Visible = true;
                    toNeededLabel.Visible = false;
                    currentNeededLabel.Visible = true;
                    valueNeededLabel.Visible = true;
                    break;

                case "path":
                    typeComboBox.Enabled = false;
                    nameTextBox.ReadOnly = true;
                    fromTextBox.ReadOnly = true;
                    fromWhereTextBox.ReadOnly = true;
                    inTextBox.ReadOnly = true;
                    whereTextBox.ReadOnly = true;
                    toTextBox.ReadOnly = true;
                    toWhereTextBox.ReadOnly = true;
                    beforeTextBox.ReadOnly = true;
                    afterTextBox.ReadOnly = true;
                    ifTextBox.ReadOnly = true;
                    currentTextBox.ReadOnly = false;
                    valueTextBox.ReadOnly = true;

                    nameNeededLabel.Visible = false;
                    fromNeededLabel.Visible = false;
                    inNeededLabel.Visible = false;
                    toNeededLabel.Visible = false;
                    currentNeededLabel.Visible = true;
                    valueNeededLabel.Visible = false;
                    break;

                default:
                    typeComboBox.Enabled = false;
                    nameTextBox.ReadOnly = true;
                    fromTextBox.ReadOnly = true;
                    fromWhereTextBox.ReadOnly = true;
                    inTextBox.ReadOnly = true;
                    whereTextBox.ReadOnly = true;
                    toTextBox.ReadOnly = true;
                    toWhereTextBox.ReadOnly = true;
                    beforeTextBox.ReadOnly = true;
                    afterTextBox.ReadOnly = true;
                    ifTextBox.ReadOnly = true;
                    currentNeededLabel.Visible = true;
                    valueTextBox.ReadOnly = true;

                    nameNeededLabel.Visible = false;
                    fromNeededLabel.Visible = false;
                    inNeededLabel.Visible = false;
                    toNeededLabel.Visible = false;
                    currentNeededLabel.Visible = false;
                    valueNeededLabel.Visible = false;
                    break;
            }
        }

        /// <summary>
        /// Attiva le action disponibili per le operazioni su namespace
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void RuleTypeChanged(object sender, EventArgs e)
        {
            if (typeComboBox.Text == "namespace")
            {
                if (actionComboBox.Text == "copy")
                    actionComboBox.Text = "";
                actionComboBox.Items.Remove("copy");
                actionTextBox.Text = actionComboBox.Text;
            }    
            else if (!actionComboBox.Items.Contains("copy"))
                actionComboBox.Items.Insert(2, "copy");
        }

        /// <summary>
        /// Crea la nuova regola e chiude la finestra se la creazione va a buon fine
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void OkBtnClicked(object sender, EventArgs e)
        {
            RuleElement rule = null;

            if (actionComboBox.Text == "path")
                rule = new PathElement($"<path current=\"{currentTextBox.Text}\"/>");
            else
            {
                rule = new CommandBuilder()
                    .SetName(actionComboBox.Text)
                    .SetAttribute("type", !typeComboBox.Enabled ? null : typeComboBox.Text)
                    .SetAttribute("name", nameTextBox.ReadOnly ? null : nameTextBox.Text)
                    .SetAttribute("from", fromTextBox.ReadOnly ? null : fromTextBox.Text)
                    .SetAttribute("fromWhere", fromWhereTextBox.ReadOnly ? null : fromWhereTextBox.Text)
                    .SetAttribute("in", inTextBox.ReadOnly ? null : inTextBox.Text)
                    .SetAttribute("where", whereTextBox.ReadOnly ? null : whereTextBox.Text)
                    .SetAttribute("to", toTextBox.ReadOnly ? null : toTextBox.Text)
                    .SetAttribute("toWhere", toWhereTextBox.ReadOnly ? null : toWhereTextBox.Text)
                    .SetAttribute("before", beforeTextBox.ReadOnly ? null : beforeTextBox.Text)
                    .SetAttribute("after", afterTextBox.ReadOnly ? null : afterTextBox.Text)
                    .SetAttribute("if", ifTextBox.ReadOnly ? null : ifTextBox.Text)
                    .SetValue(valueTextBox.ReadOnly ? null : valueTextBox.Text)
                    .Build();
            }

            XmlRuleStr = rule.ToString();
            if (XmlRuleStr != null)
            {
                errorLabel.Visible = false;
                Close();
            }
            else
                errorLabel.Visible = true;
        }
    }
}
