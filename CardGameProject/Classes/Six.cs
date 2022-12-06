using CardGameProject.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
