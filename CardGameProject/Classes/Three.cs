using CardGameProject.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProject.Classes
{
    internal class Three : CardBase
    {
        public Three(CardColour colour) : base(colour, 3)
        {
        }
        public override Image GetImage(bool front)
        {
            if (front)
            {
                if (colour == CardColour.Green)
                {
                    return Resources.card_1g;
                }
                else
                {
                    return Resources.card_1r;
                }
            }
            else
            {
                return cardBack;
            }
        }
    }
}
