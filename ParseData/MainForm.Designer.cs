namespace ParseData
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.LoadButton = new System.Windows.Forms.Button();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.ApplyChangeButton = new System.Windows.Forms.Button();
            this.AddAllButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.KeyEdit = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GenerateMissingCheckbox = new System.Windows.Forms.CheckBox();
            this.NewButton = new System.Windows.Forms.Button();
            this.KeyEditLabel = new System.Windows.Forms.Label();
            this.ValueEdit = new System.Windows.Forms.TextBox();
            this.ValueEditLabel = new System.Windows.Forms.Label();
            this.MasterCommentEdit = new System.Windows.Forms.TextBox();
            this.MasterCommentEditLabel = new System.Windows.Forms.Label();
            this.TranslateCommentEditLabel = new System.Windows.Forms.Label();
            this.TranslateCommentEdit = new System.Windows.Forms.TextBox();
            this.ControlsPanel = new System.Windows.Forms.Panel();
            this.ApplySingleMasterButton = new System.Windows.Forms.Button();
            this.ApplyChangeButton2 = new System.Windows.Forms.Button();
            this.PleaseReviewLink2 = new System.Windows.Forms.LinkLabel();
            this.DoNotTranslateLink = new System.Windows.Forms.LinkLabel();
            this.PleaseTranslateLink = new System.Windows.Forms.LinkLabel();
            this.ReviewedLink = new System.Windows.Forms.LinkLabel();
            this.PleaseReviewLink = new System.Windows.Forms.LinkLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.PasteJSButton = new System.Windows.Forms.Button();
            this.PasteTddButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ControlsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(6, 20);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(349, 708);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.Leave += new System.EventHandler(this.treeView1_Leave);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(12, 9);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 31);
            this.LoadButton.TabIndex = 1;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_click);
            // 
            // treeView2
            // 
            this.treeView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView2.CausesValidation = false;
            this.treeView2.HideSelection = false;
            this.treeView2.Location = new System.Drawing.Point(6, 20);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(295, 708);
            this.treeView2.TabIndex = 2;
            this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
            this.treeView2.Leave += new System.EventHandler(this.treeView2_Leave);
            // 
            // ApplyChangeButton
            // 
            this.ApplyChangeButton.Location = new System.Drawing.Point(9, 330);
            this.ApplyChangeButton.Name = "ApplyChangeButton";
            this.ApplyChangeButton.Size = new System.Drawing.Size(106, 29);
            this.ApplyChangeButton.TabIndex = 3;
            this.ApplyChangeButton.Text = "Apply All";
            this.ApplyChangeButton.UseVisualStyleBackColor = true;
            this.ApplyChangeButton.Click += new System.EventHandler(this.ApplyChangeButton_click);
            // 
            // AddAllButton
            // 
            this.AddAllButton.Location = new System.Drawing.Point(9, 295);
            this.AddAllButton.Name = "AddAllButton";
            this.AddAllButton.Size = new System.Drawing.Size(104, 29);
            this.AddAllButton.TabIndex = 4;
            this.AddAllButton.Text = "Add All";
            this.AddAllButton.UseVisualStyleBackColor = true;
            this.AddAllButton.Click += new System.EventHandler(this.AddAllButton_click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(124, 330);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(104, 29);
            this.DeleteButton.TabIndex = 5;
            this.DeleteButton.Text = "Delete All";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(941, 9);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 31);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_click);
            // 
            // KeyEdit
            // 
            this.KeyEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KeyEdit.Location = new System.Drawing.Point(5, 29);
            this.KeyEdit.Name = "KeyEdit";
            this.KeyEdit.Size = new System.Drawing.Size(322, 22);
            this.KeyEdit.TabIndex = 8;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 53);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.treeView2);
            this.splitContainer1.Size = new System.Drawing.Size(666, 731);
            this.splitContainer1.SplitterDistance = 358;
            this.splitContainer1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Master (Invariant)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Generated";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GenerateMissingCheckbox);
            this.panel1.Controls.Add(this.LoadButton);
            this.panel1.Controls.Add(this.SaveButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 47);
            this.panel1.TabIndex = 10;
            // 
            // GenerateMissingCheckbox
            // 
            this.GenerateMissingCheckbox.AutoSize = true;
            this.GenerateMissingCheckbox.Location = new System.Drawing.Point(122, 15);
            this.GenerateMissingCheckbox.Name = "GenerateMissingCheckbox";
            this.GenerateMissingCheckbox.Size = new System.Drawing.Size(170, 21);
            this.GenerateMissingCheckbox.TabIndex = 20;
            this.GenerateMissingCheckbox.Text = "Generate missing files";
            this.GenerateMissingCheckbox.UseVisualStyleBackColor = true;
            // 
            // NewButton
            // 
            this.NewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NewButton.Location = new System.Drawing.Point(684, 77);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(105, 31);
            this.NewButton.TabIndex = 11;
            this.NewButton.Text = "New Entry";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Visible = false;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // KeyEditLabel
            // 
            this.KeyEditLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KeyEditLabel.AutoSize = true;
            this.KeyEditLabel.Location = new System.Drawing.Point(5, 9);
            this.KeyEditLabel.Name = "KeyEditLabel";
            this.KeyEditLabel.Size = new System.Drawing.Size(32, 17);
            this.KeyEditLabel.TabIndex = 12;
            this.KeyEditLabel.Text = "Key";
            // 
            // ValueEdit
            // 
            this.ValueEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ValueEdit.Location = new System.Drawing.Point(5, 74);
            this.ValueEdit.Name = "ValueEdit";
            this.ValueEdit.Size = new System.Drawing.Size(322, 22);
            this.ValueEdit.TabIndex = 13;
            // 
            // ValueEditLabel
            // 
            this.ValueEditLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ValueEditLabel.AutoSize = true;
            this.ValueEditLabel.Location = new System.Drawing.Point(5, 54);
            this.ValueEditLabel.Name = "ValueEditLabel";
            this.ValueEditLabel.Size = new System.Drawing.Size(44, 17);
            this.ValueEditLabel.TabIndex = 14;
            this.ValueEditLabel.Text = "Value";
            // 
            // MasterCommentEdit
            // 
            this.MasterCommentEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MasterCommentEdit.Location = new System.Drawing.Point(5, 123);
            this.MasterCommentEdit.Name = "MasterCommentEdit";
            this.MasterCommentEdit.Size = new System.Drawing.Size(322, 22);
            this.MasterCommentEdit.TabIndex = 15;
            // 
            // MasterCommentEditLabel
            // 
            this.MasterCommentEditLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MasterCommentEditLabel.AutoSize = true;
            this.MasterCommentEditLabel.Location = new System.Drawing.Point(5, 103);
            this.MasterCommentEditLabel.Name = "MasterCommentEditLabel";
            this.MasterCommentEditLabel.Size = new System.Drawing.Size(114, 17);
            this.MasterCommentEditLabel.TabIndex = 16;
            this.MasterCommentEditLabel.Text = "Master Comment";
            // 
            // TranslateCommentEditLabel
            // 
            this.TranslateCommentEditLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TranslateCommentEditLabel.AutoSize = true;
            this.TranslateCommentEditLabel.Location = new System.Drawing.Point(5, 206);
            this.TranslateCommentEditLabel.Name = "TranslateCommentEditLabel";
            this.TranslateCommentEditLabel.Size = new System.Drawing.Size(131, 17);
            this.TranslateCommentEditLabel.TabIndex = 18;
            this.TranslateCommentEditLabel.Text = "Translate Comment";
            // 
            // TranslateCommentEdit
            // 
            this.TranslateCommentEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TranslateCommentEdit.Location = new System.Drawing.Point(5, 226);
            this.TranslateCommentEdit.Name = "TranslateCommentEdit";
            this.TranslateCommentEdit.Size = new System.Drawing.Size(322, 22);
            this.TranslateCommentEdit.TabIndex = 17;
            // 
            // ControlsPanel
            // 
            this.ControlsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlsPanel.Controls.Add(this.ApplySingleMasterButton);
            this.ControlsPanel.Controls.Add(this.ApplyChangeButton2);
            this.ControlsPanel.Controls.Add(this.PleaseReviewLink2);
            this.ControlsPanel.Controls.Add(this.DoNotTranslateLink);
            this.ControlsPanel.Controls.Add(this.PleaseTranslateLink);
            this.ControlsPanel.Controls.Add(this.ReviewedLink);
            this.ControlsPanel.Controls.Add(this.DeleteButton);
            this.ControlsPanel.Controls.Add(this.PleaseReviewLink);
            this.ControlsPanel.Controls.Add(this.KeyEditLabel);
            this.ControlsPanel.Controls.Add(this.ApplyChangeButton);
            this.ControlsPanel.Controls.Add(this.AddAllButton);
            this.ControlsPanel.Controls.Add(this.TranslateCommentEditLabel);
            this.ControlsPanel.Controls.Add(this.KeyEdit);
            this.ControlsPanel.Controls.Add(this.TranslateCommentEdit);
            this.ControlsPanel.Controls.Add(this.ValueEdit);
            this.ControlsPanel.Controls.Add(this.MasterCommentEditLabel);
            this.ControlsPanel.Controls.Add(this.ValueEditLabel);
            this.ControlsPanel.Controls.Add(this.MasterCommentEdit);
            this.ControlsPanel.Location = new System.Drawing.Point(684, 114);
            this.ControlsPanel.Name = "ControlsPanel";
            this.ControlsPanel.Size = new System.Drawing.Size(341, 411);
            this.ControlsPanel.TabIndex = 19;
            this.ControlsPanel.Visible = false;
            // 
            // ApplySingleMasterButton
            // 
            this.ApplySingleMasterButton.Location = new System.Drawing.Point(9, 379);
            this.ApplySingleMasterButton.Name = "ApplySingleMasterButton";
            this.ApplySingleMasterButton.Size = new System.Drawing.Size(106, 29);
            this.ApplySingleMasterButton.TabIndex = 25;
            this.ApplySingleMasterButton.Text = "Apply Single";
            this.ApplySingleMasterButton.UseVisualStyleBackColor = true;
            this.ApplySingleMasterButton.Click += new System.EventHandler(this.ApplySingleMasterButton_Click);
            // 
            // ApplyChangeButton2
            // 
            this.ApplyChangeButton2.Location = new System.Drawing.Point(9, 365);
            this.ApplyChangeButton2.Name = "ApplyChangeButton2";
            this.ApplyChangeButton2.Size = new System.Drawing.Size(106, 29);
            this.ApplyChangeButton2.TabIndex = 24;
            this.ApplyChangeButton2.Text = "Apply Single";
            this.ApplyChangeButton2.UseVisualStyleBackColor = true;
            this.ApplyChangeButton2.Click += new System.EventHandler(this.ApplyChangeButton2_Click);
            // 
            // PleaseReviewLink2
            // 
            this.PleaseReviewLink2.AutoSize = true;
            this.PleaseReviewLink2.Location = new System.Drawing.Point(234, 255);
            this.PleaseReviewLink2.Name = "PleaseReviewLink2";
            this.PleaseReviewLink2.Size = new System.Drawing.Size(95, 17);
            this.PleaseReviewLink2.TabIndex = 23;
            this.PleaseReviewLink2.TabStop = true;
            this.PleaseReviewLink2.Text = "Please review";
            this.PleaseReviewLink2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PleaseReviewLink2_click);
            // 
            // DoNotTranslateLink
            // 
            this.DoNotTranslateLink.AutoSize = true;
            this.DoNotTranslateLink.Location = new System.Drawing.Point(119, 255);
            this.DoNotTranslateLink.Name = "DoNotTranslateLink";
            this.DoNotTranslateLink.Size = new System.Drawing.Size(109, 17);
            this.DoNotTranslateLink.TabIndex = 22;
            this.DoNotTranslateLink.TabStop = true;
            this.DoNotTranslateLink.Text = "Do not translate";
            this.DoNotTranslateLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // PleaseTranslateLink
            // 
            this.PleaseTranslateLink.AutoSize = true;
            this.PleaseTranslateLink.Location = new System.Drawing.Point(3, 255);
            this.PleaseTranslateLink.Name = "PleaseTranslateLink";
            this.PleaseTranslateLink.Size = new System.Drawing.Size(110, 17);
            this.PleaseTranslateLink.TabIndex = 21;
            this.PleaseTranslateLink.TabStop = true;
            this.PleaseTranslateLink.Text = "Please translate";
            this.PleaseTranslateLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // ReviewedLink
            // 
            this.ReviewedLink.AutoSize = true;
            this.ReviewedLink.Location = new System.Drawing.Point(104, 152);
            this.ReviewedLink.Name = "ReviewedLink";
            this.ReviewedLink.Size = new System.Drawing.Size(69, 17);
            this.ReviewedLink.TabIndex = 20;
            this.ReviewedLink.TabStop = true;
            this.ReviewedLink.Text = "Reviewed";
            this.ReviewedLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // PleaseReviewLink
            // 
            this.PleaseReviewLink.AutoSize = true;
            this.PleaseReviewLink.Location = new System.Drawing.Point(3, 152);
            this.PleaseReviewLink.Name = "PleaseReviewLink";
            this.PleaseReviewLink.Size = new System.Drawing.Size(95, 17);
            this.PleaseReviewLink.TabIndex = 19;
            this.PleaseReviewLink.TabStop = true;
            this.PleaseReviewLink.Text = "Please review";
            this.PleaseReviewLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "resx";
            this.openFileDialog.FileName = "*Strings.Resx";
            this.openFileDialog.Filter = "Resx Files|*.resx";
            this.openFileDialog.Title = "Open Master RESX File";
            // 
            // PasteJSButton
            // 
            this.PasteJSButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PasteJSButton.Location = new System.Drawing.Point(806, 77);
            this.PasteJSButton.Name = "PasteJSButton";
            this.PasteJSButton.Size = new System.Drawing.Size(91, 31);
            this.PasteJSButton.TabIndex = 22;
            this.PasteJSButton.Text = "Paste JS";
            this.PasteJSButton.UseVisualStyleBackColor = true;
            this.PasteJSButton.Visible = false;
            this.PasteJSButton.Click += new System.EventHandler(this.PasteJSButton_Click);
            // 
            // PasteTddButton
            // 
            this.PasteTddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PasteTddButton.Location = new System.Drawing.Point(920, 77);
            this.PasteTddButton.Name = "PasteTddButton";
            this.PasteTddButton.Size = new System.Drawing.Size(91, 31);
            this.PasteTddButton.TabIndex = 23;
            this.PasteTddButton.Text = "Paste TDD";
            this.PasteTddButton.UseVisualStyleBackColor = true;
            this.PasteTddButton.Visible = false;
            this.PasteTddButton.Click += new System.EventHandler(this.PasteTddButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 796);
            this.Controls.Add(this.PasteTddButton);
            this.Controls.Add(this.PasteJSButton);
            this.Controls.Add(this.ControlsPanel);
            this.Controls.Add(this.NewButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "String Resource Editor";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ControlsPanel.ResumeLayout(false);
            this.ControlsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Button ApplyChangeButton;
        private System.Windows.Forms.Button AddAllButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox KeyEdit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Label KeyEditLabel;
        private System.Windows.Forms.TextBox ValueEdit;
        private System.Windows.Forms.Label ValueEditLabel;
        private System.Windows.Forms.TextBox MasterCommentEdit;
        private System.Windows.Forms.Label MasterCommentEditLabel;
        private System.Windows.Forms.Label TranslateCommentEditLabel;
        private System.Windows.Forms.TextBox TranslateCommentEdit;
        private System.Windows.Forms.Panel ControlsPanel;
        private System.Windows.Forms.LinkLabel PleaseReviewLink;
        private System.Windows.Forms.LinkLabel ReviewedLink;
        private System.Windows.Forms.LinkLabel PleaseTranslateLink;
        private System.Windows.Forms.LinkLabel DoNotTranslateLink;
        private System.Windows.Forms.LinkLabel PleaseReviewLink2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ApplyChangeButton2;
        private System.Windows.Forms.CheckBox GenerateMissingCheckbox;
        private System.Windows.Forms.Button ApplySingleMasterButton;
        private System.Windows.Forms.Button PasteJSButton;
        private System.Windows.Forms.Button PasteTddButton;
    }
}

