using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace TransformationModule.Model.Rules
{
    public class Command : RuleElement
    {
        private string action;
        private List<XAttribute> attributes;
        private string value;

        /// <summary>
        /// Costruttore della classe Command
        /// </summary>
        /// <param name="xmlElement">Oggeto di tipo XElement che rappresenta un elemento XML</param>
        public Command(XElement xmlElement)
        {
            if (IsValid(xmlElement.ToString()) && xmlElement.Name != "path" && xmlElement.Name != "repeat")
            {
                action = xmlElement.Name.ToString();
                attributes = xmlElement.Attributes().ToList();
                value = xmlElement.Value;
            }
        }

        /// <summary>
        /// Costruttore della classe Command
        /// </summary>
        /// <param name="xmlString">Stringa che rappresenta un elemento XML</param>
        public Command(string xmlElementString)
        {
            if (xmlElementString != "" && IsValid(xmlElementString))
            {
                XElement xmlElement = XElement.Parse(xmlElementString);
                if (xmlElement.Name != "path" && xmlElement.Name != "repeat")
                {
                    action = xmlElement.Name.ToString();
                    attributes = xmlElement.Attributes().ToList();
                    value = xmlElement.Value;
                }
            }
        }

        /// <summary>
        /// Restituisce il nome del Command
        /// </summary>
        /// <returns>Stringa che rappresenta il nome del Commmand o null se il Commmand non è valido</returns>"
        public override string GetName()
        {
            return action;
        }

        /// <summary>
        /// Restituisce la lista degli attributi del Command
        /// </summary>
        /// <returns>Lista di XAttrbiute che rappresenta gli attributi del Command o null se il Commmand non è valido</returns>"
        public override List<XAttribute> GetAttributes()
        {
            return attributes;
        }

        /// <summary>
        /// Restituisce il valore del Command
        /// </summary>
        /// <returns>Stringa che rappresenta il valore del Command o null se il Commmand non è valido</returns>"
        public override string GetValue()
        {
            return value;
        }
    }
}
