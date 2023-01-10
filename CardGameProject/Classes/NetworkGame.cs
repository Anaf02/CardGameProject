using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGameProject.Classes
{
    internal class NetworkGame : Game
    {
        private Client client;
        private readonly string playerName;

        public int MyPlayer { get; set; }

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
            string data = $"bet!{GetPlayer().LastBet - GetPlayer(true).LastBet}";
            client.Write(data);
            HandleNetworkRead();
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
            client.Write($"draw!{currentPlayer.CardKept}");
            HandleNetworkRead();
        }

        public override void btnJunk_Click(object sender, EventArgs e)
        {
            base.btnJunk_Click(sender, e);
            string data = $"junk!{GetPlayer()}";
            client.Write(data);
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
            CreateDeck();

            var cards = Deck.Select(x => x.Value).ToList();
            var cardsString = "cards!";

            for (int i = 0; i < cards.Count; i++)
            {
                if (i == cards.Count - 1)
                {
                    cardsString += cards[i].ToString();
                }
                else
                {
                    cardsString += $"{cards[i]},";
                }
            }

            client.Write(cardsString);

            InitialPhase();
        }

        protected override void btnNewGame_Click(object sender, EventArgs e)
        {
            base.btnNewGame_Click(sender, e);
        }

        protected override void InitialPhase()
        {
            base.InitialPhase();
            table.DisplayNames(One.Name, Two.Name);
            playerTurn = 1;
            table.DisplayCurrentPlayerTurn(playerTurn);

            if(playerTurn != MyPlayer)
            {
                HandleNetworkRead();
            }
        }

        private void HandleNetworkRead()
        {
            string receivedData = client.Read();
            string[] components = receivedData.Split('!');

            switch (components[0])
            {
                case "name":
                    if (Convert.ToInt32(components[1]) == 1)
                    {
                        MyPlayer = 2;
                        Two = new Player(playerName);
                        One = new Player(components[2]);
                    }
                    else
                    {
                        One = new Player(playerName);
                        Two = new Player(components[2]);
                        MyPlayer = 1;
                    }
                    break;

                case "start":
                    StartGame();
                    break;

                case "cards":
                    var cards = components[1].Split(',');
                    Deck = new Stack<CardBase>();
                    Deck.Clear();
                    DiscardPile = new Stack<CardBase>();

                    foreach (var card in cards.Reverse())
                    {
                        var value = Convert.ToInt32(card);
                        if (value < 0)
                        {
                            Deck.Push(CardFactory.GenerateCard(Math.Abs(value), CardColour.Red));
                        }
                        else
                        {
                            Deck.Push(CardFactory.GenerateCard(Math.Abs(value), CardColour.Green));
                        }
                    }
                    InitialPhase();
                    break;

                case "bet":
                    currentPlayer = GetPlayer();
                    var opposingPlayer = GetPlayer(true);
                    currentPlayer.BetMoney(Convert.ToInt32(components[1]));
                    table.DisplayWallets(One, Two);
                    MainPot += Convert.ToInt32(components[1]);
                    table.DisplayMainPot(MainPot);

                    GetPlayer(true).ActionPerformed = false;

                    ChangePlayerTurn();

                    if (AllPlayersPerformedActions())
                    {
                        ChangeGamePhase();
                    }
                    break;

                case "draw":
                    currentPlayer = GetPlayer();

                    currentPlayer.Hand.Add(Deck.Pop());
                    table.DisplayHands(One.Hand, Two.Hand);

                    if (components[1] == "False")
                    {
                        DiscardPile.Push(currentPlayer.Hand.Last());
                        currentPlayer.Hand.RemoveAt(currentPlayer.Hand.Count - 1);
                        currentPlayer.CardKept = false;
                    }
                    else
                    {
                        currentPlayer.CardKept = true;
                    }

                    table.DisplayHands(One.Hand, Two.Hand);
                    table.DisplayDiscardPile(DiscardPile.Peek());

                    ChangePlayerTurn();

                    if (AllPlayersPerformedActions())
                    {
                        ChangeGamePhase();
                    }

                    break;
                case "junk":

                    break;

                default:
                    break;
            }
        }
    }
}