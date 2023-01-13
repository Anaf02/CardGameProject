using CardGameProject.Properties;
using System.Drawing;

namespace CardGameProject.Classes
{
    internal class Eight : CardBase
    {
        public Eight(CardColour colour) : base(colour, 8)
        {
        }

        public override Image GetImage(bool front)
        {
            if (front)
            {
                if (colour == CardColour.Green)
                {
                    return Resources.card_8g;
                }
                else
                {
                    return Resources.card_8r;
                }
            }
            else
            {
                return cardBack;
            }
        }
    }
}