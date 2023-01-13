using CardGameProject.Forms;
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
            if (currentPlayer.Wallet > 0)
            {
                string data = $"bet!{GetMyPlayer().LastBet - GetOpposingPlayer().LastBet}";
                client.Write(data);
                table.Refresh();
                HandleNetworkRead();
            }
        }

        public override void btnCall_Click(object sender, EventArgs e)
        {
            base.btnCall_Click(sender, e);
            client.Write("call");
            table.Refresh();
            HandleNetworkRead();
        }

        public override void btnCheck_Click(object sender, EventArgs e)
        {
            base.btnCheck_Click(sender, e);
            if (One.LastBet == Two.LastBet || GetMyPlayer().Wallet == 0)
            {
                client.Write("check");
                table.Refresh();
                HandleNetworkRead();
            }
        }

        public override void btnDrawCard_Click(object sender, EventArgs e)
        {
            base.btnDrawCard_Click(sender, e);
            string data = $"draw!{GetMyPlayer().CardKept}";
            client.Write(data);
            table.Refresh();
            HandleNetworkRead();
        }

        public override void btnJunk_Click(object sender, EventArgs e)
        {
            base.btnJunk_Click(sender, e);
            string data = $"junk!{MyPlayer}";
            client.Write(data);
        }

        public override void btnRollDice_Click(object sender, EventArgs e)
        {
            base.btnRollDice_Click(sender, e);
            string data = $"rollDice!{firstDice},{secondDice}";
            client.Write(data);
            table.Refresh();
            HandleNetworkRead();
        }

        public override void btnStand_Click(object sender, EventArgs e)
        {
            base.btnStand_Click(sender, e);
            string data = $"stand!{MyPlayer}";
            client.Write(data);
            table.Refresh();
            HandleNetworkRead();
        }

        public override void btnSwapFromDiscardPile_Click(object sender, EventArgs e)
        {
            base.btnSwapFromDiscardPile_Click(sender, e);
            string data = $"swapDiscard!{GetMyPlayer().SwapedCardIndex}";
            client.Write(data);
            table.Refresh();
            HandleNetworkRead();
        }

        public override void btnSwapFromDrawPile_Click(object sender, EventArgs e)
        {
            base.btnSwapFromDrawPile_Click(sender, e);
            string data = $"swapDraw!{GetMyPlayer().SwapedCardIndex}";
            client.Write(data);
            table.Refresh();
            HandleNetworkRead();
        }

        public override void btnWinPlayer1_Click(object sender, EventArgs e)
        {
            base.btnWinPlayer1_Click(sender, e);
            string data = $"win!1";
            client.Write(data);
            table.Refresh();
            HandleNetworkRead();
        }

        public override void btnWinPlayer2_Click(object sender, EventArgs e)
        {
            base.btnWinPlayer2_Click(sender, e);
            string data = $"win!2";
            client.Write(data);
            table.Refresh();
            HandleNetworkRead();
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

        protected override void InitialPhase()
        {
            base.InitialPhase();
            table.DisplayNames(One.Name, Two.Name);
            playerTurn = 1;
            table.DisplayCurrentPlayerTurn(playerTurn);
            table.Refresh();

            if (playerTurn != MyPlayer)
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
                    {
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
                    }

                case "start":
                    {
                        StartGame();
                        break;
                    }

                case "cards":
                    {
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
                    }

                case "bet":
                    {
                        currentPlayer = GetPlayer();
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
                    }

                case "junk":
                    {
                        GetPlayer(true).AddMoney(MainPot);
                        MainPot = 0;
                        DealCards();
                        table.DisplayHands(One.Hand, Two.Hand);
                        //table.DisplayHands(One.Hand, Two.Hand, MyPlayer);
                        table.DisplayDiscardPile(DiscardPile.Peek());
                        InitialPhase();
                        table.DisplayCurrentGamePhase(currentRound, currentPhase);
                        table.DisplaySabaccPot(SabaccPot);
                        table.DisplayMainPot(MainPot);
                        table.DisplayWallets(One, Two);
                        table.DisplayCurrentPlayerTurn(playerTurn);
                        break;
                    }

                case "call":
                    {
                        base.btnCall_Click(this, EventArgs.Empty);
                        break;
                    }

                case "stand":
                    {
                        base.btnStand_Click(this, EventArgs.Empty);
                        break;
                    }

                case "check":
                    {
                        base.btnCheck_Click(this, EventArgs.Empty);
                        break;
                    }

                case "draw":
                    {
                        currentPlayer = GetPlayer();

                        currentPlayer.Hand.Add(Deck.Pop());

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
                        //table.DisplayHands(One.Hand, Two.Hand, MyPlayer);
                        table.DisplayDiscardPile(DiscardPile.Peek());

                        ChangePlayerTurn();

                        if (AllPlayersPerformedActions())
                        {
                            ChangeGamePhase();
                        }

                        break;
                    }

                case "swapDiscard":
                    {
                        currentPlayer = GetPlayer();
                        var topDiscard = DiscardPile.Pop();
                        currentPlayer.SwapedCardIndex = Convert.ToInt32(components[1]);
                        DiscardPile.Push(currentPlayer.Hand.ElementAt(currentPlayer.SwapedCardIndex));

                        currentPlayer.Hand.RemoveAt(currentPlayer.SwapedCardIndex);
                        currentPlayer.Hand.Insert(currentPlayer.SwapedCardIndex, topDiscard);
                        ChangePlayerTurn();

                        table.DisplayHands(One.Hand, Two.Hand);
                        //table.DisplayHands(One.Hand, Two.Hand, MyPlayer);
                        table.DisplayDiscardPile(DiscardPile.Peek());
                        if (AllPlayersPerformedActions())
                        {
                            ChangeGamePhase();
                        }
                        break;
                    }

                case "swapDraw":
                    {
                        currentPlayer = GetPlayer();

                        currentPlayer.SwapedCardIndex = Convert.ToInt32(components[1]);
                        DiscardPile.Push(currentPlayer.Hand.ElementAt(currentPlayer.SwapedCardIndex));
                        currentPlayer.Hand.RemoveAt(currentPlayer.SwapedCardIndex);
                        currentPlayer.Hand.Insert(currentPlayer.SwapedCardIndex, Deck.Pop());
                        ChangePlayerTurn();

                        table.DisplayHands(One.Hand, Two.Hand);
                        //table.DisplayHands(One.Hand, Two.Hand, MyPlayer);
                        table.DisplayDiscardPile(DiscardPile.Peek());
                        if (AllPlayersPerformedActions())
                        {
                            ChangeGamePhase();
                        }
                        break;
                    }

                case "rollDice":
                    {
                        var dice = components[1].Split(',');
                        firstDice = Convert.ToInt32(dice[0]);
                        secondDice = Convert.ToInt32(dice[1]);

                        var diceResultDialog = new DiceResultDialog(firstDice, secondDice);
                        diceResultDialog.ShowDialog();

                        if (firstDice == secondDice)
                        {
                            var player1HandCount = One.Hand.Count;
                            var player2HandCount = Two.Hand.Count;

                            One.Hand.ForEach(card => DiscardPile.Push(card));
                            Two.Hand.ForEach(card => DiscardPile.Push(card));
                            One.Hand.Clear();
                            Two.Hand.Clear();

                            for (int i = 0; i < player1HandCount; i++)
                            {
                                One.Hand.Add(Deck.Pop());
                            }

                            for (int i = 0; i < player2HandCount; i++)
                            {
                                Two.Hand.Add(Deck.Pop());
                            }
                            DiscardPile.Push(Deck.Pop());
                        }

                        table.DisplayHands(One.Hand, Two.Hand);
                        //table.DisplayHands(One.Hand, Two.Hand, MyPlayer);
                        table.DisplayDiscardPile(DiscardPile.Peek());
                        ChangeGamePhase();
                        break;
                    }
                case "win":
                    {
                        if (Convert.ToInt32(components[1])==1)
                        {
                            One.AddMoney(MainPot);
                            MainPot = 0;
                            if (Convert.ToInt32(components[2])==1)
                            {
                                One.AddMoney(SabaccPot);
                                SabaccPot = 0;
                            }
                        }
                        else 
                        {
                            Two.AddMoney(MainPot);
                            MainPot = 0;
                            if (Convert.ToInt32(components[2]) == 1)
                            {
                                Two.AddMoney(SabaccPot);
                                SabaccPot = 0;
                            }
                        }
                        table.DisplayMainPot(MainPot);
                        table.DisplaySabaccPot(SabaccPot);
                        table.DisplayWallets(One, Two);
                        ChangeGamePhase();
                        break;
                    }

                default:
                    break;
            }

            table.Refresh();
        }

        private Player GetMyPlayer()
        {
            return MyPlayer == 1 ? One : Two;
        }

        private Player GetOpposingPlayer()
        {
            return MyPlayer == 1 ? Two : One;
        }
    }
}