using System.Xml.Linq;
using TransformationModule.Model.Rules;

namespace TransformationModule.Model.Translators
{
    public class AddTranslator : Translator
    {
        /// <summary>
        /// Ritorna il codice XSLT di un Command add
        /// </summary>
        /// <param name="command">Command add del quale si vuole ottenere il codice XSLT</param>
        /// <returns>Stringa di codice XSLT</returns>
        public override string GetSpecificTranslation(Command command)
        {
            string typeAttr = command.GetValue("type");
            string nameAttr = command.GetValue("name");
            string inAttr = command.GetValue("in");
            string whereAttr = command.GetValue("where");
            string beforeAttr = command.GetValue("before");
            string afterAttr = command.GetValue("after");
            string ifAttr = command.GetValue("if");

            // in predicate viene salvata la traduzione di whereAttr e ifAttr in predicato XPath
            string predicate = "";
            if (ifAttr != null && whereAttr != null)
                predicate = $"[{ifAttr} and {whereAttr}]";
            else if (ifAttr != null || whereAttr != null)
                predicate = $"[{ifAttr}{whereAttr}]";

            if (typeAttr == "attribute")
            {
                if (beforeAttr == null && afterAttr == null)
                {
                    return
                        $"<xsl:template match=\"{inAttr}{predicate}\">" +
                            $"<xsl:copy>" +
                                $"<xsl:apply-templates select=\"@*\"/>" +
                                    $"<xsl:attribute name=\"{nameAttr}\">" +
                                        command.GetValue() +
                                    $"</xsl:attribute>" +
                                $"<xsl:apply-templates select=\"node()\"/>" +
                            $"</xsl:copy>" +
                        $"</xsl:template>";
                }
                else if (beforeAttr != null)
                {
                    return
                        $"<xsl:template match=\"{inAttr}{predicate}\">" +
                            $"<xsl:copy>" +
                                $"<xsl:for-each select=\"@*\">" +
                                    $"<xsl:if test=\"name()={beforeAttr}\">" +
                                        $"<xsl:attribute name=\"{nameAttr}\">" +
                                            command.GetValue() +
                                        $"</xsl:attribute>" +
                                    $"</xsl:if>" +
                                    $"<xsl:copy-of select=\".\"/>" +
                                $"</xsl:for-each>" +
                                $"<xsl:apply-templates select=\"node()\"/>" +
                            $"</xsl:copy>" +
                        $"</xsl:template>";
                }
                else // afterAttr != null
                {
                    return
                        $"<xsl:template match=\"{inAttr}{predicate}\">" +
                            $"<xsl:copy>" +
                                $"<xsl:for-each select=\"@*\">" +
                                    $"<xsl:copy-of select=\".\"/>" +
                                    $"<xsl:if test=\"name()={afterAttr}\">" +
                                        $"<xsl:attribute name=\"{nameAttr}\">" +
                                            command.GetValue() +
                                        $"</xsl:attribute>" +
                                    $"</xsl:if>" +
                                $"</xsl:for-each>" +
                                $"<xsl:apply-templates select=\"node()\"/>" +
                            $"</xsl:copy>" +
                        $"</xsl:template>";
                }
            }
            else // typeAttr = "element"
            {
                if (beforeAttr == null && afterAttr == null)
                {
                    return
                        $"<xsl:template match=\"{inAttr}{predicate}\">" +
                            $"<xsl:copy>" +
                                $"<xsl:apply-templates select=\"@*|node()\"/>" +
                                $"<{nameAttr}>" +
                                    command.GetValue() +
                                $"</{nameAttr}>" +
                            $"</xsl:copy>" +
                        $"</xsl:template>";
                }
                else if (beforeAttr != null)
                {
                    string separator = predicate == "" && inAttr.EndsWith("/") ? "" : "/";
                    return
                        $"<xsl:template match=\"{inAttr}{predicate}{separator}{beforeAttr}\">" +
                            $"<{nameAttr}>" +
                                command.GetValue() +
                            $"</{nameAttr}>" +
                            $"<xsl:copy-of select= \".\"/>" +
                        $"</xsl:template>";
                }
                else // afterAttr != null
                {
                    string separator = predicate == "" && inAttr.EndsWith("/") ? "" : "/";
                    return
                        $"<xsl:template match=\"{inAttr}{predicate}{separator}{afterAttr}\">" +
                            $"<xsl:copy-of select= \".\"/>" +
                            $"<{nameAttr}>" +
                                command.GetValue() +
                            $"</{nameAttr}>" +
                        $"</xsl:template>";
                }
            }
        }
    }
}
