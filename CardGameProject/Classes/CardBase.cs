using CardGameProject.Properties;
using System;
using System.Drawing;

namespace CardGameProject.Classes
{
    internal abstract class CardBase
    {
        public CardColour colour;
        public int value { get; set; }

        protected Image cardBack = Resources.card_back;

        public CardBase(CardColour colour, int value)
        {
            this.colour = colour;
            if (colour == CardColour.Red)
            {
                this.value = -value;
            }
            else
            {
                if (colour == CardColour.Green)
                {
                    this.value = value;
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