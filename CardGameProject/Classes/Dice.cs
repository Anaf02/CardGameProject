using CardGameProject.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProject.Classes
{
    internal static class Dice
    {
        public static Image GetImage(int number)
        {
            
            switch(number) 
            {
                case 1: return Table.ResizeImage(Resources.dice1, 186, 186);
                case 2: return Table.ResizeImage(Resources.dice2, 186, 186);
                case 3: return Table.ResizeImage(Resources.dice3, 186, 186);
                case 4: return Table.ResizeImage(Resources.dice4, 186, 186);
                case 5: return Table.ResizeImage(Resources.dice5, 186, 186);
                case 6: return Table.ResizeImage(Resources.dice6, 186, 186); 
                default: throw new ArgumentOutOfRangeException(nameof(number));
            }
        }
    }
}
