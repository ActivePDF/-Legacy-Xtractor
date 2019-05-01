
using System;

namespace DocumentationSamplesCS
{
    static class ExtractText
    {
        public static void Example()
        {
            using (Xtractor.Xtractor xtractor = new Xtractor.Xtractor(filename: @"..\..\..\Input\Xtractor.Input.pdf"))
            {
                // This method extracts the text from pages, one page at a time.
                Console.WriteLine("Extract text from each page individually.");
                for(int pageNum = 1; pageNum <= xtractor.PageTotal; ++pageNum)
                {
                    string pageText = xtractor.ExtractText(pageNumber: pageNum);
                    Console.WriteLine($"  Page {Convert.ToString(pageNum)} Text: {xtractor.ExtractText(pageNum)}");
                }

                // This method extracts the text from the whole document at once.
                // The string[] is sorted by page number, where index 'n' is page 'n + 1'.
                string[] allTextArray = xtractor.ExtractText();
            }
        }
    }
}
