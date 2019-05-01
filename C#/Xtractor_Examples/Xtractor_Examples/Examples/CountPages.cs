
using System;

namespace DocumentationSamplesCS
{
    static class CountPages
    {
        public static void Example()
        {
            Console.WriteLine($"Counting number of pages in input document ...");
            using (Xtractor.Xtractor xtractor = new Xtractor.Xtractor(filename: @"..\..\..\Input\Xtractor.Input.pdf"))
            {
                Console.WriteLine($"  Number of pages found: {xtractor.PageTotal}.");
            }
        }
    }
}
