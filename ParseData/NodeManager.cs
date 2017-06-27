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

namespace ParseData
{
    public class NodeManager
    {
        public static void AddResxToTreeView(string genericResxFilename, string resxFilename, TreeView treeView, bool generateMissing)
        {
            if (!File.Exists(resxFilename))
            {
                if (generateMissing)
                {
                    File.Copy(genericResxFilename, resxFilename);
                }
                else return;
            }
            TreeNode parentItem = new TreeNode(Path.GetFileName(resxFilename));
            var doc = XDocument.Load(resxFilename);
            parentItem.Tag = new DocumentDescriptor(doc, resxFilename);
            var d = doc.Root.Elements("data");
            foreach (XElement elem in d)
            {
                var nameNode = parentItem.Nodes.Add(elem.FirstAttribute.Value, elem.FirstAttribute.Value);
                //var nameNode = new TreeNode(elem.FirstAttribute.Value);
                nameNode.Tag = elem;
                var valueNode = elem.Elements("value").First();
                var commentNode = elem.Elements("comment").First();
                var valueText = valueNode.Value;
                var commentText = commentNode.Value;
                var valueItem = new TreeNode(valueText);
                var commentItem = new TreeNode(commentText);
                nameNode.Nodes.Add(valueItem);
                nameNode.Nodes.Add(commentItem);
                nameNode.Nodes[0].Name = "1"; // for sorting
                nameNode.Nodes[1].Name = "2";
                //parentItem.Nodes.Add(nameNode);
            }
            treeView.Nodes.Add(parentItem);
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
            if (isMaster || isEnglish) nodeData.Comment = node.Element("comment").Value;
            else nodeData.TranslateComment = node.Element("comment").Value;
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
                found = true;
                XElement xNode = (XElement)tNode.Tag;
                XDocument doc = DocumentDescriptor.DocFromTag(parentTn.Tag);
                var isEnglish = DocumentDescriptor.IsEnglishFromTag(parentTn.Tag);
                var elems = doc.Root.Descendants("data").ToArray();
                var elem = elems.Where(d => (string)d.FirstAttribute.Value ==data.KeyName).FirstOrDefault();
                if (data.Text != "") elem.Element("value").Value = data.Text;
                if (data.Text != "")
                {
                    tNode.Nodes[0].Text = data.Text;
                    tNode.Nodes[0].ForeColor = System.Drawing.Color.Red;
                    tNode.ForeColor = System.Drawing.Color.Red;
                    parentTn.ForeColor = System.Drawing.Color.Red;
                }
                if (isMaster|| isEnglish)
                {
                    if (data.Comment != "")
                    {
                        elem.Element("comment").Value = data.Comment;
                        tNode.Nodes[1].Text = data.Comment;
                        tNode.Nodes[1].ForeColor = System.Drawing.Color.Red;
                        tNode.ForeColor = System.Drawing.Color.Red;
                        parentTn.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    if (data.TranslateComment != "")
                    {
                        elem.Element("comment").Value = data.TranslateComment;
                        tNode.Nodes[1].Text = data.TranslateComment;
                        tNode.Nodes[1].ForeColor = System.Drawing.Color.Red;
                        tNode.ForeColor = System.Drawing.Color.Red;
                        parentTn.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            return found;
        }

        static public void AddNewNodeToTreeNode(NodeData data, TreeNode parentTn, bool isMaster)
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
            var nameElement = new XElement("data");
            var nameAttr = new XAttribute("name",data.KeyName);
            nameElement.Add(nameAttr);
            var preserveAttr = new XAttribute(XNamespace.Xml + "space", "preserve");
            nameElement.Add(preserveAttr);
            var valueNode = new XElement("value",data.Text);
            nameElement.Add(valueNode);
            if (isMaster || isEnglish)
            {
                var commentNode = new XElement("comment", data.Comment);
                nameElement.Add(commentNode);
            }
            else
            {
                var commentNode = new XElement("comment", data.TranslateComment);
                nameElement.Add(commentNode);
            }
            doc.Root.Add(nameElement);
            newTvn.Tag = nameElement;
            newTvn.ForeColor = System.Drawing.Color.Blue;
            parentTn.ForeColor = System.Drawing.Color.Blue;
            
            //parentTn.Nodes.Add(newTvn);
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
        static public void InsertUpdateNodeTddClipboard(TreeNode parentTn, TreeView slaveTv)
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
                    string name = tokens[0];
                    string value = tokens[1];

                    NodeData nData = new NodeData();
                    nData.KeyName = prefix + name;
                    nData.Text = value;
                    nData.Comment = "PLEASE REVIEW";
                    nData.TranslateComment = "PLEASE TRANSLATE";

                    if (SetNodeData(nData, parentTn, true))
                    {
                        foreach (TreeNode tn in slaveTv.Nodes)
                        {
                            NodeManager.SetNodeData(nData, tn, false);
                        }
                    }
                    else
                    {
                        AddNewNodeToTreeNode(nData, parentTn, true);
                        foreach (TreeNode tn in slaveTv.Nodes)
                        {
                            NodeManager.AddNewNodeToTreeNode(nData, tn, false);
                        }
                    }
                }
            }
            catch
            {
                // swallow
            }
        }


        static public string[] GetResxFileNames(string genericResx)
        {
            string dir = Path.GetDirectoryName(genericResx);
            string root = Path.GetFileNameWithoutExtension(genericResx);
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
            var filenames = langs.Select(r => {
                var tmp = Path.Combine(dir, root);
                tmp += "." + r + ".resx";
                return tmp;
            });
            return filenames.ToArray();
        }
    }
}
