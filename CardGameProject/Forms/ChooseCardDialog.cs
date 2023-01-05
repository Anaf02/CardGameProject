using System;
using System.Windows.Forms;

namespace CardGameProject.Forms
{
    public partial class ChooseCardDialog : Form
    {
        public int CardId { get; set; }

        public ChooseCardDialog(int maxValue)
        {
            InitializeComponent();

            numericUpDownCardId.Maximum = maxValue;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CardId = Convert.ToInt32(numericUpDownCardId.Value);
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}