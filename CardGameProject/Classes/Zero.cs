using CardGameProject.Properties;
using System.Drawing;

namespace CardGameProject.Classes
{
    internal class Zero : CardBase
    {
        public Zero(CardColour colour) : base(CardColour.Green, 0)
        {
        }

        public override Image GetImage(bool front)
        {
            if (front)
            {
                return Resources.card_0;
            }
            else
            {
                return cardBack;
            }
        }
    }
}