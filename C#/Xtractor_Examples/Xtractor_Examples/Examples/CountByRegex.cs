
using System;
using System.Text.RegularExpressions;

namespace DocumentationSamplesCS
{
    static class CountByRegex
    {
        public static void Example()
        {
            using (Xtractor.Xtractor xtractor = new Xtractor.Xtractor(filename: @"..\..\..\Input\Xtractor.Input.pdf"))
            {
                //Simple regex to search for all words.
                Regex re = new Regex(pattern: "\\w+");

                Console.WriteLine($"Counting regular expression, {re.ToString()}, instances ...");

                //Count instances on just the first page.
                int searchResults = xtractor.CountInstances(re: re, pageNumber: 1);
                Console.WriteLine($"  Instances of {re.ToString()} found on the first page: {searchResults}");

                //Count instances in the entire document.
                searchResults = xtractor.CountInstances(re: re);
                Console.WriteLine($"  Instances of {re.ToString()} found in the document: {searchResults}");
            }
        }
    }
}
