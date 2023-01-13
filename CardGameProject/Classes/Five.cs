using CardGameProject.Properties;
using System.Drawing;

namespace CardGameProject.Classes
{
    internal class Five : CardBase
    {
        public Five(CardColour colour) : base(colour, 5)
        {
        }

        public override Image GetImage(bool front)
        {
            if (front)
            {
                if (colour == CardColour.Green)
                {
                    return Resources.card_5g;
                }
                else
                {
                    return Resources.card_5r;
                }
            }
            else
            {
                return cardBack;
            }
        }
    }
}