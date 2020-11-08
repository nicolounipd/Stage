using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;
using TransformationModule.Model.Rules;
using TransformationModule.Model.Translators;

namespace TransformationModule.Model
{
    public class Transformer
    {
        private XDocument xml;
        private XDocument rules;
        private XmlNamespaceManager namespaceManager;
        private List<string> unnecessaryRules;
        private string absolutePrefix;
        private string relativePrefix;

        /// <summary>
        /// Aggiunge il namespace di default nei campi dati che lavorano e/o gestiscono i namespace
        /// </summary>
        /// <param name="value">Valore da assegnare al namespace di default</param>
        private void SetDefaultNamespace(string value)
        {
            if (rules.Element("rules").HasAttributes)
            {
                string defaultPrefix = rules.Element("rules").Attribute("defaultPrefix").Value;
                namespaceManager.AddNamespace(defaultPrefix, value);
                Translator.AddNamespace($"xmlns:{defaultPrefix}=\"{value}\"");
            }
        }

        /// <summary>
        /// Rimuove il namespace di default dai campi dati che lavorano e/o gestiscono i namespace
        /// </summary>
        private void RemoveDefaultNamespace()
        {
            if (rules.Element("rules").Attribute("defaultPrefix") != null)
            {
                string defaultPrefix = rules.Element("rules").Attribute("defaultPrefix").Value;
                foreach (XAttribute attr in xml.Descendants().Attributes())
                    if (attr.IsNamespaceDeclaration && attr.Name.LocalName == defaultPrefix)
                        attr.Remove();
            }
        }

        /// <summary>
        /// Aggiorna i campi dati che lavorano e/o gestiscono i namespace
        /// </summary>
        private void UpdateNamespace()
        {
            XmlReader inputXml = XmlReader.Create(new StringReader(xml.ToString()));
            XElement root = XElement.Load(inputXml);
            XmlNameTable nameTable = inputXml.NameTable;
            namespaceManager = new XmlNamespaceManager(nameTable);
            Translator.Init();

            // vengono inseriti in namespaceManager tutti i namespace definiti nell'XML
            foreach (XAttribute attr in xml.Descendants().Attributes())
                if (attr.IsNamespaceDeclaration)
                {
                    if (attr.Name.LocalName != "xmlns")
                    {
                        namespaceManager.AddNamespace(attr.Name.LocalName, attr.Value);
                        Translator.AddNamespace($"xmlns:{attr.Name.LocalName}=\"{attr.Value}\"");
                    }
                    else
                    {
                        namespaceManager.AddNamespace("", attr.Value);
                        Translator.AddNamespace($"{attr.Name.LocalName}=\"{attr.Value}\"");
                        SetDefaultNamespace(attr.Value);
                    }
                }
        }

        /// <summary>
        /// Applica il codice XSLT all'XML
        /// </summary>
        /// <param name="xsltString">Stringa che rappresenta il codice XSLT da applicare</param>
        /// <returns>True se la trasformazione produce dei cambiamenti all'XML, false altrimenti</param>
        private bool ApplyXslt(string xsltString)
        {
            XmlReader inputXml = XmlReader.Create(new StringReader(xml.ToString()));
            XmlReader xsltCode = XmlReader.Create(new StringReader(xsltString));

            StringWriter xmlSrtingWriter = new StringWriter();
            XmlWriter outputXml = XmlWriter.Create(xmlSrtingWriter);

            // trasformo l'XML applicando un command alla volta
            XslCompiledTransform xsltProcessor = new XslCompiledTransform();
            xsltProcessor.Load(xsltCode);
            xsltProcessor.Transform(inputXml, outputXml);

            if (xml.ToString() != XDocument.Parse(xmlSrtingWriter.ToString()).ToString())
            {
                // la trasformazione ha prodotto cambimanti all'XML
                xml = XDocument.Parse(xmlSrtingWriter.ToString());
                return true;
            }
            else
                // la trasformazione NON ha prodotto cambimanti all'XML
                return false;
        }

        /// <summary>
        /// Aggiunge alle regole di tipo Command il prefisso dato dagli elementi di tipo PathElement
        /// </summary>
        /// <returns>Lista di tutti i Command, sia aggiornati che non</returns>
        private List<Command> FixCommandsPath()
        {
            List<Command> updatedCommands = new List<Command>();
            string currentPrefix = absolutePrefix + (relativePrefix != "" ? $"/{relativePrefix}" : "");
            foreach (XElement element in rules.Descendants().Elements().ToList())
            {
                if (element.Name == "repeat")
                    return updatedCommands;
                else if (element.Name == "path")
                {
                    // path può essere assoluto o relativo e viene trattato di conseguenza
                    string path = new PathElement(element).GetValue("current");
                    if (path.StartsWith("/"))
                    {
                        // path assoluto
                        absolutePrefix = path;
                        relativePrefix = "";
                    }
                    else
                        // path relativo
                        relativePrefix = path;
                    currentPrefix = absolutePrefix + (relativePrefix != "" ? $"/{relativePrefix}" : "");
                }
                else if (currentPrefix != "")
                {
                    // element è un Command && ho un prefisso da aggiungere
                    CommandBuilder commandBuilder = new CommandBuilder().UpdateCommand(new Command(element));
                    foreach (XAttribute attr in element.Attributes())
                    {
                        if (!attr.Value.StartsWith("/"))
                        {
                            // il percorso è locale
                            // controlli necessari per costruire percorsi sintatticamenete validi
                            if (attr.Value.StartsWith("./"))
                                attr.Value = attr.Value.Substring(2);
                            if (attr.Value != "" && !currentPrefix.EndsWith("/"))
                                currentPrefix += "/";
                            else if (attr.Value == "" && currentPrefix.EndsWith("/"))
                                currentPrefix = currentPrefix.Remove(currentPrefix.LastIndexOf('/'));

                            switch (attr.Name.ToString())
                            {
                                case "from":
                                    commandBuilder = commandBuilder.SetAttribute("from", $"{currentPrefix}{attr.Value}");
                                    break;
                                case "in":
                                    commandBuilder = commandBuilder.SetAttribute("in", $"{currentPrefix}{attr.Value}");
                                    break;
                                case "to":
                                    commandBuilder = commandBuilder.SetAttribute("to", $"{currentPrefix}{attr.Value}");
                                    break;
                                case "if":
                                    commandBuilder = commandBuilder.SetAttribute("if", $"{currentPrefix}{attr.Value}");
                                    break;
                            }
                        }
                    }
                    updatedCommands.Add(commandBuilder.Build());
                }
                else
                    updatedCommands.Add(new Command(element));
                element.Remove();
            }
            return updatedCommands;
        }

        /// <summary>
        /// Sositutisce l'elemento RepeatElement e tutti i nodi figli con un elenco di Command equivalente
        /// </summary>
        private void ReplaceRepeatRule()
        {
            foreach (XElement element in rules.Descendants().Elements().ToList())
            {
                if (element.Name == "repeat")
                {
                    RepeatElement repeat = null;
                    try
                    {
                        repeat = new RepeatElement(element);
                    }
                    catch
                    {
                        // l'attributo times di repeat è una espressione XPath -> è necessario trovarne il valore
                        XPathNavigator navigator = xml.CreateNavigator();
                        double times = (double)navigator.Evaluate(element.Attribute("times").Value, namespaceManager);
                        element.Attribute("times").Value = $"{times}";
                        repeat = new RepeatElement(element);
                    }
                    // gli elementi interni al RepeatElement vengono estratti nel livello superiore Times volte
                    foreach (XElement insideRepeatElem in repeat.GetNewElementList())
                        element.AddBeforeSelf(insideRepeatElem);
                    element.Remove();
                }
            }
        }

        /// <summary>
        /// Costruttore della classe Transformer
        /// </summary>
        /// <param name="xmlDoc">XDocument che rappresenta l'XML di input</param>
        /// <param name="rulesDoc">XDocument che rappresenta il file delle regole</param>
        public Transformer(XDocument xmlDoc, XDocument rulesDoc)
        {
            SetXmlDocument(xmlDoc);
            SetRulesDocument(rulesDoc);
        }

        /// <summary>
        /// Costruttore della classe Transformer
        /// </summary>
        /// <param name="xmlText">Stringa che rappresenta il contenuto dell'XML di input</param>
        /// <param name="rulesText">Stringa che rappresenta il contenuto del file delle regole</param>
        public Transformer(string xmlText, string rulesText)
        {
            SetXmlDocument(xmlText);
            SetRulesDocument(rulesText);
        }

        /// <summary>
        /// Imposta o aggiorna l'XML di input
        /// </summary>
        /// <param name="xmlDoc">XDocument che rappresenta l'XML di input</param>
        public void SetXmlDocument(XDocument xmlDoc)
        {
            xml = xmlDoc;
        }

        /// <summary>
        /// Imposta o aggiorna il l'XML di input
        /// </summary>
        /// <param name="xmlText">Stringa che rappresenta il contenuto dell'XML di input</param>
        public void SetXmlDocument(string xmlText)
        {
            xml = XDocument.Parse(xmlText);
        }

        /// <summary>
        /// Imposta o aggiorna l'XML delle regole
        /// </summary>
        /// <param name="rulesDoc">XDocument che rappresenta il file delle regole</param>
        public void SetRulesDocument(XDocument rulesDoc)
        {
            rules = rulesDoc;
        }

        /// <summary>
        /// Imposta o aggiorna l'XML delle regole
        /// </summary>
        /// <param name="xml">Stringa che rappresenta il contenuto del file delle regole</param>
        public void SetRulesDocument(string rulesText)
        {
            rules = XDocument.Parse(rulesText);
        }

        /// <summary>
        /// Trasforma l'XML di input secondo la definizione della regole
        /// </summary>
        public void Transfrom()
        {
            absolutePrefix = "";
            relativePrefix = "";
            unnecessaryRules = new List<string>();
            UpdateNamespace();

            // viene salvata la dichiarazione dell'XML perchè verrà cancellata durante processo di trasformazione
            XDeclaration xmlDeclaration = xml.Declaration;

            // applicazione della trasformazione identità necessaria per ottimizzare la ricerca di path errati
            ApplyXslt(Translator.IdentityTransform());

            do
            {
                foreach (Command command in FixCommandsPath())
                {
                    if (command.GetValue("type") == "namespace")
                    {
                        NamespaceTranslator namespaceTranslator = new NamespaceTranslator(xml, command);
                        try
                        {
                            namespaceTranslator.Transform(namespaceManager);
                            UpdateNamespace();
                        }
                        catch
                        {
                            unnecessaryRules.Add(command.ToString());
                        }
                    }
                    else
                    {
                        Translator xmlTranslator = null;
                        switch (command.GetName())
                        {
                            case "add":
                                xmlTranslator = new AddTranslator();
                                break;
                            case "change":
                                xmlTranslator = new ChangeTranslator();
                                break;
                            case "copy":
                                xmlTranslator = new CopyTranslator();
                                break;
                            case "delete":
                                xmlTranslator = new DeleteTranslator();
                                break;
                            case "move":
                                xmlTranslator = new MoveTranslator();
                                break;
                            case "rename":
                                xmlTranslator = new RenameTranslator();
                                break;
                        }
                        // se la trasformazione non produce cambiamenti -> la regola viene aggiunta alla lista di regole inutili
                        if (!ApplyXslt(xmlTranslator.Translate(command)))
                            unnecessaryRules.Add(command.ToString());
                    }
                }
                ReplaceRepeatRule();
            } while (rules.Descendants().Elements().Count() > 0);

            // il default namespace serviva solo per poter fare il match degli elementi con xmlns
            RemoveDefaultNamespace();

            // viene reimpostata la dichiarazione XML iniziale
            xml.Declaration = xmlDeclaration;
        }

        /// <summary>
        /// Verifica che le regole abbiano prodotto cambiamenti
        /// </summary>
        /// <returns>Lista di strighe che rappresentano i command che non hanno prodotto cambiamenti nell'XML</returns>
        public List<string> UnnecessaryRules()
        {
            if (unnecessaryRules == null)
                return new List<string>();
            return unnecessaryRules;
        }

        /// <summary>
        /// Ritorna il riusultato dell'ultima trasformazione effettuata
        /// </summary>
        /// <returns>Stringa XML corrispondente al risultato dell'ultima trasformazione effettuata</returns>
        public string GetOutputXml()
        {
            if (xml.Declaration == null)
                return xml.ToString();
            else
                return $"{xml.Declaration}\n{xml}";
        }
    }
}
