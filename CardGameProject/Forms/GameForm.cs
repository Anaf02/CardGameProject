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

        public GameForm(bool isNetwork = false)
        {
            InitializeComponent();
            table = new Table(this.Size);
            table.Location = new Point(0, 0);
            this.Controls.Add(table);

            if (isNetwork)
            {
                var connectionScreen = new ConnectionScreen();

                if (connectionScreen.ShowDialog() == DialogResult.OK)
                {
                    Client client = new Client();
                    client.Connect(connectionScreen.IpAddress, connectionScreen.Port);
                    client.Write(connectionScreen.PlayerName);
                    game = new NetworkGame(table, client, connectionScreen.PlayerName);
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                game = new Game(table);
            }
        }
    }
   
}
