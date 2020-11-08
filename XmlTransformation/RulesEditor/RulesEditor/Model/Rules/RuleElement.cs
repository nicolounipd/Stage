using System.Collections.Generic;
using System.Xml.Linq;
using RulesEditor.Model.Validators;

namespace RulesEditor.Model.Rules
{
    public abstract class RuleElement
    {
        /// <summary>
        /// Verifica se la sintassi di un elemento è conforme a quella delle regole
        /// </summary>
        /// <param name="element">Stringa che rappresenta l'elemento di cui si vuole verificare la sintassi</param>
        /// <returns>True se l'elemento è conforme alla sintassi delle regole, false altrimenti</returns>
        protected static bool IsValid(string xmlElementString)
        {
            return RulesValidator.Use().Validate(
                $"<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                $"<rules>" +
                    xmlElementString +
                $"</rules>"
            ) == "Regole valide";
        }

        /// <summary>
        /// Restituisce il codice XML del RuleElement
        /// </summary>
        /// <returns>Stringa che rappresenta il codice XML del RuleElement</returns>
        public override string ToString()
        {
            string name = GetName();
            if (name != null)
            {
                // creazione di una stringa con contenenti tutti gli attributi del RuleElement
                string attrStringList = "";
                foreach (XAttribute attr in GetAttributes())
                    if (attr.Value != null)
                        attrStringList += $" {attr.Name}=\"{attr.Value}\"";

                string value = GetValue(); 
                if (value != "")
                    // <elemento>valore</elemento>
                    return string.Format("<{0}{1}>{2}</{0}>", name, attrStringList, value);
                else
                    // <elemento/>
                    return string.Format("<{0}{1}/>", name, attrStringList);
            }
            else
                return null;
        }

        /// <summary>
        /// Ritorna, se presente, il valore dell'attributo richiesto del RuleElement
        /// </summary>
        /// <param name="attrName">Stringa che rappresenta l'attributo del quale si vuole ottenere il valore</param>
        /// <returns>Stringa che rappresenta il valore dell'attributo richiesto, null se non presente</returns>
        public string GetValue(string attrName)
        {
            List<XAttribute> attributes = GetAttributes();
            if (attributes != null)
                foreach (XAttribute attr in attributes)
                    if (attr.Name == attrName)
                        return attr.Value;
            return null;
        }

        /// <summary>
        /// Ritorna il nome del RuleElement
        /// </summary>
        /// <returns>Stringa che rappresenta il nome del RuleElement</returns>
        public abstract string GetName();

        /// <summary>
        /// Ritorna la lista degli attributi presenti nel RuleElement
        /// </summary>
        /// <returns>Stringa che rappresenta la lsita degli attributi del RuleElement</returns>
        public abstract List<XAttribute> GetAttributes();

        /// <summary>
        /// Ritorna il valore del RuleElement
        /// </summary>
        /// <returns>Stringa che rappresenta il valore del RuleElement</returns>
        public abstract string GetValue();
    }
}
