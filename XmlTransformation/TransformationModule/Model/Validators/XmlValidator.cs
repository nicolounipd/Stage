using System;
using System.Xml.Linq;

namespace TransformationModule.Model.Validators
{
    public class XmlValidator
    {
        private static readonly XmlValidator validator = new XmlValidator();

        /// <summary>
        /// Costruttore della classe RulesValidator
        /// </summary>
        protected XmlValidator() {}

        /// <summary>
        /// Permette di ottenere un'istanza della classe XmlValidator
        /// </summary>
        /// <returns>Istanza della classe XmlValidator</returns>"
        public static XmlValidator Use()
        {
            return validator;
        }

        /// <summary>
        /// Valida il contenuto di una stringa secondo la sintassi degli XML
        /// </summary>
        /// <param name="rulesText">Stringa XML da validatre</param>
        /// <returns>Stringa che rappresenta il massaggio della validazione</returns>"
        public virtual string Validate(string xmlText)
        {
            try
            {
                XDocument xmlDocument = XDocument.Parse(xmlText);
                return "XML valido";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
