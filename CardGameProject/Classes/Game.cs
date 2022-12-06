using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProject.Classes
{
    internal class Game
    {
        private Stack<CardBase> Deck;
        private Stack<CardBase> DiscardPile;
        private decimal SabaccPot = 0;
        private decimal MainPot = 0;


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
            Deck = ShuffleDeck(Deck);
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
    }
}
