using System;
using System.Windows.Forms;
using System.Xml.Linq;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using RulesEditor.Model.Rules;

namespace RulesEditor {
    internal partial class EditorUserControl : UserControl
    {
        public delegate void CaretChangeEventHandler(int line, int column);
        public event CaretChangeEventHandler caretChangeEvent;
        private bool isTextChanged;

        /// <summary>
        /// Costruttore della classe EditorUserControl
        /// </summary>
        public EditorUserControl()
        {
            InitializeComponent();

            textEditorControl.TabIndent = 3;
            textEditorControl.Document.HighlightingStrategy = HighlightingManager.Manager.FindHighlighter("XML");
            textEditorControl.ActiveTextAreaControl.Caret.PositionChanged += CaretPositionChanged;
            textEditorControl.Document.DocumentChanged += DocumentChanged;
        }

        /// <summary>
        /// Imposta la posizione del cursore
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void CaretPositionChanged(object sender, EventArgs e)
        {
            int line = textEditorControl.ActiveTextAreaControl.Caret.Line + 1;
            int column = textEditorControl.ActiveTextAreaControl.Caret.Column + 1;

            caretChangeEvent?.Invoke(line, column);
        }

        /// <summary>
        /// Rileva se sono state apportate modifiche al testo stampato a video
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void DocumentChanged(object sender, DocumentEventArgs e)
        {
            isTextChanged = true;
        }

        /// <summary>
        /// Ritorna il testo stampato a video
        /// </summary>
        /// <returns>Stringa che rappresenta l'XML</returns>
        public string GetText()
        {
            return textEditorControl.Text;
        }

        /// <summary>
        /// Imposta il contenuto da stampare a video
        /// </summary>
        /// <param name="text">Stringa di testo da stampare a video</param>
        public void SetText(string text)
        {
            bool modified = isTextChanged;
            textEditorControl.Text = text;
            textEditorControl.Refresh();
            isTextChanged = modified;
        }


        /// <summary>
        /// Ritorna la riga in cui è posizionato il cursore
        /// </summary>
        /// <returns>Intero che rappresenta la riga in cui è posizionato il cursore</returns>
        public int GetActiveLineNumber()
        {
            return textEditorControl.ActiveTextAreaControl.Caret.Line;
        }

        /// <summary>
        /// Porta il cursore in un preciso punto
        /// </summary>
        /// <param name="line">Riga sulla quale posizionare il cursore</param>
        /// <param name="column">Colonna sulla quale posizionare il cursore</param>
        public void GotoLine(int line, int column)
        {
            textEditorControl.ActiveTextAreaControl.Caret.Line = line;
            textEditorControl.ActiveTextAreaControl.Caret.Column = column;
            textEditorControl.ActiveTextAreaControl.CenterViewOn(line, 0);
            textEditorControl.Focus();
        }

        /// <summary>
        /// Verifica se la riga in cui è posizionato il cursore è vuota
        /// </summary>
        /// <returns>True se la riga in cui è posizionato il cursore è vuota, false altrimenti</returns>
        private bool IsActiveLineEmpty()
        {
            string lineText = GetActiveLineText();
            int i = 0;
            for (; i < lineText.Length && (lineText[i] == ' ' || lineText[i] == '\t'); i++);
            return i == lineText.Length;
        }

        /// <summary>
        /// Ritorna il contenuto della riga in cui è posizionato il cursore
        /// </summary>
        /// <returns>Stringa che rappresenta il testo contenuto nella riga in cui è posizionato il cursore</returns>
        private string GetActiveLineText()
        {
            LineSegment lineSegment = textEditorControl.Document.GetLineSegment(GetActiveLineNumber());
            return textEditorControl.Document.GetText(lineSegment);
        }

        /// <summary>
        /// Ritorna la regola presente nella riga in cui è posizionato il cursore
        /// </summary>
        /// <returns>RulesElement contenente la regola presente nella riga in cui è posizionato il cursore</returns>
        private RuleElement GetActiveLineRule()
        {
            if (IsActiveLineEmpty())
                return null;
            XElement element = XElement.Parse(GetActiveLineText());
            if (element.Name == "path")
                return new PathElement(element);
            if (element.Name == "repeat")
                return new RepeatElement(element);
            return new Command(element);
        }

        /// <summary>
        /// Sostituisce il testo della riga in cui è posizionato il cursore con un altro
        /// </summary>
        /// <param name="newLineText">Nuovo testo da inserire</param>
        private void ReplaceActiveLineText(string newLineText)
        {
            LineSegment lineSegment = textEditorControl.Document.GetLineSegment(GetActiveLineNumber());
            string lineText = textEditorControl.Document.GetText(lineSegment);
            string spaceBeforeText = "";
            for (int i = 0; i < lineText.Length && (lineText[i] == ' ' || lineText[i] == '\t'); i++)
                spaceBeforeText += lineText[i];
            textEditorControl.Document.Replace(lineSegment.Offset, lineText.Length, spaceBeforeText + newLineText);
            GotoLine(GetActiveLineNumber(), spaceBeforeText.Length + lineText.Length);
        }

        /// <summary>
        /// Ripete l'ultima azione
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void RedoBtnClicked(object sender, EventArgs e)
        {
            textEditorControl.Redo();
        }
        /// <summary>
        /// Annulla l'ultima azione
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void UndoBtnClicked(object sender, EventArgs e)
        {
            textEditorControl.Undo();
        }


        /// <summary>
        /// Mostra le voci del menu a tendina attivando quelle disponibili
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void ContextMenuOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textEditorControl.Document.UndoStack.CanUndo)
                undoContextMenuItem.Enabled = true;
            else
                undoContextMenuItem.Enabled = false;

            if (textEditorControl.Document.UndoStack.CanRedo)
                redoContextMenuItem.Enabled = true;
            else
                redoContextMenuItem.Enabled = false;

            if (IsActiveLineEmpty())
            {
                addRepeatContextMenuItem.Enabled = true;
                addRuleContextMenuItem.Enabled = true;
            }
            else
            {
                addRepeatContextMenuItem.Enabled = false;
                addRuleContextMenuItem.Enabled = false;
            }

            try
            {
                RuleElement rule = GetActiveLineRule();
                if (rule != null && rule.ToString() != null && !(rule is RepeatElement))
                {
                    updateRuleContextMenuItem.Enabled = true;
                    deleteRuleContextMenuItem.Enabled = true;
                }
                else
                {
                    updateRuleContextMenuItem.Enabled = false;
                    deleteRuleContextMenuItem.Enabled = false;
                }
            }
            catch
            {
                updateRuleContextMenuItem.Enabled = false;
                deleteRuleContextMenuItem.Enabled = false;
            }
        }


        /// <summary>
        /// Taglia l'elemento selezionato
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void CutBtnClicked(object sender, EventArgs e)
        {
            textEditorControl.ActiveTextAreaControl.TextArea.ClipboardHandler.Cut(sender, e);
        }

        /// <summary>
        /// Copia l'elemento selezionato
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void CopyBtnClicked(object sender, EventArgs e)
        {
            textEditorControl.ActiveTextAreaControl.TextArea.ClipboardHandler.Copy(sender, e);
        }


        /// <summary>
        /// Incolla l'elemento copiato nella posizione in cui si trova il cursore
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void PasteBtnClicked(object sender, EventArgs e)
        {
            textEditorControl.ActiveTextAreaControl.TextArea.ClipboardHandler.Paste(sender, e);
        }

        /// <summary>
        /// Elimina l'elemento selezionato
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void DeleteBtnClicked(object sender, EventArgs e)
        {
            textEditorControl.ActiveTextAreaControl.TextArea.ClipboardHandler.Delete(sender, e);
        }

        /// <summary>
        /// Seleziona tutto il contenuto stampato a video
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void SelectAllBtnClicked(object sender, EventArgs e)
        {
            TextLocation startPosition = new TextLocation(0, 0);

            int textLength = textEditorControl.ActiveTextAreaControl.Document.TextLength;
            TextLocation endPosition = new TextLocation();
            endPosition.Column = textEditorControl.Document.OffsetToPosition(textLength).Column;
            endPosition.Line = textEditorControl.Document.OffsetToPosition(textLength).Line;

            textEditorControl.ActiveTextAreaControl.SelectionManager.SetSelection(startPosition, endPosition);
            textEditorControl.ActiveTextAreaControl.Caret.Position = endPosition;
        }

        /// <summary>
        /// Aggiunge un template dell'elemento repeat nella posizione in cui si trova il cursore
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void AddRepeatBtnClicked(object sender, EventArgs e)
        {
            ReplaceActiveLineText("<repeat times=\"\">\n");
            string spaceBeforeText = GetActiveLineText().Substring(0, GetActiveLineText().IndexOf('<'));

            // l'elemento repeat viene creato rispettando la formattazione e il cursore viene posizionato sull'attributo times
            GotoLine(GetActiveLineNumber() + 1, 0);
            ReplaceActiveLineText($"{spaceBeforeText}\t\n");
            GotoLine(GetActiveLineNumber() + 1, 0);
            ReplaceActiveLineText($"{spaceBeforeText}</rules>");
            GotoLine(GetActiveLineNumber() - 2, 0);
            GotoLine(GetActiveLineNumber(), GetActiveLineText().IndexOf('"') + 1);
        }

        /// <summary>
        /// Aggiunge la regola nella posizione in cui si trova il cursore
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void AddRuleBtnClicked(object sender, EventArgs e)
        {
            var addRuleDialog = new RuleCreatorForm();
            addRuleDialog.ShowDialog();
            if (addRuleDialog.XmlRuleStr != null)
            {
                textEditorControl.ActiveTextAreaControl.TextArea.InsertString(addRuleDialog.XmlRuleStr);
            }
        }

        /// <summary>
        /// Aggiorna la regola sottostante il cursore
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void UpdateRuleBtnClicked(object sender, EventArgs e)
        {
            RuleCreatorForm addRuleDialog = new RuleCreatorForm();
            RuleElement rule = GetActiveLineRule();

            addRuleDialog.actionComboBox.Text = rule.GetName();
            addRuleDialog.typeComboBox.Text = rule.GetValue("type");
            addRuleDialog.nameTextBox.Text = rule.GetValue("name");
            addRuleDialog.fromTextBox.Text = rule.GetValue("from");
            addRuleDialog.fromWhereTextBox.Text = rule.GetValue("fromWhere");
            addRuleDialog.inTextBox.Text = rule.GetValue("in");
            addRuleDialog.whereTextBox.Text = rule.GetValue("where");
            addRuleDialog.toTextBox.Text = rule.GetValue("to");
            addRuleDialog.toWhereTextBox.Text = rule.GetValue("toWhere");
            addRuleDialog.beforeTextBox.Text = rule.GetValue("before");
            addRuleDialog.afterTextBox.Text = rule.GetValue("after");
            addRuleDialog.ifTextBox.Text = rule.GetValue("if");
            addRuleDialog.currentTextBox.Text = rule.GetValue("current");
            addRuleDialog.valueTextBox.Text = rule.GetValue();

            addRuleDialog.ShowDialog();

            if (addRuleDialog.XmlRuleStr != null) {
                ReplaceActiveLineText(addRuleDialog.XmlRuleStr);
            }
        }

        /// <summary>
        /// Rimouve la regola sottostante il cursore
        /// </summary>
        /// <param name="sender">Riferimento all'oggetto che ha generato l'evento</param>
        /// <param name="e">Istanza che contiene i dati dell'evento</param>
        private void DeleteRuleBtnClicked(object sender, EventArgs e) {
            ReplaceActiveLineText("");
        }
    }
}
