using CardGameProject.Properties;
using System.Drawing;

namespace CardGameProject.Classes
{
    internal class Six : CardBase
    {
        public Six(CardColour colour) : base(colour, 6)
        {
        }

        public override Image GetImage(bool front)
        {
            if (front)
            {
                if (colour == CardColour.Green)
                {
                    return Resources.card_6g;
                }
                else
                {
                    return Resources.card_6r;
                }
            }
            else
            {
                return cardBack;
            }
        }
    }
}