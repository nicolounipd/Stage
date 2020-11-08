using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace TransformationModule.Model.Validators
{
    public class RulesValidator : XmlValidator
    {
        private static readonly RulesValidator validator = new RulesValidator();
        private static XmlSchemaSet xsdSchema;

        /// <summary>
        /// Costruttore della classe RulesValidator
        /// </summary>
        protected RulesValidator() { }

        /// <summary>
        /// Permette di ottenere un'istanza della classe RulesValidator
        /// </summary>
        /// <returns>Istanza della classe RulesValidator</returns>"
        public new static RulesValidator Use()
        {
            return validator;
        }

        /// <summary>
        /// Valida il contenuto di una stringa secondo la sintassi delle regole
        /// </summary>
        /// <param name="rulesText">Stringa XML da validatre</param>
        /// <returns>Stringa che rappresenta il massaggio della validazione</returns>"
        public override string Validate(string rulesText)
        {
            // l'XSD di validazione viene caricato solo una volta
            if (xsdSchema == null)
            {
                xsdSchema = new XmlSchemaSet();
                XmlReader xsdReader = XmlReader.Create(new StringReader(Properties.Resources.rules));
                xsdSchema.Add("", xsdReader);
            }

            string xmlValidationText = base.Validate(rulesText);
            if (xmlValidationText == "XML valido")
            {
                foreach (XAttribute attr in XDocument.Parse(rulesText).Descendants().Attributes())
                    if (attr.IsNamespaceDeclaration)
                        return "La sintassi delle regole non prevede namespace";

                // l'XML è valido rispetto la sintassi degli XML
                XDocument xmlDocument = XDocument.Parse(rulesText);

                string xsdMessage = "Regole valide";
                xmlDocument.Validate(xsdSchema, (object sender, ValidationEventArgs e) => {
                    // check di eventuali errori di compatibilità con la sintassi delle regole
                    XmlSeverityType severityType = XmlSeverityType.Warning;
                    if (Enum.TryParse("Error", out severityType))
                        if (severityType == XmlSeverityType.Error)
                            xsdMessage = e.Message;
                });
                return xsdMessage;
            }
            else
                return xmlValidationText;
        }
    }
}
