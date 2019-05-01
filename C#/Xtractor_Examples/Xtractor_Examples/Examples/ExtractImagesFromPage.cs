
using System;
using System.Diagnostics;
using System.Drawing;

namespace DocumentationSamplesCS
{
    static class ExtractImagesFromPage
    {
        public static void Example()
        {
            using (Xtractor.Xtractor xt = new Xtractor.Xtractor(filename: @"..\..\..\Input\Xtractor.Input.pdf"))
            {
                // Saves all images on page 1 to bmp files. 
                // The function will replace #PAGE# with the page number (1) and #NUM# with 
                // the order it appeared on the page, starting at 1 and counting up.
                // The literal file names, after the #PAGE# AND #NUM# substitutions were made, are returned.
                // Using both #PAGE# and #NUM# are optional.
                string[] bmpFileNames = xt.ExtractImagesToFile(filenameOrMask: @"..\..\..\Output\#PAGE#_#NUM#.bmp", pageNumber: 1);
                foreach (string bmpFileName in bmpFileNames)
                {
                    Process.Start(fileName: bmpFileName);
                }
                Console.WriteLine("First page BMP image processing complete, press any key to continue.");                

                // Saves all images in the entire document to JPG files.
                string[] jpgFileNames = xt.ExtractImagesToFile(filenameOrMask: @"..\..\..\Output\#PAGE#_#NUM#.jpg");
                foreach (string jpgFileName in jpgFileNames)
                {
                    Process.Start(fileName: jpgFileName);
                }
                Console.WriteLine("JPG image processing complete, press any key to continue.");

                // Extracts all images on page 1, and returns them in memory.
                Bitmap[] allImagesPage1 = xt.ExtractImages(pageNumber: 1);

                // Process the images

                DisposeBitmaps(allImagesPage1);

                // Extracts all images in the whole document, and returns them in memory.
                // The first dimension in the array is sorted by page number in ascending order.
                // allImagesWholeDocument
                Bitmap[][] allImagesWholeDocument = xt.ExtractImages();

                // Process the images

                DisposeBitmaps(allImagesWholeDocument);
            }
        }

        static void DisposeBitmaps(Bitmap[] bitmaps)
        {
            if (bitmaps == null)
                return;

            for (int i = 0; i < bitmaps.Length; ++i)
            {
                bitmaps[i]?.Dispose();
            }
        }

        static void DisposeBitmaps(Bitmap[][] bitmaps)
        {
            if (bitmaps == null)
                return;

            for (int i = 0; i < bitmaps.Length; ++i)
            {
                DisposeBitmaps(bitmaps[i]);
            }
        }
    }
}
