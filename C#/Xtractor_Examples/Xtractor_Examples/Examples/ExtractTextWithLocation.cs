
using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace DocumentationSamplesCS
{
    static class ExtractTextWithLocation
    {
        public static void Example()
        {
            // You have a few options, depending on how much detail you want.
            // Note that all of the "Xtractor.Xtractor.CoordinateOrigin" arguments are optional.
            using (Xtractor.Xtractor xtractor = new Xtractor.Xtractor(@"..\..\..\Input\Xtractor.Input.pdf"))
            {
                string searchPhrase = "ActivePDF";

                // Gives back the bounding box of each occurrance of "ActivePDF" on page 1, 
                // and results are relative to the top-left corner of the page.
                Console.WriteLine($"Retrieve the bounding box coordinates for all instances of {searchPhrase} on page one.");
                RectangleF[] page1BoundingBoxes = xtractor.FindText(text: searchPhrase, pageNumber: 1, origin: Xtractor.Xtractor.CoordinateOrigin.TopLeft);
                Console.WriteLine($"{page1BoundingBoxes.Length.ToString()} instance(s) of {searchPhrase} found on page 1.");
                foreach (RectangleF boundingBox in page1BoundingBoxes)
                {
                    Console.WriteLine($"  Box: ({boundingBox.X}, {boundingBox.Y}), ({boundingBox.X + boundingBox.Width}, {boundingBox.Y + boundingBox.Height})");
                }
                Console.WriteLine();

                // Gives back the bounding box of each occurrance of "ActivePDF" in the document.
                // Results are relative to the top-left corner of the page.
                // The first dimension of the array is sorted by page number, 
                // so wholeDocumentBoundingBoxes[0] contains the same data as page1BoundingBoxes.
                Console.WriteLine($"Retrieve the bounding box coordinates for all instances of {searchPhrase} in the document.");
                RectangleF[][] wholeDocumentBoundingBoxes = xtractor.FindText(text: searchPhrase, origin: Xtractor.Xtractor.CoordinateOrigin.TopLeft);
                for (int i = 0; i < wholeDocumentBoundingBoxes.Length; ++i)
                {
                    Console.WriteLine($"{wholeDocumentBoundingBoxes[i].Length.ToString()} instance(s) of {searchPhrase} found on page {i + 1}.");
                    for (int j = 0; j < wholeDocumentBoundingBoxes[i].Length; ++j)
                    {
                        RectangleF boundingBox = wholeDocumentBoundingBoxes[i][j];
                        Console.WriteLine($"  Box: ({boundingBox.X}, {boundingBox.Y}), ({boundingBox.X + boundingBox.Width}, {boundingBox.Y + boundingBox.Height})");
                    }
                }

                // Uses the regex @"\w+" to find all words on page 1. Gets back each word and location found.
                // Returned coordinates are given relative to the bottom left corner, in PDF units.
                Tuple<string, RectangleF>[] allWordsPage1 = xtractor.FindText(new Regex(@"\w+"), 1, Xtractor.Xtractor.CoordinateOrigin.BottomLeft);

                // Uses the regex @"\w+" to find all words in the document. Gets back each word and location found.
                // Returned coordinates are given relative to the bottom left corner, in PDF units.
                // allWordsWholeDocument[0] contains the same data as allWordsPage1.
                Tuple<string, RectangleF>[][] allWordsWholeDocument = xtractor.FindText(re: new Regex(@"\w+"), origin: Xtractor.Xtractor.CoordinateOrigin.BottomLeft);

                // Extracts the location of each individual character on page 1. Coordinates are relative to the top left corner.
                // The order of characters is in the PDF's order, which may or may not be in natural reading order.
                Xtractor.CharAndBox[] eachCharacterPage1 = xtractor.ExtractTextWithLocation(pageNumber: 1, origin: Xtractor.Xtractor.CoordinateOrigin.TopLeft);

                // Extracts the location of each individual character in the whole document. Coordinates are relative to the bottom left corner.
                // eachCharacterWholeDocument[0] contains the same characters in the same order as eachCharacterPage1, but the
                // coordinates returned will differ because they used different coordinate spaces when they were called.
                // Coordinates will match if they used the same coordinate space.
                // The order of characters is in the PDF's order, which may or may not be in natural reading order.
                Xtractor.CharAndBox[][] eachCharacterWholeDocument = xtractor.ExtractTextWithLocation(origin: Xtractor.Xtractor.CoordinateOrigin.BottomLeft);
            }
        }
    }
}
