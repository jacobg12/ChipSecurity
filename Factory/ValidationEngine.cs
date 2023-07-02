using System.Collections.Generic;
using System.Linq;

namespace ChipSecuritySystem.Factory
{
    internal sealed class ValidationEngine
    {
        public static bool CanUnlock(IEnumerable<ColorChip> colors)
        {
            /*
             * [Blue, Yellow]
                [Red, Green]
                [Yellow, Red]
                [Orange, Purple]*/

            if (colors.First().StartColor != Color.Blue && colors.First().EndColor != Color.Yellow)
                return false;
            if (colors.Last().StartColor != Color.Red && colors.Last().EndColor != Color.Green)
                return false;

            
             //The above above conditions result to a Chip Security System rathern than assuming first ==> Blue && Last ==> Greeen
             

            foreach (var colorChip in colors)
            {
                switch (colorChip.StartColor)
                {
                    case Color.Blue:
                        if (colorChip.EndColor != Color.Yellow)
                            return false;
                        break;
                    case Color.Red:
                        if (colorChip.EndColor != Color.Green)
                            return false;
                        break;
                    case Color.Yellow:
                        if (colorChip.EndColor != Color.Red)
                            return false;
                        break;
                    case Color.Orange:
                        if (colorChip.EndColor != Color.Purple)
                            return false;
                        break;
                    default:
                        return false;
                }
            }
            return true;
        }
    }
}
