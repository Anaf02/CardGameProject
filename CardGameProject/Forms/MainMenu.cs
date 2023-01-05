using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var gameForm=new GameForm();
            gameForm.FormClosed+=reshow_main_menu;
            gameForm.Show();
            this.Hide();
        }

        private void reshow_main_menu(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}
