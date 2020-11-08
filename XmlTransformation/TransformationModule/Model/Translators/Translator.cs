using TransformationModule.Model.Rules;

namespace TransformationModule.Model.Translators
{
    public abstract class Translator
    {
        private static string baseNamespace = $"xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\"";
        private static string namespaceList;

        /// <summary>
        /// Inizializza la lista dei namespace
        /// </summary>
        public static void Init()
        {
            namespaceList = baseNamespace;
        }

        /// <summary>
        /// Aggiunge un namespace alla lista dei namespace
        /// </summary>
        /// <param name="namespaceString">Stringa del namespace da aggiungere</param>
        public static void AddNamespace(string namespaceString)
        {
            namespaceList += $" {namespaceString}";
        }

        /// <summary>
        /// Ritorna il codice XSLT per ottenere la trasformazione identità
        /// </summary>
        public static string IdentityTransform()
        {
            return
                $"<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                $"<xsl:transform version=\"1.0\" {namespaceList}>" +
                    $"<xsl:output indent=\"yes\"/>" +
                    $"<xsl:strip-space elements=\"*\"/>" +
                    $"<xsl:template match=\"@*|node()\">" +
                        $"<xsl:copy>" +
                            $"<xsl:apply-templates select=\"@*|node()\"/>" +
                        $"</xsl:copy>" +
                    $"</xsl:template>" +
                $"</xsl:transform>";
        }

        /// <summary>
        /// Ritorna il codice XSLT relativo che applica un Command
        /// </summary>
        /// <param name="command">Command da tradurre</param>
        /// <returns>Stringa di codice XSLT</returns>
        public string Translate(Command command)
        {
            return
                $"<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                $"<xsl:transform version=\"1.0\" {namespaceList}>" +
                    $"<xsl:output indent=\"yes\"/>" +
                    $"<xsl:strip-space elements=\"*\"/>" +
                    GetIdentityTranslation() +
                    GetSpecificTranslation(command) +
                $"</xsl:transform>";
        }

        /// <summary>
        /// Ritorna il codice XSLT che copia il contenuto dell' XML originale
        /// </summary>
        /// <returns>Stringa di codice XSLT</returns>
        private string GetIdentityTranslation()
        {
            return
                "<xsl:template match=\"@*|node()\">" +
                    "<xsl:copy>" +
                        "<xsl:apply-templates select=\"@*|node()\"/>" +
                    "</xsl:copy>" +
                "</xsl:template>";
        }

        /// <summary>
        /// Ritorna il codice XSLT di un Command
        /// </summary>
        /// <param name="command">Command del quale si vuole ottenere il codice XSLT</param>
        /// <returns>Stringa di codice XSLT</returns>
        public abstract string GetSpecificTranslation(Command command);
    }
}
