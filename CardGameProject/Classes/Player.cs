using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProject.Classes
{
    internal class Player
    {
        public string Name { get; }
        public int Wallet { get; private set; }
        public List<CardBase> Hand { get; private set; }
        public bool ActionPerformed { get; set; }

        public Player(string name)
        {
            Name = name;
            Wallet = 5000;
            Hand = new List<CardBase>();
        }

        public void AddMoney(int value)
        {
            Wallet += value;
        }
        public void BetMoney(int value)
        {
            Wallet -= value;
        }
    }
}
