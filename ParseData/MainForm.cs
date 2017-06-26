using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;

namespace ParseData
{
    public partial class MainForm : Form
    {
        private string genericResx;
        private TreeNode selectedNode;

        public MainForm()
        {
            InitializeComponent();
            treeView1.TreeViewNodeSorter = new NodeSorter();
            treeView2.TreeViewNodeSorter = new NodeSorter();
            treeView1.Sorted = true;
            treeView2.Sorted = true;
        }

        private void LoadButton_click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                treeView1.Nodes.Clear();
                treeView2.Nodes.Clear();
                genericResx = openFileDialog.FileName;
                NodeManager.AddResxToTreeView(genericResx, genericResx, treeView1, GenerateMissingCheckbox.Checked);
                var filenames = NodeManager.GetResxFileNames(genericResx);
                foreach (string fileName in filenames)
                {
                    NodeManager.AddResxToTreeView(genericResx, fileName, treeView2, GenerateMissingCheckbox.Checked);
                }
                NewButton.Visible = true;
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void AddAllButton_click(object sender, EventArgs e)
        {
            var data = new NodeData();
            data.KeyName = KeyEdit.Text;
            data.Text = ValueEdit.Text;
            data.Comment = MasterCommentEdit.Text;
            data.TranslateComment = TranslateCommentEdit.Text;

            var selectedResxNode = treeView1.Nodes[0];
            NodeManager.AddNewNodeToTreeNode(data, selectedResxNode, true);
            var nodes = treeView2.Nodes;
            foreach (TreeNode tn in nodes)
            {
                NodeManager.AddNewNodeToTreeNode(data, tn, false);
            }

            AddAllButton.Visible = false;
            ControlsPanel.Visible = false;
            treeView1.Sort();
            treeView2.Sort();
        }

        private void DeleteButton_click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Delete Entryies", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                NodeManager.DeleteTreeNode(KeyEdit.Text, treeView1.Nodes[0]);
                var nodes = treeView2.Nodes;
                foreach (TreeNode tn in nodes)
                {
                    NodeManager.DeleteTreeNode(KeyEdit.Text, tn);
                }
            }

        }

        private void SaveButton_click(object sender, EventArgs e)
        {
            NodeManager.SaveAllFiles(treeView1, treeView2);
        }

        private void ApplyChangeButton_click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var data = new NodeData();
            data.KeyName = KeyEdit.Text;
            data.Text = ValueEdit.Text;
            data.Comment = MasterCommentEdit.Text;
            data.TranslateComment = TranslateCommentEdit.Text;

            var parentNode = treeView1.Nodes[0];
            NodeManager.SetNodeData(data, parentNode, true);
            var nodes = treeView2.Nodes;
            foreach (TreeNode tn in nodes)
            {
                NodeManager.SetNodeData(data, tn, false);
            }
            this.Cursor = Cursors.Default;
        }
        private void ApplySingleMasterButton_Click(object sender, EventArgs e)
        {
            var data = new NodeData();
            data.KeyName = KeyEdit.Text;
            data.Text = ValueEdit.Text;
            data.Comment = MasterCommentEdit.Text;
            data.TranslateComment = TranslateCommentEdit.Text;

            NodeManager.SetNodeData(data, selectedNode, true);
        }

        private void ApplyChangeButton2_Click(object sender, EventArgs e)
        {
            var data = new NodeData();
            data.KeyName = KeyEdit.Text;
            data.Text = ValueEdit.Text;
            data.Comment = MasterCommentEdit.Text;
            data.TranslateComment = TranslateCommentEdit.Text;

            NodeManager.SetNodeData(data, selectedNode, false);
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectedNode = treeView1.SelectedNode;
            PasteJSButton.Visible = false;
            var data = NodeManager.GetNodeData(selectedNode,true);
            if (data != null)
            {
                KeyEdit.Text = data.KeyName;
                MasterCommentEdit.Text = data.Comment;
                ValueEdit.Text = data.Text;
                TranslateCommentEdit.Text = "";

                KeyEdit.Enabled = false;

                ControlsPanel.Visible = true;
                ShowMasterControls(true, true);
                ShowTranslateControls(true, true);
                AddAllButton.Visible = false;
                ApplyChangeButton.Visible = true;
                ApplyChangeButton2.Visible = false;
                ApplySingleMasterButton.Visible = true;
                DeleteButton.Visible = true;
                PasteJSButton.Visible = true;
            }
            else
            {
                ControlsPanel.Visible = false;
            }
            if (selectedNode.Level == 0) PasteTddButton.Visible = true;
            else PasteTddButton.Visible = false;
        }
        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectedNode = treeView2.SelectedNode;
            PasteJSButton.Visible = false;
            var data = NodeManager.GetNodeData(selectedNode,false);
            if (data != null)
            {
                KeyEdit.Text = data.KeyName;
                MasterCommentEdit.Text = data.Comment;
                TranslateCommentEdit.Text = data.TranslateComment;
                ValueEdit.Text = data.Text;

                KeyEdit.Enabled = false;

                ControlsPanel.Visible = true;
                ShowMasterControls(true, true);
                ShowTranslateControls(true, true);
                AddAllButton.Visible = false;
                ApplyChangeButton.Visible = false;
                ApplyChangeButton2.Visible = true;
                ApplySingleMasterButton.Visible = false;
                DeleteButton.Visible = false;
                PasteJSButton.Visible = true;
                PasteTddButton.Visible = false;
            }
            else
            {
                ControlsPanel.Visible = false;
            }
            PasteTddButton.Visible = false;
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            KeyEdit.Text = "";
            MasterCommentEdit.Text = "";
            TranslateCommentEdit.Text = "";
            ValueEdit.Text = "";

            KeyEdit.Enabled = true;
            ControlsPanel.Visible = true;
            ShowMasterControls(true,true);
            ShowTranslateControls(true, true);
            AddAllButton.Visible = true;
            ApplyChangeButton.Visible = false;
            ApplyChangeButton2.Visible = false;
            ApplySingleMasterButton.Visible = false;
            DeleteButton.Visible = false;
        }
        private void PasteJSButton_Click(object sender, EventArgs e)
        {
            NodeManager.UpdateNodeWithJSFromClipboard(selectedNode, false);
        }

        private void PasteTddButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            NodeManager.InsertUpdateNodeTddClipboard(selectedNode, treeView2);
            this.Cursor = Cursors.Default;
        }

        #region link labels
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MasterCommentEdit.Text = "PLEASE REVIEW";
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MasterCommentEdit.Text = "Reviewed " + DateTime.Now.ToShortDateString();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TranslateCommentEdit.Text = "PLEASE TRANSLATE";
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TranslateCommentEdit.Text = "DO NOT TRANSLATE";
        }

        private void PleaseReviewLink2_click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TranslateCommentEdit.Text = "PLEASE REVIEW";
        }


        #endregion

        private void ShowMasterControls(bool show, bool showLinks)
        {
            MasterCommentEdit.Visible = show;
            MasterCommentEditLabel.Visible = show;
            PleaseReviewLink.Visible = showLinks;
            ReviewedLink.Visible = showLinks;
        }

        private void ShowTranslateControls(bool show, bool showLinks)
        {
            TranslateCommentEdit.Visible = show;
            TranslateCommentEditLabel.Visible = show;
            PleaseTranslateLink.Visible = showLinks;
            DoNotTranslateLink.Visible = showLinks;
            PleaseReviewLink2.Visible = showLinks;
        }

        private void treeView1_Leave(object sender, EventArgs e)
        {
            treeView1.SelectedNode = null;
        }

        private void treeView2_Leave(object sender, EventArgs e)
        {
            treeView2.SelectedNode = null;
        }
    }
}
