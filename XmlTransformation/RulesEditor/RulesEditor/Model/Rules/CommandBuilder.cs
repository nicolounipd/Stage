using System.Collections.Generic;
using System.Xml.Linq;

namespace RulesEditor.Model.Rules
{
    public class CommandBuilder
    {
        string action;
        List<XAttribute> attributes;
        string value;

        /// <summary>
        /// Acquisice i campi dati di un Command
        /// </summary>
        /// <param name="command">Command del quale si vuole acquisire i dati</param>
        /// <returns>Riferimento al CommandBuilder</returns>
        public CommandBuilder UpdateCommand(Command command)
        {
            action = command.GetName();
            attributes = command.GetAttributes();
            value = command.GetValue();
            return this;
        }

        /// <summary>
        /// Imposta il nome del Command
        /// </summary>
        /// <param name="elemValue">Nome da impostare</param>
        /// <returns>Riferimento al CommandBuilder</returns>
        public CommandBuilder SetName(string elemName)
        {
            action = elemName;
            return this;
        }

        /// <summary>
        /// Aggiunge o aggiorna un attributo al Command
        /// </summary>
        /// <param name="attrName">Nome dell'attributo da aggiungere o aggiornare</param>
        /// <param name="attrValue">Valore dell'attributo da aggiungere o aggiornare</param>
        /// <returns>Riferimento al CommandBuilder</returns>
        public CommandBuilder SetAttribute(string attrName, string attrValue)
        {
            if (attributes == null)
                attributes = new List<XAttribute>();

            if (attrValue != null && attrValue != "")
            {
                XAttribute newAttribute = new XAttribute(attrName, attrValue);
                short indexOfAttribute = -1;
                foreach (XAttribute attr in attributes)
                    if (attr.Name == attrName)
                    {
                        indexOfAttribute = (short)attributes.IndexOf(attr);
                        break;
                    }
                if (indexOfAttribute == -1)
                    // attributo non trovato -> l'attributo va aggiunto
                    attributes.Add(newAttribute);
                else
                {
                    // attributo trovato -> l'attributo va sostituito
                    attributes.Insert(indexOfAttribute, newAttribute);
                    attributes.RemoveAt(indexOfAttribute + 1);
                }
            }
            return this;
        }

        /// <summary>
        /// Rimuove un attributo del Command se presente
        /// </summary>
        /// <param name="attrName">Nome dell'attributo da rimuovere</param>
        /// <returns>Riferimento al CommandBuilder</returns>
        public CommandBuilder RemoveAttribute(string attrName)
        {
            foreach (XAttribute attribute in attributes)
                if (attribute.Name.ToString() == attrName)
                {
                    // attributo trovato -> l'attributo va rimosso
                    attributes.Remove(attribute);
                    break;
                }
            return this;
        }


        /// <summary>
        /// Imposta il valore del Command
        /// </summary>
        /// <param name="elemValue">Valore da impostare</param>
        /// <returns>Riferimento al CommandBuilder</returns>
        public CommandBuilder SetValue(string elemValue)
        {
            value = elemValue;
            return this;
        }

        /// <summary>
        /// Costruisce il Command
        /// </summary>
        /// <returns>Command con le caratteristiche impostate</returns>
        public Command Build()
        {
            try
            {
                XElement xmlElement = new XElement(action);
                foreach (XAttribute attr in attributes)
                    xmlElement.SetAttributeValue(attr.Name, attr.Value);
                xmlElement.Value = value != null  ? value : "";
                return new Command(xmlElement);
            }
            catch
            {
                // XElement non valido
                return new Command("");
            }
        }
    }
}
