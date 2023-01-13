using System.Collections.Generic;

namespace CardGameProject.Classes
{
    internal class Player
    {
        public string Name { get; }
        public int Wallet { get; private set; }
        public List<CardBase> Hand { get; private set; }
        public bool ActionPerformed { get; set; }

        public int LastBet { get; private set; }

        public bool CardKept { get; set; }

        public int SwapedCardIndex { get; set; }

        public Player(string name)
        {
            Name = name;
            Wallet = 5000;
            Hand = new List<CardBase>();
            LastBet = 0;
        }

        public void AddMoney(int value)
        {
            Wallet += value;
        }

        public int BetMoney(int value)
        {
            LastBet += value;

            if (Wallet - value < 0)
            {
                value = Wallet;
                Wallet = 0;
            }
            else
            {
                Wallet -= value;
            }

            return value;
        }

        public void ResetLastBet()
        {
            LastBet = 0;
        }
    }
}