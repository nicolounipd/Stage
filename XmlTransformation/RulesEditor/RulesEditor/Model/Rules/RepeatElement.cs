using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace RulesEditor.Model.Rules
{
    public class RepeatElement : RuleElement
    {
        private static string name = "repeat";
        private ushort times;
        private List<XElement> insideElemList;

        /// <summary>
        /// Costruttore della classe RepeatElement
        /// </summary>
        /// <param name="element">Elemento XML che rappresenta un RepeatElement</param>
        public RepeatElement(XElement xmlElement)
        {
            if (xmlElement.Name == name && IsValid(xmlElement.ToString()))
            {
                times = Convert.ToUInt16(xmlElement.Attribute("times").Value);
                if (insideElemList == null)
                    insideElemList = new List<XElement>();
                // salva in insideElemList tutti gli elementi contenuti in <repeat>...</repeat>
                foreach (XElement insideElem in xmlElement.Elements())
                    insideElemList.Add(insideElem);
            }
        }

        /// <summary>
        /// Costruttore della classe RepeatElement
        /// </summary>
        /// <param name="elementString">Stringa che rappresenta un RepeatElement</param>
        public RepeatElement(string xmlElementString)
        {
            if (xmlElementString != "" && IsValid(xmlElementString))
            {
                XElement element = XElement.Parse(xmlElementString);
                if (element.Name == name)
                {
                    times = Convert.ToUInt16(element.Attribute("times").Value);
                    if (insideElemList == null)
                        insideElemList = new List<XElement>();
                    // salva in insideElemList tutti gli elementi contenuti in <repeat>...</repeat>
                    foreach (XElement insideElem in element.Elements())
                        insideElemList.Add(insideElem);
                }
            }
        }

        /// <summary>
        /// Ritorna la lista degli elementi interni al Repeat ripetuti Times volte
        /// </summary>
        /// <returns>Lista di XElement contenente Times volte gli elementi interni al Repeat</returns>
        public List<XElement> GetNewElementList()
        {
            List<XElement> newElementList = new List<XElement>();
            for (ushort i = 1; i <= times; ++i)
                foreach (XElement elem in insideElemList)
                {
                    // sostituisce tutte le occorrenze di {i} nell'elemento con l'indice dell'iterata
                    string newElem = elem.ToString().Replace("{i}", $"{i}");
                    newElementList.Add(XElement.Parse(newElem));
                }
            return newElementList;
        }

        /// <summary>
        /// Ritorna il nome del RepeatElement
        /// </summary>
        /// <returns>Stringa "repeat" o null se il RepeatElement non è valido</returns>
        public override string GetName()
        {
            return insideElemList != null ? name : null;
        }

        /// <summary>
        /// Ritorna la lista degli attributi del RepeatElement
        /// </summary>
        /// <returns>Lista di XAttrbiute che rappresenta gli attributi del RepeatElement o null se il RepeatElement non è valido</returns>
        public override List<XAttribute> GetAttributes()
        {
            if (insideElemList != null)
            {
                List<XAttribute> attributes = new List<XAttribute>();
                attributes.Add(new XAttribute("times", $"{times}"));
                return attributes;
            }
            return null;
        }

        /// <summary>
        /// Permette di ottenere il valore del RepeatElement
        /// </summary>
        /// <returns>Stringa che rappresenta gli elementi interni al Repeat o null se il RepeatElement non è valido</returns>
        public override string GetValue()
        {
            if (insideElemList != null)
            {
                string elemList = "";
                foreach (XElement elem in insideElemList)
                    elemList += elem.ToString();
                return elemList;
            }
            return null;
        }
    }
}
