namespace Army
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Upload = new Button();
            Tree = new TreeView();
            splitContainer1 = new SplitContainer();
            pictureBox1 = new PictureBox();
            TreeText = new Label();
            pictureBox2 = new PictureBox();
            Table = new DataGridView();
            Close1 = new Button();
            Show1 = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Table).BeginInit();
            SuspendLayout();
            // 
            // Upload
            // 
            Upload.BackColor = SystemColors.ControlLight;
            Upload.Location = new Point(3, 3);
            Upload.Name = "Upload";
            Upload.Size = new Size(106, 42);
            Upload.TabIndex = 0;
            Upload.Text = "Загрузить";
            Upload.UseVisualStyleBackColor = false;
            Upload.Click += Upload_Click;
            // 
            // Tree
            // 
            Tree.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Tree.Location = new Point(0, 159);
            Tree.Name = "Tree";
            Tree.Size = new Size(205, 364);
            Tree.TabIndex = 1;
            Tree.AfterSelect += Tree_AfterSelect;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            splitContainer1.Panel1.Controls.Add(TreeText);
            splitContainer1.Panel1.Controls.Add(Tree);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pictureBox2);
            splitContainer1.Panel2.Controls.Add(Table);
            splitContainer1.Panel2.Controls.Add(Close1);
            splitContainer1.Panel2.Controls.Add(Show1);
            splitContainer1.Panel2.Controls.Add(Upload);
            splitContainer1.Size = new Size(889, 523);
            splitContainer1.SplitterDistance = 205;
            splitContainer1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(0, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(205, 124);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // TreeText
            // 
            TreeText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TreeText.BackColor = SystemColors.ControlLight;
            TreeText.Font = new Font("Segoe UI", 9F);
            TreeText.Location = new Point(3, 3);
            TreeText.Name = "TreeText";
            TreeText.Size = new Size(202, 20);
            TreeText.TabIndex = 3;
            TreeText.Text = "Армия";
            TreeText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(339, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(338, 42);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // Table
            // 
            Table.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Table.Location = new Point(0, 51);
            Table.Name = "Table";
            Table.RowHeadersWidth = 51;
            Table.Size = new Size(680, 448);
            Table.TabIndex = 3;
            // 
            // Close1
            // 
            Close1.Location = new Point(227, 3);
            Close1.Name = "Close1";
            Close1.Size = new Size(106, 42);
            Close1.TabIndex = 2;
            Close1.Text = "Закрыть";
            Close1.UseVisualStyleBackColor = true;
            Close1.Click += Close1_Click;
            // 
            // Show1
            // 
            Show1.Location = new Point(115, 3);
            Show1.Name = "Show1";
            Show1.Size = new Size(106, 42);
            Show1.TabIndex = 1;
            Show1.Text = "Показать";
            Show1.UseVisualStyleBackColor = true;
            Show1.Click += Show1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(889, 523);
            Controls.Add(splitContainer1);
            Name = "MainForm";
            Text = "MainForm";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)Table).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button Upload;
        private TreeView Tree;
        private SplitContainer splitContainer1;
        private Button Close1;
        private Button Show1;
        private Label TreeText;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        protected DataGridView Table;
    }
}
