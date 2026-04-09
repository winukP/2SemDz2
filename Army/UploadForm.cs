using System;

namespace Army
{
    public partial class UploadForm : Form
    {
        public string SelectedFormat { get; set; }
        public UploadForm()
        {
            InitializeComponent();
        }

        private void XML_Click(object sender, EventArgs e)
        {
            SelectedFormat = "XML";
            DialogResult = DialogResult.OK;
            Close();
        }

        private void JSON_Click(object sender, EventArgs e)
        {
            SelectedFormat = "JSON";
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
