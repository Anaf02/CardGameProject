using CardGameProject.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
