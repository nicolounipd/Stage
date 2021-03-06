﻿using TransformationModule.Model.Rules;

namespace TransformationModule.Model.Translators
{
    public class RenameTranslator : Translator
    {
        /// <summary>
        /// Ritorna il codice XSLT di un Command rename
        /// </summary>
        /// <param name="command">Command rename del quale si vuole ottenere il codice XSLT</param>
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
                    $"<xsl:template match=\"{inAttr}{predicate}/@{nameAttr}\">" +
                        $"<xsl:attribute name=\"{command.GetValue()}\">" +
                             $"<xsl:value-of select=\".\"/>" +
                        $"</xsl:attribute>" +
                    $"</xsl:template>";
            }
            else // typeAttr = "element"
            {
                string separator = inAttr.EndsWith("/") ? "" : "/";
                return
                    $"<xsl:template match=\"{inAttr}/{nameAttr}{predicate}\">" +
                        $"<{command.GetValue()}>" +
                            $"<xsl:apply-templates select=\"@*|node()\"/>" +
                        $"</{command.GetValue()}>" +
                    $"</xsl:template>";
            }
        }
    }
}