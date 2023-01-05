using CardGameProject.Properties;
using System;
using System.Drawing;
using System.Security;

namespace CardGameProject.Classes
{
    internal abstract class CardBase
    {
        public CardColour colour;

        public int Value { get; private set; }

        protected Image cardBack = Resources.card_back;

        public CardBase(CardColour colour, int value)
        {
            this.colour = colour;
            if (colour == CardColour.Red)
            {
                Value = -value;
            }
            else
            {
                if (colour == CardColour.Green)
                {
                    Value = value;
                }
                else
                {
                    throw new ArgumentException("Colour is invalid");
                }
            }
        }

        public abstract Image GetImage(bool front);
    }
}