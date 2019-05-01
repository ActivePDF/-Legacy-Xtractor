
using System;
using System.Drawing;

namespace DocumentationSamplesCS
{
    static class ExtractTextWithinArea
    {
        public static void Example()
        {
            using (Xtractor.Xtractor xtractor = new Xtractor.Xtractor(filename: @"..\..\..\Input\Xtractor.Input.pdf"))
            {
                // If you know where on the page you want to look, you can
                // restrict extractions to just that area. In this example,
                // we'll just a square 100 units  on each side and pull from a
                // corner.
                const float boxWidth = 100, boxHeight = 810;
                for (int pageNum = 1; pageNum <= xtractor.PageTotal; ++pageNum)
                {
                    // PDF allows each page to be a different size, so we should get the
                    // page size for each page rather than once for the whole document.
                    float pageWidth, pageHeight;
                    xtractor.GetPageSize(pageNumber: pageNum, width: out pageWidth, height: out pageHeight);

                    // We use Image Coordinates as the text origin  [top left is (0, 0)]
                    RectangleF topBox = new RectangleF(x: pageWidth - boxWidth,
                                                       y: 0,
                                                       width: boxWidth,
                                                       height: boxHeight);
                    string textTopRight = xtractor.ExtractTextWithin(pageNumber: pageNum, rect: topBox, origin: Xtractor.Xtractor.CoordinateOrigin.TopLeft);
                    Console.WriteLine($"Top Right Text Page {pageNum}: {textTopRight}");
                    Console.WriteLine();

                    // or we can use PDF coordinates  [bottom left is (0, 0)]
                    RectangleF bottomBox = new RectangleF(x: pageWidth - boxWidth,
                                                          y: boxHeight,
                                                          width: boxWidth,
                                                          height: boxHeight);
                    string textBottomLeft = xtractor.ExtractTextWithin(pageNumber: pageNum, rect: bottomBox, origin: Xtractor.Xtractor.CoordinateOrigin.BottomLeft);
                    Console.WriteLine($"Bottom Right Text Page {pageNum}: {textBottomLeft}");
                    Console.WriteLine();
                }
            }
        }
    }
}
