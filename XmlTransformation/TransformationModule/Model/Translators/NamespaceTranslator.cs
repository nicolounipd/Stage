using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using TransformationModule.Model.Rules;

namespace TransformationModule.Model.Translators
{
    class NamespaceTranslator
    {
        private XDocument xml;
        private Command command;

        /// <summary>
        /// Ritorna un predicato XPath che è l'unione di due condizioni
        /// </summary>
        /// <param name="condition1">Prima condizione da unire</param>
        /// <param name="condition2">Seconda condizione da unire</param>
        /// <returns>Stringa di un predicato XPath che è il risultato dell'unione di due condizioni</returns>
        private string JoinConditions(string condition1, string condition2)
        {
            // in predicate viene salvata la traduzione di predicate1 e predicate2 in predicato XPath
            string predicate = "";
            if (condition1 != null && condition2 != null)
                predicate = $"[{condition1} and {condition2}]";
            else if (condition1 != null || condition2 != null)
                predicate = $"[{condition1}{condition2}]";
            return predicate;
        }

        /// <summary>
        /// Inserisce una definizione di namespace nella posizione deifinita nel Command
        /// </summary>
        /// <param name="targetElem">Elemento in cui andrà inserita la definizione di namespace</param>
        /// <param name="name">Nome del namespace da inserire</param>
        /// <param name="value">Valore del namespace da inserire</param>
        private void InsertNamespace(XElement targetElem, string name, string value)
        {
            string beforeAttr = command.GetValue("before");
            string afterAttr = command.GetValue("after");
            if (beforeAttr == null && afterAttr == null)
                targetElem.SetAttributeValue(XNamespace.Xmlns + name, value);

            else if (beforeAttr != null)
            {
                foreach (XAttribute attr in targetElem.Attributes())
                    if (attr.IsNamespaceDeclaration && attr.Name.LocalName == beforeAttr)
                    {
                        XAttribute newAttr = new XAttribute(XNamespace.Xmlns + name, value);

                        // il nuovo namespace viene inserito PRIMA del namespace corrente
                        List<XAttribute> attributes = targetElem.Attributes().ToList();
                        attributes.Insert(attributes.IndexOf(attr), newAttr);
                        targetElem.ReplaceAttributes(attributes);
                    }
            }

            else // afterAttr != null && beforeAttr = null
            {
                foreach (XAttribute attr in targetElem.Attributes())
                    if (attr.IsNamespaceDeclaration && attr.Name.LocalName == afterAttr)
                    {
                        XAttribute newAttr = new XAttribute(XNamespace.Xmlns + name, value);

                        // il nuovo namespace viene inserito DOPO il namespace corrente
                        List<XAttribute> attributes = targetElem.Attributes().ToList();
                        attributes.Insert(attributes.IndexOf(attr) + 1, newAttr);
                        targetElem.ReplaceAttributes(attributes);
                    }
            }
        }

        /// <summary>
        /// Aggiunge una definizione di namespace nel punto specificato dal Command
        /// </summary>
        /// <param name="namespaceManager">Contiene la definzione di tutti i namespace dell'XML</param>
        private void Add(XmlNamespaceManager namespaceManager)
        {
            string whereAttr = command.GetValue("where");
            string ifAttr = command.GetValue("if");

            // in predicate viene salvata la traduzione di whereAttr e ifAttr in predicato XPath
            string predicate = JoinConditions(ifAttr, whereAttr);

            XElement targetElem = xml.XPathSelectElement($"{command.GetValue("in")}{predicate}", namespaceManager);
            if (targetElem != null)
                InsertNamespace(targetElem, command.GetValue("name"), command.GetValue());
        }

        /// <summary>
        /// Modifica il valore di una definizione di namespace come specificato nel Command
        /// </summary>
        /// <param name="namespaceManager">Contiene la definzione di tutti i namespace dell'XML</param>
        private void Change(XmlNamespaceManager namespaceManager)
        {
            string whereAttr = command.GetValue("where");
            string ifAttr = command.GetValue("if");

            // in predicate viene salvata la traduzione di whereAttr e ifAttr in predicato XPath
            string predicate = JoinConditions(ifAttr, whereAttr);

            XElement targetElem = xml.XPathSelectElement($"{command.GetValue("in")}{predicate}", namespaceManager);
            if (targetElem == null)
                return;
            foreach (XAttribute attr in targetElem.Attributes())
                if (attr.IsNamespaceDeclaration && attr.Name.LocalName == command.GetValue("name"))
                {
                    string newAttr = $"xmlns:{attr.Name.LocalName}=\"{command.GetValue()}\"";
                    string targetAttr = targetElem.Attribute(XNamespace.Xmlns + attr.Name.LocalName).ToString();
                    string newElem = targetElem.ToString().Replace(targetAttr, newAttr);
                    // l'elemento dell'XML viene sostituito con un nuovo elemento che ha il valore corretto
                    targetElem.ReplaceWith(XElement.Parse(newElem));
                    return;
                }
        }

        /// <summary>
        /// Copia una definizione di namespace nel punto specificato dal Command
        /// </summary>
        /// <param name="namespaceManager">Contiene la definzione di tutti i namespace dell'XML</param>
        private void Copy(XmlNamespaceManager namespaceManager)
        {
            string fromWhereAttr = command.GetValue("fromWhere");
            string toWhereAttr = command.GetValue("toWhere");
            string ifAttr = command.GetValue("if");

            // in predicateFrom viene salvata la traduzione di formWhereAttr e ifAttr in predicato XPath
            string predicateFrom = JoinConditions(ifAttr, fromWhereAttr);

            // in predicateTo viene salvata la traduzione di toWhereAttr e ifAttr in predicato XPath
            string predicateTo = JoinConditions(ifAttr, toWhereAttr);

            XElement targetElem = xml.XPathSelectElement($"{command.GetValue("from")}{predicateFrom}", namespaceManager);
            if (targetElem == null)
                return;
            XAttribute targetAttr = targetElem.Attribute(XNamespace.Xmlns + command.GetValue("name"));
            if (targetAttr == null)
                return;

            // l'attributo viene reinserito nella posizione voluta
            targetElem = xml.XPathSelectElement($"{command.GetValue("to")}{predicateTo}", namespaceManager);
            if (targetElem != null && targetElem.Attribute(XNamespace.Xmlns + targetAttr.Name.LocalName) == null)
                InsertNamespace(targetElem, targetAttr.Name.LocalName, targetAttr.Value);
        }

        /// <summary>
        /// Rimuove una definizione di namespace dal punto specificato nel Command
        /// </summary>
        /// <param name="namespaceManager">Contiene la definzione di tutti i namespace dell'XML</param>
        private void Delete(XmlNamespaceManager namespaceManager)
        {
            string whereAttr = command.GetValue("where");
            string ifAttr = command.GetValue("if");

            // in predicate viene salvata la traduzione di whereAttr e ifAttr in predicato XPath
            string predicate = JoinConditions(ifAttr, whereAttr);

            XElement targetElem = xml.XPathSelectElement($"{command.GetValue("in")}{predicate}", namespaceManager);
            if (targetElem == null)
                return;
            foreach (XAttribute attr in targetElem.Attributes())
                if (attr.IsNamespaceDeclaration && attr.Name.LocalName == command.GetValue("name"))
                {
                    targetElem.SetAttributeValue(XNamespace.Xmlns + attr.Name.LocalName, null);
                    return;
                }
        }

        /// <summary>
        /// Sposta una definizione di namespace nel punto specificato dal Command
        /// </summary>
        /// <param name="namespaceManager">Contiene la definzione di tutti i namespace dell'XML</param>
        private void Move(XmlNamespaceManager namespaceManager)
        {
            string fromWhereAttr = command.GetValue("fromWhere");
            string toWhereAttr = command.GetValue("toWhere");
            string ifAttr = command.GetValue("if");

            // in predicateFrom viene salvata la traduzione di formWhereAttr e ifAttr in predicato XPath
            string predicateFrom = JoinConditions(ifAttr, fromWhereAttr);

            // in predicateTo viene salvata la traduzione di toWhereAttr e ifAttr in predicato XPath
            string predicateTo = JoinConditions(ifAttr, toWhereAttr);

            XElement targetElem = xml.XPathSelectElement($"{command.GetValue("from")}{predicateFrom}", namespaceManager);
            if (targetElem == null)
                return;
            XAttribute targetAttr = targetElem.Attribute(XNamespace.Xmlns + command.GetValue("name"));
            if (targetAttr == null)
                return;

            // il namespace viene inserito nella posizione voluta e viene eliminato dall'origine
            targetElem = xml.XPathSelectElement($"{command.GetValue("to")}{predicateTo}", namespaceManager);
            if (targetElem != null && targetElem.Attribute(XNamespace.Xmlns + targetAttr.Name.LocalName) == null)
            {
                InsertNamespace(targetElem, targetAttr.Name.LocalName, targetAttr.Value);
                targetAttr.Remove();
            }
        }

        /// <summary>
        /// Modifica il nome di una definizione di namespace come specificato nel Command
        /// </summary>
        /// <param name="namespaceManager">Contiene la definzione di tutti i namespace dell'XML</param>
        private void Rename(XmlNamespaceManager namespaceManager)
        {
            string whereAttr = command.GetValue("where");
            string ifAttr = command.GetValue("if");

            // in predicate viene salvata la traduzione di whereAttr e ifAttr in predicato XPath
            string predicate = JoinConditions(ifAttr, whereAttr);

            XElement elem = xml.XPathSelectElement($"{command.GetValue("in")}{predicate}", namespaceManager);
            if (elem == null)
                return;
            foreach (XAttribute attr in elem.Attributes())
                if (attr.IsNamespaceDeclaration && attr.Name.LocalName == command.GetValue("name"))
                {
                    XAttribute newAttr = new XAttribute(XNamespace.Xmlns + command.GetValue(), attr.Value);

                    // il namespcae viene sostituito con un nuovo namespace che ha il nome corretto
                    List<XAttribute> attributes = elem.Attributes().ToList();
                    attributes.Insert(attributes.IndexOf(attr), newAttr);
                    attributes.Remove(attr);
                    elem.ReplaceAttributes(attributes);

                    return;
                }
        }

        /// <summary>
        /// Costruttore della classe NamespaceTranslator
        /// </summary>
        /// <param name="xmlDoc">XDocument che rappresenta l'XML su cui applicare la trasformazione</param>
        /// <param name="commandElement">Command con type="namespace" contenete la definizione della trasformazione</param>
        public NamespaceTranslator(XDocument xmlDoc, Command commandElement)
        {
            xml = xmlDoc;
            command = commandElement;
        }

        /// <summary>
        /// Costruttore della classe NamespaceTranslator
        /// </summary>
        /// <param name="xmlString">Stringa che rappresenta l'XML su cui applicare la trasformazione</param>
        /// <param name="commandElementString">Stringa che rappresenta il Command con type="namespace" contenete la definizione della trasformazione</param>
        public NamespaceTranslator(string xmlString, string commandElementString)
        {
            xml = XDocument.Parse(xmlString);
            command = new Command(commandElementString);
        }

        /// <summary>
        /// Trasforma l'XML secondo la definzione del Command
        /// </summary>
        public void Transform(XmlNamespaceManager namespaceManager)
        {
            string prevXml = xml.ToString();
            switch (command.GetName())
            {
                case "add":
                    Add(namespaceManager);
                    break;
                case "change":
                    Change(namespaceManager);
                    break;
                case "copy":
                    Copy(namespaceManager);
                    break;
                case "delete":
                    Delete(namespaceManager);
                    break;
                case "move":
                    Move(namespaceManager);
                    break;
                case "rename":
                    Rename(namespaceManager);
                    break;
            }

            if (prevXml == xml.ToString())
                throw new Exception("La regola non ha prodotto cambiamenti");
        }

        /// <summary>
        /// Restituisce il risultato della trasformazione
        /// </summary>
        /// <returns>XDocument che rappresenta il nuovo XML trasformato</returns></param>
        public XDocument GetResult()
        {
            return xml;
        }
    }
}
