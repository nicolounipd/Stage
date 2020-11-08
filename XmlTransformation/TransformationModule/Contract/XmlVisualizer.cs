using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;

namespace TransformationModule.Contract
{
    internal partial class XmlVisualizer : UserControl
    {
        /// <summary>
        /// Costruttore della classe XmlVisualizer
        /// </summary>
        public XmlVisualizer()
        {
            InitializeComponent();

            textContainer.TabIndent = 3;
            textContainer.Document.HighlightingStrategy = HighlightingManager.Manager.FindHighlighter("XML");
        }

        /// <summary>
        /// Restituisce il testo XML mostrato a video
        /// </summary>
        /// <returns>Stringa che rappresenta il testo XML mostrato a video</returns>
        public string GetText()
        {
            return textContainer.Text;
        }

        /// <summary>
        /// Imposta il testo XML da mostrare a video
        /// </summary>
        /// <param name="text">Testo da mostrare a video</param>
        public void SetText(string text)
        {
            textContainer.Text = text;
            textContainer.Refresh();
        }
    }
}
