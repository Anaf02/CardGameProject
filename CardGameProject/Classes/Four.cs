using CardGameProject.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
