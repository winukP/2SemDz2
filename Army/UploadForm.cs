using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
