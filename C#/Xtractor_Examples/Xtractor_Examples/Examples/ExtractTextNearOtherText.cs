
using System;

namespace DocumentationSamplesCS
{
    static class ExtractTextNearOtherText
    {
        public static void Example()
        {
            /*
            Assume that you have a page with text that looks like this:
            
            ---------------------------------
            |                               |
            |             North             |
            |                               |
            |  West       Center      East  |
            |                               |
            |             South             |
            |                               |
            ---------------------------------
            */

            using (Xtractor.Xtractor xtractor = new Xtractor.Xtractor(filename: @"..\..\..\Input\Xtractor.Text.Location.pdf"))
            {
                //These functions have options to control which page you extract from, how many characters you want to get,
                //how far to the side of the original text in PDF units to search, and which instance on that page to use
                //as the reference point.
                string up = xtractor.ExtractTextAbove(pageNumber: 1, text: "Center", length: int.MaxValue, unitType: Xtractor.Xtractor.UnitType.Character);
                Console.WriteLine($"Text above center: {up.Trim()}");

                string below = xtractor.ExtractTextBelow(pageNumber: 1, text: "Center", length: int.MaxValue, unitType: Xtractor.Xtractor.UnitType.Character);
                Console.WriteLine($"Text below center: {below.Trim()}");

                string right = xtractor.ExtractTextRight(pageNumber: 1, text: "Center", length: int.MaxValue, unitType: Xtractor.Xtractor.UnitType.Character);
                Console.WriteLine($"Text right of center: {right.Trim()}");

                string left = xtractor.ExtractTextLeft(pageNumber: 1, text: "Center", length: int.MaxValue, unitType: Xtractor.Xtractor.UnitType.Character);
                Console.WriteLine($"Text left of center: {left.Trim()}");
            }
        }
    }
}
