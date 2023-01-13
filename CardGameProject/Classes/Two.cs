using CardGameProject.Properties;
using System.Drawing;

namespace CardGameProject.Classes
{
    internal class Two : CardBase
    {
        public Two(CardColour colour) : base(colour, 2)
        {
        }

        public override Image GetImage(bool front)
        {
            if (front)
            {
                if (colour == CardColour.Green)
                {
                    return Resources.card_2g;
                }
                else
                {
                    return Resources.card_2r;
                }
            }
            else
            {
                return cardBack;
            }
        }
    }
}