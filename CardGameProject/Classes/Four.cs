using CardGameProject.Properties;
using System.Drawing;

namespace CardGameProject.Classes
{
    internal class Four : CardBase
    {
        public Four(CardColour colour) : base(colour, 4)
        {
        }

        public override Image GetImage(bool front)
        {
            if (front)
            {
                if (colour == CardColour.Green)
                {
                    return Resources.card_4g;
                }
                else
                {
                    return Resources.card_4r;
                }
            }
            else
            {
                return cardBack;
            }
        }
    }
}