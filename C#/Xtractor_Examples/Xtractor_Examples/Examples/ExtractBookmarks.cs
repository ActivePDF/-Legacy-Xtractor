
using System;
using System.IO;
using System.Text;

namespace DocumentationSamplesCS
{
    static class ExtractBookmarks
    {
        public static void Example()
        {
            // When it comes to extracting bookmarks, you have two options.
            using (Xtractor.Xtractor xtractor = new Xtractor.Xtractor(filename: @"..\..\..\Input\Xtractor.Input.pdf"))
            {
                // Extract bookmarks as a JSON string.
                Console.WriteLine($"Extracting bookmarks as a JSON string.");
                string bookmarksJson = xtractor.GetBookmarksAsJson();
                string bookmarksJonFile = "bookmarks.json";
                using (FileStream outputStream = new FileStream(path: bookmarksJonFile, mode: FileMode.OpenOrCreate, access: FileAccess.ReadWrite))
                {
                    byte[] bookmarksBytes = Encoding.UTF8.GetBytes(s: bookmarksJson);
                    outputStream.Write(array: bookmarksBytes, offset: 0, count: bookmarksBytes.Length);
                }
                Console.WriteLine($"Bookmark JSON data saved to: ${System.IO.Directory.GetCurrentDirectory()}\\{bookmarksJonFile}");
                Console.WriteLine();

                // Extract bookmarks as a tree structure.
                Console.WriteLine($"Extracting bookmarks as a tree structure.");
                Xtractor.DocumentOutline bookmarks = xtractor.GetBookmarksAsTree();
                PrintBookmarks(bookmarks: bookmarks);
            }
        }

        static void PrintBookmarks(Xtractor.DocumentOutline bookmarks)
        {
            foreach(Xtractor.Bookmark bookmark in bookmarks.Outline)
            {
                PrintBookmark(bookmark: bookmark);
            }
        }

        static void PrintBookmark(Xtractor.Bookmark bookmark)
        {
            string title = bookmark.Title;
            int destinationPage = bookmark.Target;
            string uri = bookmark.Uri;

            Console.WriteLine("Bookmark {0} goes to page {1} at {2}.", title, destinationPage, uri);

            foreach(Xtractor.Bookmark child in bookmark.Children)
            {
                PrintBookmark(bookmark: child);
            }
        }
    }
}
