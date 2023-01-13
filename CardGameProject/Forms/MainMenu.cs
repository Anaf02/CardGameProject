using System;
using System.Windows.Forms;

namespace CardGameProject.Forms
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
        }

        private void rules_btn_Click(object sender, EventArgs e)
        {
            var rulesForm = new RulesForm();
            rulesForm.Show();
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            var gameForm = new GameForm();
            gameForm.FormClosed += reshow_main_menu;
            gameForm.Show();
            this.Hide();
        }

        private void reshow_main_menu(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btnLan_Click(object sender, EventArgs e)
        {
            var gameForm = new GameForm(true);
            if (!gameForm.IsDisposed)
            {
                gameForm.FormClosed += reshow_main_menu;
                gameForm.Show();
                this.Hide();
            }
        }
    }
}