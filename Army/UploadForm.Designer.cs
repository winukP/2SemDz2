namespace Army
{
    partial class UploadForm
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
            MainText = new Label();
            XML = new Button();
            JSON = new Button();
            SuspendLayout();
            // 
            // MainText
            // 
            MainText.AutoSize = true;
            MainText.BackColor = SystemColors.Control;
            MainText.Font = new Font("Segoe UI", 15F);
            MainText.Location = new Point(28, 9);
            MainText.Name = "MainText";
            MainText.Size = new Size(197, 35);
            MainText.TabIndex = 0;
            MainText.Text = "Выбор загрузки";
            // 
            // XML
            // 
            XML.Location = new Point(73, 56);
            XML.Name = "XML";
            XML.Size = new Size(102, 43);
            XML.TabIndex = 1;
            XML.Text = "XML";
            XML.UseVisualStyleBackColor = true;
            XML.Click += XML_Click;
            // 
            // JSON
            // 
            JSON.Location = new Point(73, 105);
            JSON.Name = "JSON";
            JSON.Size = new Size(102, 43);
            JSON.TabIndex = 2;
            JSON.Text = "JSON";
            JSON.UseVisualStyleBackColor = true;
            JSON.Click += JSON_Click;
            // 
            // UploadForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(246, 179);
            Controls.Add(JSON);
            Controls.Add(XML);
            Controls.Add(MainText);
            Name = "UploadForm";
            Text = "UploadForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label MainText;
        private Button XML;
        private Button JSON;
    }
}