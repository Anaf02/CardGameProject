using System;
using System.Windows.Forms;

namespace CardGameProject.Forms
{
    public partial class NameDialog : Form
    {
        public string Player1Name { get; set; }
        public string Player2Name { get; set; }

        public NameDialog()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Player1Name = textBoxP1.Text;
            Player2Name = textBoxP2.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}