using System.Windows.Forms;
using System.Xml.Linq;
using TransformationModule.Model.Rules;

namespace TransformationModule.Model.Translators
{
    public class ChangeTranslator : Translator
    {
        /// <summary>
        /// Ritorna il codice XSLT di un Command change
        /// </summary>
        /// <param name="command">Command change del quale si vuole ottenere il codice XSLT</param>
        /// <returns>Stringa di codice XSLT</returns>
        public override string GetSpecificTranslation(Command command)
        {
            string typeAttr = command.GetValue("type");
            string nameAttr = command.GetValue("name");
            string inAttr = command.GetValue("in");
            string whereAttr = command.GetValue("where");
            string ifAttr = command.GetValue("if");

            // in predicate viene salvata la traduzione di whereAttr e ifAttr in predicato XPath
            string predicate = "";
            if (ifAttr != null && whereAttr != null)
                predicate = $"[{ifAttr} and {whereAttr}]";
            else if (ifAttr != null || whereAttr != null)
                predicate = $"[{ifAttr}{whereAttr}]";

            if (typeAttr == "attribute")
            {
                string separator = predicate == "" && inAttr.EndsWith("/") ? "" : "/";
                return
                    $"<xsl:template match=\"{inAttr}{predicate}{separator}@{nameAttr}\">" +
                        $"<xsl:attribute name=\"{nameAttr}\">" +
                            command.GetValue() +
                        $"</xsl:attribute>" +
                    $"</xsl:template>";
            }
            else // typeAttr = "element"
            {
                string separator = inAttr.EndsWith("/") ? "" : "/";
                return
                    $"<xsl:template match=\"{inAttr}{separator}{nameAttr}{predicate}\">" +
                        $"<{nameAttr}>" +
                          $"<xsl:apply-templates select=\"@*\"/>" +
                          command.GetValue() +
                        $"</{nameAttr}>" +
                    $"</xsl:template>";
            }
        }
    }
}