
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentationSamplesCS
{
    static class ExtractTextByReadingOrder
    {
        public static void Example()
        {
            using (Xtractor.Xtractor xtractor = new Xtractor.Xtractor(filename: @"..\..\..\Input\Xtractor.Input.pdf"))
            {
                /*
                 * PDF documents don't always store the desired reading order of the text.
                 * Even if it does, the text is not required to be stored in the reading 
                 * order for  that language. Some languages even have multiple acceptible 
                 * reading orders. Thus, Xtractor cannot guarantee getting text back in the
                 * desired reading order for a given language.
                 * 
                 * However, if you know what reading order you expect from your document,
                 * it is still quite easy to get the desired result using LINQ. The example 
                 * below sorts the text for English, meaning top -> bottom first, 
                 * and left -> right second.
                 */
                Console.WriteLine("Extracting document text by reading order ...");
                Xtractor.CharAndBox[] englishText = xtractor.ExtractTextWithLocation(pageNumber: 1, origin: Xtractor.Xtractor.CoordinateOrigin.BottomLeft);
                IEnumerable<Xtractor.CharAndBox> sortedText = englishText.OrderBy(cab => cab.Box.Y).ThenBy(cab => cab.Box.X);
                StringBuilder stringBuilder = new StringBuilder();
                foreach(Xtractor.CharAndBox character in sortedText)
                {
                    stringBuilder.Append(character.Character);
                }
                Console.WriteLine($"Document Text: {stringBuilder.ToString()}");
            }
        }
    }
}
