using CardGameProject.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CardGameProject.Classes
{
    internal class Game
    {
        private readonly Table table;
        private Stack<CardBase> Deck;
        private Stack<CardBase> DiscardPile;
        private int SabaccPot = 0;
        private int MainPot = 0;
        private Player One, Two;
        private GamePhase currentPhase;
        private int currentRound;
        private int playerTurn;

        public Game(Table table)
        {
            this.table = table;
            table.newGame_btn.Click += newGame_btn_Click;
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

        private void newGame_btn_Click(object sender, EventArgs e)
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
        }

        private void InitialPhase()
        {
            currentPhase = GamePhase.Play;
            currentRound = 1;
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
                    currentRound = currentRound < 3 ? currentRound + 1 : currentRound;
                    if(currentRound == 3)
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
        }

        private void ChangePlayerTurn()
        {
            playerTurn = playerTurn == 1 ? 2 : 1;
        }
    }
}