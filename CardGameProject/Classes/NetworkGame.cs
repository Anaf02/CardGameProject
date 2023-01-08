using CardGameProject.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProject.Classes
{
    internal class NetworkGame : Game
    {

        private Client client;
        private readonly string playerName;

        public NetworkGame(Table table, Client client, string playerName) : base(table)
        {
            table.btnNewGame.Hide();
            this.client = client;
            this.playerName = playerName;
            HandleNetworkRead();
            HandleNetworkRead();
        }

        public override void btnBet_Click(object sender, EventArgs e)
        {
            base.btnBet_Click(sender, e);
        }

        public override void btnCall_Click(object sender, EventArgs e)
        {
            base.btnCall_Click(sender, e);
        }

        public override void btnCheck_Click(object sender, EventArgs e)
        {
            base.btnCheck_Click(sender, e);
        }

        public override void btnDrawCard_Click(object sender, EventArgs e)
        {
            base.btnDrawCard_Click(sender, e);
        }

        public override void btnJunk_Click(object sender, EventArgs e)
        {
            base.btnJunk_Click(sender, e);
        }

        public override void btnRollDice_Click(object sender, EventArgs e)
        {
            base.btnRollDice_Click(sender, e);
        }

        public override void btnStand_Click(object sender, EventArgs e)
        {
            base.btnStand_Click(sender, e);
        }

        public override void btnSwapFromDiscardPile_Click(object sender, EventArgs e)
        {
            base.btnSwapFromDiscardPile_Click(sender, e);
        }

        public override void btnSwapFromDrawPile_Click(object sender, EventArgs e)
        {
            base.btnSwapFromDrawPile_Click(sender, e);
        }

        public override void btnWinPlayer1_Click(object sender, EventArgs e)
        {
            base.btnWinPlayer1_Click(sender, e);
        }

        public override void btnWinPlayer2_Click(object sender, EventArgs e)
        {
            base.btnWinPlayer2_Click(sender, e);
        }

        public override void CreateDeck()
        {
            base.CreateDeck();
        }

        public override void StartGame()
        {
            base.StartGame();
        }

        protected override void btnNewGame_Click(object sender, EventArgs e)
        {
            base.btnNewGame_Click(sender, e);
        }

        protected override void InitialPhase()
        {
            base.InitialPhase();
        }

        private void HandleNetworkRead()
        {
            string receivedData = client.Read();
            string[] components = receivedData.Split('-');
            
            switch (components[0])
            {
                case "name":
                    table.DisplayNames(playerName, components[1]);
                    One = new Player(playerName);
                    Two = new Player(components[1]);
                    break;
                case "start":
                    StartGame();
                    break;
                case "cards":
                    break;
                default:
                    break;
            }
        }
    }
}
