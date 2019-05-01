
using System.Drawing;

namespace DocumentationSamplesCS
{
    static class ExtractImagesByLocation
    {
        public static void Example()
        {
            // Xtractor supports many image file formats, including jpg, png, tiff, and more.
            using (Xtractor.Xtractor xtractor = new Xtractor.Xtractor(filename: @"..\..\..\Input\Xtractor.Input.pdf"))
            {
                PointF location = new PointF(x: 50f, y: 50f);

                // On page 1, finds the image 50 units from the left edge, 
                // and 50 units from the top, and saves to a jpg file.
                xtractor.ExtractImageToFile(filename: @"..\..\..\Output\ExtractImagesByLocation.jpg", pageNumber: 1, location: location, origin: Xtractor.Xtractor.CoordinateOrigin.TopLeft);

                // On page 1, finds the image 50 units from the left edge, 
                // and 700 units from the bottom, and saves to a png file.
                xtractor.ExtractImageToFile(filename: @"..\..\..\Output\ExtractImagesByLocation.png", pageNumber: 1, location: new PointF(x: 50f, y: 700f), origin: Xtractor.Xtractor.CoordinateOrigin.BottomLeft);

                // Extracts the image 50 units from the left edge and 50 from the top of page 1, and returns it in memory.
                Bitmap imageAtLocation = xtractor.ExtractImage(pageNumber: 1, location: location, origin: Xtractor.Xtractor.CoordinateOrigin.TopLeft);
                imageAtLocation.Dispose();
            }
        }
    }
}
