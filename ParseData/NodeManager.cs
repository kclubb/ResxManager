using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace ParseData
{
    public class NodeManager
    {
        public static void AddResxToTreeView(bool isCombining, string baseResxFile, string addingResxFile, string language, TreeView treeView, bool generateMissing, bool merge, bool isMaster)
        {
            string baseResxFileLang = LangToFileName(baseResxFile, language);
            string addingResxFileLang = LangToFileName(addingResxFile, language);

            // ensure file is created if generate missing is selected
            if (!File.Exists(baseResxFileLang))
            {
                if (generateMissing)
                {
                    File.Copy(baseResxFile, baseResxFileLang);
                }
                else return;
            }

            string key = null;
            if (language != null) // working on language treeview
            {
                key = Path.GetFileName(baseResxFileLang);
            }
            else
            {
                key = Path.GetFileName(baseResxFile);
            }

            TreeNode parentItem = treeView.Nodes[key];
            XDocument doc = null;
            if (parentItem == null)
            {
                parentItem = new TreeNode(Path.GetFileName(key));
                parentItem.Name = Path.GetFileName(key);
                doc = XDocument.Load(addingResxFileLang);
                parentItem.Tag = new DocumentDescriptor(doc, baseResxFileLang); // combining two files
                var d = doc.Root.Elements("data");
                MergeDocIntoTree(isCombining, merge, parentItem, d, isMaster);
                treeView.Nodes.Add(parentItem);
            }
            else
            {
                DocumentDescriptor dd = (DocumentDescriptor)parentItem.Tag;
                doc = dd.Document;
                var doc2 = XDocument.Load(addingResxFileLang);
                var d = doc2.Root.Elements("data");
                MergeDocIntoTree(isCombining, merge, parentItem, d, isMaster);
            }
        }

        private static void MergeDocIntoTree(bool isCombining, bool isMerging, TreeNode parentItem, IEnumerable<XElement> d, bool isMaster)
        {
            foreach (XElement elem in d)
            {
                elem.FirstAttribute.Value = elem.FirstAttribute.Value.Trim();
                if (!isMerging && DataExists(elem.FirstAttribute.Value, parentItem)) continue;

                string key = elem.FirstAttribute.Value;
                var valueNode = elem.Elements("value").FirstOrDefault();
                var commentNode = elem.Elements("comment").FirstOrDefault();
                string valueText = valueNode != null ? valueNode.Value : "-------";
                var commentText = commentNode != null ? commentNode.Value : "";
                var data = new NodeData();
                data.KeyName = key;
                data.Text = valueText;
                data.Comment = commentText;

                var nameNode = parentItem.Nodes[key];
                if (nameNode == null)
                {
                    AddNewNodeToTreeNode(isCombining, data, parentItem, isMaster);
                }
                else
                {
                    SetNodeData(data, parentItem, isMaster);
                }
            }
        }

        static public NodeData GetNodeData(TreeNode tNode, bool isMaster)
        {
            var nodeData = new NodeData();
            if (tNode.Level == 2) tNode = tNode.Parent;
            if (tNode.Level == 0) return null;
            var tnParent = tNode.Parent;
            bool isEnglish = DocumentDescriptor.IsEnglishFromTag(tnParent.Tag);
            XElement node = (XElement)tNode.Tag;
            switch (node.Name.LocalName)
            {
                case "value":
                case "comment":
                    node = node.Parent;
                    break;
            }
            nodeData.KeyName = node.Attribute("name").Value;
            nodeData.Text = node.Element("value").Value;
            XElement commentElem = node.Element("comment");
            if (isMaster || isEnglish) nodeData.Comment = commentElem != null ? commentElem.Value : "";
            else nodeData.TranslateComment              = commentElem != null ? commentElem.Value : "";
            return nodeData;
        }

        static public bool SetNodeData(NodeData data, TreeNode parentTn, bool isMaster)
        {
            if (parentTn.Level == 2) parentTn = parentTn.Parent.Parent;
            else if (parentTn.Level == 1) parentTn = parentTn.Parent;
            bool found = false;
            var tNode = parentTn.Nodes[data.KeyName];
            if (tNode != null)
            {
                XElement xNode = (XElement)tNode.Tag;
                if (xNode == null) return found;

                found = true;
                var isEnglish = DocumentDescriptor.IsEnglishFromTag(parentTn.Tag);
                if (data.Text != "") xNode.Element("value").Value = data.Text;
                if (data.Text != "")
                {
                    tNode.Nodes[0].Text = data.Text;
                    tNode.Nodes[0].ForeColor = System.Drawing.Color.Red;
                    tNode.ForeColor = System.Drawing.Color.Red;
                    parentTn.ForeColor = System.Drawing.Color.Red;
                }
                if (isMaster|| isEnglish)
                {
                    if (data.Comment != null && data.Comment != "")
                    {
                        xNode.Element("comment").Value = data.Comment;
                        tNode.Nodes[1].Text = data.Comment;
                        tNode.Nodes[1].ForeColor = System.Drawing.Color.Red;
                        tNode.ForeColor = System.Drawing.Color.Red;
                        parentTn.ForeColor = System.Drawing.Color.Red;
                        tNode.Nodes[0].Name = "1"; // for sorting
                        tNode.Nodes[1].Name = "2";

                    }
                }
                else
                {
                    if (data.TranslateComment != null && data.TranslateComment != "")
                    {
                        xNode.Element("comment").Value = data.TranslateComment;
                        tNode.Nodes[1].Text = data.TranslateComment;
                        tNode.Nodes[1].ForeColor = System.Drawing.Color.Red;
                        tNode.ForeColor = System.Drawing.Color.Red;
                        parentTn.ForeColor = System.Drawing.Color.Red;
                        tNode.Nodes[0].Name = "1"; // for sorting
                        tNode.Nodes[1].Name = "2";
                    }
                }
            }
            return found;
        }

        static private bool DataExists(NodeData data, TreeNode parentTn)
        {
            if (parentTn.Level == 2) parentTn = parentTn.Parent.Parent;
            else if (parentTn.Level == 1) parentTn = parentTn.Parent;
            var tNode = parentTn.Nodes[data.KeyName];
            bool found = (tNode != null);
            return found;
        }
        static private bool DataExists(string key, TreeNode parentTn)
        {
            if (parentTn.Level == 2) parentTn = parentTn.Parent.Parent;
            else if (parentTn.Level == 1) parentTn = parentTn.Parent;
            var tNode = parentTn.Nodes[key];
            bool found = (tNode != null);
            return found;
        }

        static public void AddNewNodeToTreeNode(bool isCombining, NodeData data, TreeNode parentTn, bool isMaster)
        {
            if (parentTn.Level == 2) parentTn = parentTn.Parent.Parent;
            else if (parentTn.Level == 1) parentTn = parentTn.Parent;
            TreeNode newTvn = parentTn.Nodes.Add(data.KeyName, data.KeyName);
            TreeNode newTextTvn = new TreeNode(data.Text);
            newTvn.Nodes.Add(newTextTvn);
            bool isEnglish = DocumentDescriptor.IsEnglishFromTag(parentTn.Tag);
            if (isMaster || isEnglish)
            {
                TreeNode newCommentTvn = new TreeNode(data.Comment);
                newTvn.Nodes.Add(newCommentTvn);
            }
            else
            {
                TreeNode newCommentTvn = new TreeNode(data.TranslateComment);
                newTvn.Nodes.Add(newCommentTvn);
            }
            newTvn.Nodes[0].Name = "1";
            newTvn.Nodes[1].Name = "2";

            XDocument doc = DocumentDescriptor.DocFromTag(parentTn.Tag);

            // if we are combining a second document, we need to create a new element and add it to the resx document
            // note: otherwise we are just building the tree from the original document
            if (isCombining)
            {
                var newElement = new XElement("data");
                var nameAttr = new XAttribute("name", data.KeyName);
                newElement.Add(nameAttr);
                var preserveAttr = new XAttribute(XNamespace.Xml + "space", "preserve");
                newElement.Add(preserveAttr);
                var valueNode = new XElement("value", data.Text);
                newElement.Add(valueNode);
                if (isMaster || isEnglish)
                {
                    var commentNode = new XElement("comment", data.Comment);
                    newElement.Add(commentNode);
                }
                else
                {
                    var commentNode = new XElement("comment", data.TranslateComment);
                    newElement.Add(commentNode);
                }

                doc.Root.Add(newElement);
            }

            // we have either created a new element in the resx by combining, or are just building the tree
            // either way we want to save the document element in the treenode's tag. So find the
            // node (existing or newly created) in the resx file, and save it in the new treenode's tag
            var elems = doc.Root.Descendants("data").ToArray();
            var elem = elems.Where(d => (string)d.FirstAttribute.Value == data.KeyName).FirstOrDefault();
            newTvn.Tag = elem;
        }

        static public void DeleteTreeNode(string key, TreeNode parentTn)
        {
            if (parentTn.Level == 2) parentTn = parentTn.Parent.Parent;
            else if (parentTn.Level == 1) parentTn = parentTn.Parent;
            foreach (TreeNode tNode in parentTn.Nodes)
            {
                if (key == tNode.Text)
                {
                    XElement xNode = (XElement)tNode.Tag;
                    XDocument doc = DocumentDescriptor.DocFromTag(parentTn.Tag);
                    var elems = doc.Root.Descendants("data").ToArray();
                    var elem = elems.Where(d => (string)d.FirstAttribute.Value == key).FirstOrDefault();
                    if (elem != null)
                    {
                        elem.Remove();
                    }
                    tNode.Remove();
                    break;
                }
            }
        }

        static public void CopyClipboardMissing(TreeView tv, bool missingOnly)
        {
            DocumentDescriptor desc = (DocumentDescriptor)tv.Nodes[0].Tag;
            XDocument doc = desc.Document;
            var d = doc.Root.Elements("data");
            var lines = new List<string>();
            foreach(XElement e in d)
            {
                string name = e.FirstAttribute.Value;
                var valueNode = e.Elements("value").FirstOrDefault();
                var commentNode = e.Elements("comment").FirstOrDefault();
                if (!missingOnly || (missingOnly && (valueNode == null || valueNode.Value == "" || valueNode.Value.StartsWith("***"))))
                {
                    string valueText = valueNode == null ? "NULL" : valueNode.Value;
                    string commentText = commentNode == null ? "NULL" : commentNode.Value;
                    lines.Add(name + '\t' + valueText + "\t" + commentText);
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (var line in lines)
            {
                sb.Append(line);
                sb.AppendLine();
            }
            Clipboard.SetText(sb.ToString(), TextDataFormat.UnicodeText);
        }

        static public void SaveAllFiles(TreeView tv1, TreeView tv2)
        {
            DocumentDescriptor desc = (DocumentDescriptor)tv1.Nodes[0].Tag;
            XDocument doc = desc.Document;
            string filename = desc.Filename;
            doc.Save(filename);
            foreach(TreeNode node in tv2.Nodes)
            {
                desc = (DocumentDescriptor)node.Tag;
                doc = desc.Document;
                filename = desc.Filename;
                doc.Save(filename);
            }
        }

        static public void UpdateNodeWithJSFromClipboard(TreeNode parentTn, bool isMaster)
        {
            try
            {
                string prefix = "";
                char delimitor = '.';
                if (parentTn.Level == 2)
                {
                    prefix = parentTn.Parent.Text;
                    if (!prefix.Contains(delimitor)) delimitor = '_';
                    prefix = prefix.Substring(0, prefix.LastIndexOf(delimitor) + 1);
                    parentTn = parentTn.Parent.Parent;
                }
                else if (parentTn.Level == 1)
                {
                    prefix = parentTn.Text;
                    if (!prefix.Contains(delimitor)) delimitor = '_';
                    prefix = prefix.Substring(0, prefix.LastIndexOf(delimitor) + 1);
                    parentTn = parentTn.Parent;
                }
                var data = Clipboard.GetText();
                int start = data.IndexOf(prefix);
                data = data.Substring(start);
                start = data.IndexOf('{');
                data = data.Substring(start);
                int stop = data.IndexOf('}');
                data = data.Substring(0, stop+1);
                dynamic obj = JObject.Parse(data);
                foreach (JProperty x in (JToken)obj)
                {
                    string name = x.Name;
                    string value = (string)x.Value;

                    NodeData nData = new NodeData();
                    nData.KeyName = prefix + name;
                    nData.Text = value;
                    nData.Comment = "PLEASE REVIEW";
                    nData.TranslateComment = "PLEASE TRANSLATE";

                    SetNodeData(nData, parentTn, isMaster);
                }
            }
            catch
            {
                // swallow
            }
        }
        static public void InsertUpdateNodeTddClipboard(TreeNode parentTn, TreeView slaveTv, bool merge)
        {
            try
            {
                string prefix = "";
                char delimitor = '.';
                if (parentTn.Level == 2)
                {
                    prefix = parentTn.Parent.Text;
                    if (!prefix.Contains(delimitor)) delimitor = '_';
                    prefix = prefix.Substring(0, prefix.LastIndexOf(delimitor) + 1);
                    parentTn = parentTn.Parent.Parent;
                }
                else if (parentTn.Level == 1)
                {
                    prefix = parentTn.Text;
                    if (!prefix.Contains(delimitor)) delimitor = '_';
                    prefix = prefix.Substring(0, prefix.LastIndexOf(delimitor) + 1);
                    parentTn = parentTn.Parent;
                }
                var lines = Clipboard.GetText().Split(new char[] { '\r', '\n' });
                lines = lines.Where(l => !string.IsNullOrEmpty(l)).ToArray();

                foreach (string line in lines)
                {
                    var tokens = line.Split('\t');
                    string name = tokens[0].Trim();
                    if (name[0] == '-' || (name.Length > 18 && name.Substring(0,18) == "OPERATOR ATTENTION")) continue;

                    string value = "*** UNKNOWN ***";
                    if (tokens.Length > 1)
                    {
                        value = tokens[1];
                        value = value.Replace(@"\n\n", @"<br>");
                        value = value.Replace(@"\n", @"<br>");
                    }

                    NodeData nData = new NodeData();
                    nData.KeyName = prefix + name;
                    nData.Text = value;
                    nData.Comment = "PLEASE REVIEW";
                    nData.TranslateComment = "PLEASE TRANSLATE";

                    if (!DataExists(nData, parentTn))
                    {
                        AddNewNodeToTreeNode(true, nData, parentTn, true);
                    }
                    else if (merge) // exists and merging
                    {
                        SetNodeData(nData, parentTn, true);
                    }

                    foreach (TreeNode tn in slaveTv.Nodes)
                    {
                        if (!DataExists(nData, tn))
                        {
                            AddNewNodeToTreeNode(true, nData, tn, false);
                        }
                        else if (merge) // exists and merging
                        {
                            SetNodeData(nData, tn, false);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // swallow
            }
        }

        static public string[] GetLanguages()
        {
            string[] langs = new string[]
            {
                "cs-cz",
                "cs",
                "de-de",
                "de",
                "en-us",
                "en-zw",
                "en",
                "es-es",
                "es",
                "fr-fr",
                "fr",
                "it-it",
                "it",
                "ja-jp",
                "ja",
                "nb-no",
                "nl-nl",
                "nl",
                "no",
                "pl-pl",
                "pl",
                "pt-br",
                "pt",
                "ru-ru",
                "ru",
                "tr-tr",
                "tr",
                "zh-tw",
                "zh"
            };
            return langs;
        }
        static public string LangToFileName(string genericResx, string lang)
        {
            if (lang == null) return genericResx;

            string dir = Path.GetDirectoryName(genericResx);
            string root = Path.GetFileNameWithoutExtension(genericResx);
            var tmp = Path.Combine(dir, root);
            tmp += "." + lang + ".resx";
            return tmp;
        }
        static public void ClearColor(TreeNode tn)
        {
            tn.ForeColor = System.Drawing.Color.Black;
            foreach(TreeNode cn in tn.Nodes)
            {
                ClearColor(cn);
            }
        }
    }
}
