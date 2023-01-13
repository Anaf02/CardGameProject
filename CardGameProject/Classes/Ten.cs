using CardGameProject.Properties;
using System.Drawing;

namespace CardGameProject.Classes
{
    internal class Ten : CardBase
    {
        public Ten(CardColour colour) : base(colour, 10)
        {
        }

        public override Image GetImage(bool front)
        {
            if (front)
            {
                if (colour == CardColour.Green)
                {
                    return Resources.card_10g;
                }
                else
                {
                    return Resources.card_10r;
                }
            }
            else
            {
                return cardBack;
            }
        }
    }
}