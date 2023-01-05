using CardGameProject.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CardGameProject.Classes
{
    internal class Game
    {
        private readonly Table table;
        private Stack<CardBase> Deck;
        private Stack<CardBase> DiscardPile;
        private int SabaccPot;
        private int MainPot;
        private Player One, Two;
        private GamePhase currentPhase;
        private int currentRound;
        private int playerTurn;
        private Player currentPlayer;
        private Random rand;

        public Game(Table table)
        {
            rand = new Random();
            this.table = table;
            AssingButtonHandlers();
        }

        public void AssingButtonHandlers()
        {
            table.btnNewGame.Click += btnNewGame_Click;
            table.btnCheck.Click += btnCheck_Click;
            table.btnBet.Click += btnBet_Click;
            table.btnCall.Click += btnCall_Click;
            table.btnJunk.Click += btnJunk_Click;
            table.btnDrawCard.Click += btnDrawCard_Click;
            table.btnStand.Click += btnStand_Click;
            table.btnSwapFromDrawPile.Click += btnSwapFromDrawPile_Click;
            table.btnSwapFromDiscardPile.Click += btnSwapFromDiscardPile_Click;
            table.btnRollDice.Click += btnRollDice_Click;
        }

        public void CreateDeck()
        {
            Deck = new Stack<CardBase>();
            for (int j = 0; j < 3; j++)
            {
                for (int i = 1; i <= 10; i++)
                {
                    Deck.Push(CardFactory.GenerateCard(i, CardColour.Green));
                    Deck.Push(CardFactory.GenerateCard(i, CardColour.Red));
                }
            }
            Deck.Push(CardFactory.GenerateCard(0, CardColour.Green));
            Deck.Push(CardFactory.GenerateCard(0, CardColour.Green));
            Deck = ShuffleDeck(ShuffleDeck(Deck));
        }

        public Stack<CardBase> ShuffleDeck(Stack<CardBase> cards)
        {
            Random rand = new Random();
            var shuffledCards = new List<CardBase>(cards);

            for (int i = 0; i < cards.Count; i++)
            {
                int randomIndex = i + rand.Next(cards.Count - i);
                var temp = shuffledCards[randomIndex];
                shuffledCards[randomIndex] = shuffledCards[i];
                shuffledCards[i] = temp;
            }

            return new Stack<CardBase>(shuffledCards);
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            var nameDialog = new NameDialog();
            var result = nameDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                table.DisplayNames(nameDialog.Player1Name, nameDialog.Player2Name);
                One = new Player(nameDialog.Player1Name);
                Two = new Player(nameDialog.Player2Name);
                this.StartGame();
            }
        }

        public void DealCards()
        {
            One.Hand.Clear();
            Two.Hand.Clear();
            for (int i = 0; i < 2; i++)
            {
                One.Hand.Add(Deck.Pop());
                Two.Hand.Add(Deck.Pop());
            }
            DiscardPile.Push(Deck.Pop());
        }

        public void StartGame()
        {
            DiscardPile = new Stack<CardBase>();
            CreateDeck();
            DealCards();
            table.DisplayHands(One.Hand, Two.Hand);
            table.DisplayDiscardPile(DiscardPile.Peek());
            InitialPhase();
            Random r = new Random();
            playerTurn = r.Next(1, 3);
            table.DisplayCurrentGamePhase(currentRound, currentPhase);
            table.DisplaySabaccPot(SabaccPot);
            table.DisplayMainPot(MainPot);
            table.DisplayWallets(One, Two);
            table.DisplayCurrentPlayerTurn(playerTurn);
        }

        private void InitialPhase()
        {
            currentPhase = GamePhase.Play;
            currentRound = 1;
            One.BetMoney(150);
            Two.BetMoney(150);
            SabaccPot += 100;
            MainPot += 200;
            One.ResetLastBet();
            Two.ResetLastBet();
        }

        private void ChangeGamePhase()
        {
            switch (currentPhase)
            {
                case GamePhase.Bet:
                    currentPhase = GamePhase.Spike;
                    break;

                case GamePhase.Play:
                    currentPhase = GamePhase.Bet;
                    break;

                case GamePhase.Spike:
                    currentRound = currentRound <= 3 ? currentRound + 1 : currentRound;
                    if (currentRound == 4)
                    {
                        currentPhase = GamePhase.Reveal;
                    }
                    else
                    {
                        currentPhase = GamePhase.Play;
                    }
                    break;

                case GamePhase.Reveal:
                    InitialPhase();
                    break;

                default:
                    break;
            }
            One.ActionPerformed = false; 
            Two.ActionPerformed = false;
            table.DisplayCurrentGamePhase(currentRound, currentPhase);
        }

        private void ChangePlayerTurn()
        {
            GetPlayer().ActionPerformed = true;
            playerTurn = playerTurn == 1 ? 2 : 1;
            table.DisplayCurrentPlayerTurn(playerTurn);
        }

        private Player GetPlayer(bool opposingPlayer = false)
        {
            if (!opposingPlayer)
            {
                switch (playerTurn)
                {
                    case 1:
                        return One;

                    case 2:
                        return Two;

                    default:
                        throw new ArgumentNullException(nameof(playerTurn));
                }
            }
            else
            {
                switch (playerTurn)
                {
                    case 1:
                        return Two;

                    case 2:
                        return One;

                    default:
                        throw new ArgumentNullException(nameof(playerTurn));
                }
            }
        }

        private bool AllPlayersPerformedActions()
        {
            return One.ActionPerformed && Two.ActionPerformed;
        }

        public void btnBet_Click(object sender, EventArgs e)
        {
            currentPlayer = GetPlayer();
            var opposingPlayer = GetPlayer(true);
            var betDialog = new BetDialog(opposingPlayer.LastBet != 0 ? opposingPlayer.LastBet - currentPlayer.LastBet : 50, currentPlayer.Wallet);
            var result = betDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                currentPlayer.BetMoney(betDialog.BetValue);
                table.DisplayWallets(One, Two);
                MainPot += betDialog.BetValue;
                table.DisplayMainPot(MainPot);

                GetPlayer(true).ActionPerformed = false;

                ChangePlayerTurn();
            }

            if (AllPlayersPerformedActions())
            {
                ChangeGamePhase();
            }
        }

        public void btnCall_Click(object sender, EventArgs e)
        {
            currentPlayer = GetPlayer();
            var opposingPlayer = GetPlayer(true);

            if (opposingPlayer.LastBet != 0)
            {
                currentPlayer.BetMoney(opposingPlayer.LastBet - currentPlayer.LastBet);
                table.DisplayWallets(One, Two);
                MainPot += opposingPlayer.LastBet - currentPlayer.LastBet;
                table.DisplayMainPot(MainPot);

                GetPlayer(true).ActionPerformed = false;
            }

            ChangePlayerTurn();

            if (AllPlayersPerformedActions())
            {
                ChangeGamePhase();
            }
        }

        public void btnJunk_Click(object sender, EventArgs e)
        {
            GetPlayer(true).AddMoney(MainPot);
            MainPot = 0;
            DealCards();
            table.DisplayHands(One.Hand, Two.Hand);
            table.DisplayDiscardPile(DiscardPile.Peek());
            InitialPhase();
            Random r = new Random();
            playerTurn = r.Next(1, 3);
            table.DisplayCurrentGamePhase(currentRound, currentPhase);
            table.DisplaySabaccPot(SabaccPot);
            table.DisplayMainPot(MainPot);
            table.DisplayWallets(One, Two);
            table.DisplayCurrentPlayerTurn(playerTurn);
        }

        public void btnDrawCard_Click(object sender, EventArgs e)
        {
            currentPlayer = GetPlayer();

            currentPlayer.Hand.Add(Deck.Pop());
            table.DisplayHands(One.Hand, Two.Hand);

            if (MessageBox.Show("Do you want to keep the card? ", "Keep Card", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                DiscardPile.Push(currentPlayer.Hand.Last());
                currentPlayer.Hand.RemoveAt(currentPlayer.Hand.Count - 1);
            }

            table.DisplayHands(One.Hand, Two.Hand);
            table.DisplayDiscardPile(DiscardPile.Peek());

            ChangePlayerTurn();

            if (AllPlayersPerformedActions())
            {
                ChangeGamePhase();
            }
        }

        public void btnStand_Click(object sender, EventArgs e)
        {
            ChangePlayerTurn();

            if (AllPlayersPerformedActions())
            {
                ChangeGamePhase();
            }
        }

        public void btnCheck_Click(object sender, EventArgs e)
        {
            if (One.LastBet == Two.LastBet)
            {
                ChangePlayerTurn();

                if (AllPlayersPerformedActions())
                {
                    ChangeGamePhase();
                }
            }
        }

        public void btnSwapFromDrawPile_Click(object sender, EventArgs e)
        {
            currentPlayer = GetPlayer();
            var chosenCardDialog = new ChooseCardDialog(currentPlayer.Hand.Count);
            var result = chosenCardDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                DiscardPile.Push(currentPlayer.Hand.ElementAt(chosenCardDialog.CardId - 1));
                currentPlayer.Hand.RemoveAt(chosenCardDialog.CardId - 1);
                currentPlayer.Hand.Insert(chosenCardDialog.CardId - 1, Deck.Pop());
                ChangePlayerTurn();
            }
            table.DisplayHands(One.Hand, Two.Hand);
            table.DisplayDiscardPile(DiscardPile.Peek());
            if (AllPlayersPerformedActions())
            {
                ChangeGamePhase();
            }
        }

        public void btnSwapFromDiscardPile_Click(object sender, EventArgs e)
        {
            currentPlayer = GetPlayer();
            var chosenCardDialog = new ChooseCardDialog(currentPlayer.Hand.Count);
            var result = chosenCardDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var topDiscard = DiscardPile.Pop();
                DiscardPile.Push(currentPlayer.Hand.ElementAt(chosenCardDialog.CardId - 1));
                currentPlayer.Hand.RemoveAt(chosenCardDialog.CardId - 1);
                currentPlayer.Hand.Insert(chosenCardDialog.CardId - 1, topDiscard);
                ChangePlayerTurn();
            }
            table.DisplayHands(One.Hand, Two.Hand);
            table.DisplayDiscardPile(DiscardPile.Peek());
            if (AllPlayersPerformedActions())
            {
                ChangeGamePhase();
            }
        }

        public void btnRollDice_Click(object sender, EventArgs e)
        {
            One.ResetLastBet();
            Two.ResetLastBet();

            var firstDice = rand.Next(1, 7);
            var secondDice = rand.Next(1, 7);

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
            table.DisplayDiscardPile(DiscardPile.Peek());
            ChangeGamePhase();
        }
    }
}