using TransformationModule.Model.Rules;

namespace TransformationModule.Model.Translators
{
    public class MoveTranslator : Translator
    {
        /// <summary>
        /// Ritorna il codice XSLT di un Command move
        /// </summary>
        /// <param name="command">Command move del quale si vuole ottenere il codice XSLT</param>
        /// <returns>Stringa di codice XSLT</returns>
        public override string GetSpecificTranslation(Command command)
        {
            string typeAttr = command.GetValue("type");
            string nameAttr = command.GetValue("name");
            string fromAttr = command.GetValue("from");
            string fromWhereAttr = command.GetValue("fromWhere");
            string toAttr = command.GetValue("to");
            string toWhereAttr = command.GetValue("toWhere");
            string beforeAttr = command.GetValue("before");
            string afterAttr = command.GetValue("after");
            string ifAttr = command.GetValue("if");

            // in fromWherePredicate viene salvata la traduzione di formWhereAttr in predicato XPath
            string fromWherePredicate = fromWhereAttr != null ? $"[{fromWhereAttr}]"  : "";

            // in predicate viene salvata la traduzione di formWhereAttr e ifAttr in predicato XPath
            string fromPredicate = "";
            if (ifAttr != null && fromWhereAttr != null)
                fromPredicate = $"[{ifAttr} and {fromWhereAttr}]";
            else if (ifAttr != null || fromWhereAttr != null)
                fromPredicate = $"[{ifAttr}{fromWhereAttr}]";

            // in predicate viene salvata la traduzione di toWhereAttr e ifAttr in predicato XPath
            string toPredicate = "";
            if (ifAttr != null && toWhereAttr != null)
                toPredicate = $"[{ifAttr} and {toWhereAttr}]";
            else if (ifAttr != null || toWhereAttr != null)
                toPredicate = $"[{ifAttr}{toWhereAttr}]";

            if (typeAttr == "attribute")
            {
                string fromWhereSeparator = fromWherePredicate == "" && fromAttr.EndsWith("/") ? "" : "/";
                string fromSeparator = fromPredicate == "" && fromAttr.EndsWith("/") ? "" : "/";
                if (beforeAttr == null && afterAttr == null)
                {
                    return
                        $"<xsl:template match=\"{toAttr}{toPredicate}\">" +
                            $"<xsl:copy>" +
                                $"<xsl:apply-templates select=\"@*\"/>" +
                                $"<xsl:copy-of select=\"{fromAttr}{fromWherePredicate}{fromWhereSeparator}@{nameAttr}\"/>" +
                                $"<xsl:apply-templates select=\"node()\"/>" +
                            $"</xsl:copy>" +
                        $"</xsl:template>" +
                        $"<xsl:template match=\"{fromAttr}{fromPredicate}{fromSeparator}@{nameAttr}\"/>";
                }
                else if (beforeAttr != null)
                {
                    return
                        $"<xsl:template match=\"{toAttr}{toPredicate}\">" +
                            $"<xsl:copy>" +
                                $"<xsl:for-each select=\"@*\">" +
                                    $"<xsl:if test=\"name()={beforeAttr}\">" +
                                        $"<xsl:value-of select=\"{fromAttr}{fromWherePredicate}{fromWhereSeparator}@{nameAttr}\"/>" +
                                    $"</xsl:if>" +
                                    $"<xsl:copy-of select=\".\"/>" +
                                $"</xsl:for-each>" +
                                $"<xsl:apply-templates select=\"node()\"/>" +
                            $"</xsl:copy>" +
                        $"<xsl:template match=\"{fromAttr}{fromPredicate}{fromSeparator}@{nameAttr}\"/>";
                }
                else // afterAttr != null
                {
                    return
                        $"<xsl:template match=\"{toAttr}{toPredicate}\">" +
                            $"<xsl:copy>" +
                                $"<xsl:for-each select=\"@*\">" +
                                    $"<xsl:copy-of select=\".\"/>" +
                                    $"<xsl:if test=\"name()={afterAttr}\">" +
                                        $"<xsl:value-of select=\"{fromAttr}{fromWherePredicate}{fromWhereSeparator}@{nameAttr}\"/>" +
                                    $"</xsl:if>" +
                                $"</xsl:for-each>" +
                                $"<xsl:apply-templates select=\"node()\"/>" +
                            $"</xsl:copy>" +
                        $"<xsl:template match=\"{fromAttr}{fromPredicate}{fromSeparator}@{nameAttr}\"/>";
                }
            }

            else // typeAttr = "element"
            {
                string fromSeparator = fromAttr.EndsWith("/") ? "" : "/";
                if (beforeAttr == null && afterAttr == null)
                {
                    return
                        $"<xsl:template match=\"{toAttr}{toPredicate}\">" +
                            $"<xsl:copy>" +
                                $"<xsl:apply-templates select=\"@*|node()\"/>" +
                                $"<xsl:copy-of select=\"{fromAttr}{fromSeparator}{nameAttr}{fromWherePredicate}\"/>" +
                            $"</xsl:copy>" +
                        $"</xsl:template>" +
                        $"<xsl:template match=\"{fromAttr}{fromSeparator}{nameAttr}{fromPredicate}\"/>";
                }
                else if (beforeAttr != null)
                {
                    string toSeparator = toAttr.EndsWith("/") ? "" : "/";
                    return
                        $"<xsl:template match=\"{toAttr}{toSeparator}{beforeAttr}{toPredicate}\">" +
                            $"<xsl:copy-of select=\"{fromAttr}{fromSeparator}{nameAttr}{fromWherePredicate}\"/>" +
                            $"<xsl:copy-of select= \".\"/>" +
                        $"</xsl:template>" +
                        $"<xsl:template match=\"{fromAttr}{fromSeparator}{nameAttr}{fromPredicate}\"/>";
                }
                else // afterAttr != null
                {
                    string toSeparator = toAttr.EndsWith("/") ? "" : "/";
                    return
                        $"<xsl:template match=\"{toAttr}{toSeparator}{afterAttr}{toPredicate}\">" +
                            $"<xsl:copy-of select= \".\"/>" +
                            $"<xsl:copy-of select=\"{fromAttr}{fromSeparator}{nameAttr}{fromWherePredicate}\"/>" +
                        $"</xsl:template>" +
                        $"<xsl:template match=\"{fromAttr}{fromSeparator}{nameAttr}{fromPredicate}\"/>";
                }
            }
        }
    }
}