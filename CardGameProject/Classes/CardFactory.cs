using System;

namespace CardGameProject.Classes
{
    internal static class CardFactory
    {
        public static CardBase GenerateCard(int number, CardColour cardColour)
        {
            switch (number)
            {
                case 0: return new Zero(cardColour);
                case 1: return new One(cardColour);
                case 2: return new Two(cardColour);
                case 3: return new Three(cardColour);
                case 4: return new Four(cardColour);
                case 5: return new Five(cardColour);
                case 6: return new Six(cardColour);
                case 7: return new Seven(cardColour);
                case 8: return new Eight(cardColour);
                case 9: return new Nine(cardColour);
                case 10: return new Ten(cardColour);
                default:
                    throw new ArgumentException("Invalid Card");
            }
        }
    }
}