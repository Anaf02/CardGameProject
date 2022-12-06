using CardGameProject.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProject.Classes
{
    internal class Seven : CardBase
    {
        public Seven(CardColour colour) : base(colour, 7)
        {
        }
        public override Image GetImage(bool front)
        {
            if (front)
            {
                if (colour == CardColour.Green)
                {
                    return Resources.card_7g;
                }
                else
                {
                    return Resources.card_7r;
                }
            }
            else
            {
                return cardBack;
            }
        }
    }
}
