using System.Collections.Generic;
using System.Xml.Linq;

namespace RulesEditor.Model.Rules
{
    public class PathElement : RuleElement
    {
        private static string name = "path";
        private string current;

        /// <summary>
        /// Costruttore della classe PathElement
        /// </summary>
        /// <param name="xmlElement">Oggeto di tipo XElement che rappresenta un elemento XML</param>
        public PathElement(XElement xmlElement)
        {
            if (IsValid(xmlElement.ToString()) && xmlElement.Name == name)
                current = xmlElement.Attribute("current").Value;
        }

        /// <summary>
        /// Costruttore della classe PathElement
        /// </summary>
        /// <param name="xmlString">Stringa che rappresenta un elemento XML</param>
        public PathElement(string xmlElementString)
        {
            if (IsValid(xmlElementString))
            {
                XElement xmlElement = XElement.Parse(xmlElementString);
                if (xmlElement.Name == name)
                    current = xmlElement.Attribute("current").Value;
            }
        }

        /// <summary>
        /// Ritorna il nome del PathElement
        /// </summary>
        /// <returns>Stringa "path" o null se il RepeatElement non è valido</returns>
        public override string GetName()
        {
            return current != null ? name : null;
        }

        /// <summary>
        /// Ritorna la lista degli attributi del PathElement
        /// </summary>
        /// <returns>Lista di XAttrbiute che rappresenta gli attributi del PathElement o null se il RepeatElement non è valido</returns>
        public override List<XAttribute> GetAttributes()
        {
            if (current != null)
            {
                List<XAttribute> attributes = new List<XAttribute>();
                attributes.Add(new XAttribute("current", current));
                return attributes;
            }
            return null;
        }

        /// <summary>
        /// Permette di ottenere il valore del PathElement
        /// </summary>
        /// <returns>Stringa vuota o null se il RepeatElement non è valido</returns>
        public override string GetValue()
        {
            return current != null ? "" : null;
        }
    }
}
