using CardGameProject.Classes;
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
    public partial class GameForm : Form
    {
        private readonly Table table;
        private readonly Game game;

        public GameForm()
        {
            InitializeComponent();
            table = new Table(this.Size);
            table.Location = new Point(0, 0);
            this.Controls.Add(table);

            game = new Game(table);
        }
    }
   
}
