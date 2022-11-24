using CardGameProject.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProject.Classes
{
    internal abstract class CardBase
    {
        public int value { get; set; }

        private Image cardBackPath = Resources.card_back;

        public abstract Image GetImage(bool front);
    }
}
