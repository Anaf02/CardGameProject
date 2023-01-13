using CardGameProject.Properties;
using System.Drawing;

namespace CardGameProject.Classes
{
    internal class Nine : CardBase
    {
        public Nine(CardColour colour) : base(colour, 9)
        {
        }

        public override Image GetImage(bool front)
        {
            if (front)
            {
                if (colour == CardColour.Green)
                {
                    return Resources.card_9g;
                }
                else
                {
                    return Resources.card_9r;
                }
            }
            else
            {
                return cardBack;
            }
        }
    }
}