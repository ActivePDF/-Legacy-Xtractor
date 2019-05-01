
using System;

namespace DocumentationSamplesCS
{
    static class CountWords
    {
        public static void Example()
        {
            using (Xtractor.Xtractor xtractor = new Xtractor.Xtractor(filename: @"..\..\..\Input\Xtractor.Input.pdf"))
            {
                string searchTerm = "ActivePDF";

                Console.WriteLine($"Counting search term, {searchTerm}, instances ...");

                // Count instances on just the first page.
                int searchResults = xtractor.CountInstances(text: searchTerm, pageNumber: 1);
                Console.WriteLine($" Instances of {searchTerm} found on the first page: {searchResults}");

                // Count instances in the entire document.
                searchResults = xtractor.CountInstances(text: searchTerm);
                Console.WriteLine($" Instances of {searchTerm} found in the document: {searchResults}");
            }
        }
    }
}
