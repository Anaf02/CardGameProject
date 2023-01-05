using System;
using System.Windows.Forms;

namespace CardGameProject.Forms
{
    public partial class BetDialog : Form
    {
        public int BetValue { get; set; }

        public BetDialog(int minValue, int maxValue)
        {
            InitializeComponent();
            numericUpDownBet.Maximum = maxValue;
            numericUpDownBet.Minimum = minValue;
            trackBarBet.Maximum = maxValue / trackBarBet.TickFrequency;
            trackBarBet.Minimum = minValue / trackBarBet.TickFrequency;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void trackBarBet_Scroll(object sender, EventArgs e)
        {
            BetValue = trackBarBet.Value * trackBarBet.TickFrequency;
            numericUpDownBet.Value = BetValue;
        }

        private void numericUpDownBet_ValueChanged(object sender, EventArgs e)
        {
            BetValue = Convert.ToInt32(numericUpDownBet.Value);
            trackBarBet.Value = BetValue / trackBarBet.TickFrequency;
        }
    }
}