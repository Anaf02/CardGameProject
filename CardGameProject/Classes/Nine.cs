using CardGameProject.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
