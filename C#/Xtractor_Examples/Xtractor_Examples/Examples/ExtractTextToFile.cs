
using System.Diagnostics;

namespace DocumentationSamplesCS
{
    static class ExtractTextToFile
    {
        public static void Example()
        {
            using (Xtractor.Xtractor xtractor = new Xtractor.Xtractor(filename: @"..\..\..\Input\Xtractor.Input.pdf"))
            {
                //This saves the text from just page 1 to a file.
                xtractor.ExtractTextToFile(filename: @"..\..\..\Output\PageOneText.txt", pageNumber: 1);
                Process.Start(@"PageOneText.txt");

                //This saves the text from the whole document to a file.
                xtractor.ExtractTextToFile(filename: @"WholeDocumentText.txt");
                Process.Start(@"WholeDocumentText.txt");

                //This overload contains an optional parameter for a string to insert
                //between the result of each page. It defaults to "\n". Each page may
                //contain newlines as well, so modify this if you need to be able to
                //tell pages apart.
                xtractor.ExtractTextToFile(filename: @"WholeDocumentTextPageBreak.txt", pageSeparationStr: "This is a page break.");
                Process.Start(@"WholeDocumentTextPageBreak.txt");
            }
        }
    }
}
