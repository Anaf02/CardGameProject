using CardGameProject.Classes;
using System;
using System.Windows.Forms;

namespace CardGameProject.Forms
{
    public partial class DiceResultDialog : Form
    {
        public DiceResultDialog(int dice1, int dice2)
        {
            InitializeComponent();
            pictureBox1.Image = Dice.GetImage(dice1);
            pictureBox2.Image = Dice.GetImage(dice2);
            if (dice1 == dice2)
            {
                labelDiceInfoMessage.Text = "Hands must be discarded. Players will draw the same amount of cards they had";
            }
            else
            {
                labelDiceInfoMessage.Text = "The numbers are different, no changes will happen";
            }

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Close();
        }
    }
}