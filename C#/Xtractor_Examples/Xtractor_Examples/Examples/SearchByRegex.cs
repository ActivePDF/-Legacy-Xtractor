
using System;
using System.Text.RegularExpressions;

namespace DocumentationSamplesCS
{
    static class SearchByRegex
    {
        public static void Example()
        {
            using (Xtractor.Xtractor xtractor = new Xtractor.Xtractor(@"..\..\..\Input\Xtractor.Input.pdf"))
            {
                // Simple Regex to search for numbers.
                Regex re = new Regex(pattern: "\\d+");

                // Finds all the numbers on page 1.
                Console.WriteLine("Searching first page ...");
                string[] page1Matches = xtractor.FindAllByRegex(re: re, pageNumber: 1);
                Console.WriteLine($"{page1Matches.Length} results found on page one.");
                Console.WriteLine();


                // Finds all numbers in the whole document. The first dimension
                // of the array is sorted by page number.
                Console.WriteLine("Searching entire document ...");
                string[][] wholeDocumentMatches = xtractor.FindAllByRegex(re: re);
                for (int i = 0; i < wholeDocumentMatches.Length; ++i)
                {
                    Console.WriteLine($"{wholeDocumentMatches[i].Length} results found on page {i + 1}.");
                }
            }
        }
    }
}
