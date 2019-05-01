
using System;
using System.Drawing;

namespace DocumentationSamplesCS
{
    static class ExtractPageSize
    {
        public static void Example()
        {
            // You have two options for extracting the page size.
            using (Xtractor.Xtractor xtractor = new Xtractor.Xtractor(filename: @"..\..\..\Input\Xtractor.Input.pdf"))
            {
                Console.WriteLine("Extracting document page dimensions ...");

                // Extract the page size as two floats from page one.
                float width, height;
                xtractor.GetPageSize(pageNumber: 1, width: out width, height: out height);
                Console.WriteLine($"  Page one Width: {width} Height: {height}");

                // Extract the page size from page two as a rectangle.
                RectangleF pageSize = xtractor.GetPageSize(pageNumber: 2);
                Console.WriteLine($"  Page two Width: {pageSize.Width} Height: {pageSize.Height}");
            }
        }
    }
}
