
using System;

namespace DocumentationSamplesCS
{
    static class ExtractDocumentInfo
    {
        public static void Example()
        {
            using (Xtractor.Xtractor xtractor = new Xtractor.Xtractor(filename: @"..\..\..\Input\Xtractor.Input.pdf"))
            {
                Xtractor.DocumentInfo xtractorDocInfo = xtractor.GetDocumentInfo();
                WriteMetadata(XtractorDocInfo: xtractorDocInfo);
                Console.WriteLine();
                WritePermissions(XtractorDocInfo: xtractorDocInfo);
            }
        }

        public static void WriteMetadata(Xtractor.DocumentInfo XtractorDocInfo)
        {
            Console.WriteLine($"PDF Metadata");
            Console.WriteLine($"  Author: {XtractorDocInfo.Author}");
            Console.WriteLine($"  Keywords: {XtractorDocInfo.Keywords}");
            Console.WriteLine($"  Subject: {XtractorDocInfo.Subject}");
            Console.WriteLine($"  Title: {XtractorDocInfo.Title}");
            Console.WriteLine($"  DateCreated: {XtractorDocInfo.DateCreated}");
            Console.WriteLine($"  DateModified: {XtractorDocInfo.DateModified}");
            Console.WriteLine($"  Creator: {XtractorDocInfo.Creator}");
            Console.WriteLine($"  Producer: {XtractorDocInfo.Producer}");
            Console.WriteLine($"  Version: {XtractorDocInfo.Version}");
        }

        public static void WritePermissions(Xtractor.DocumentInfo XtractorDocInfo)
        {
            Console.WriteLine("PDF Permissions");
            Console.WriteLine($"  CanPrintLowResolution: {XtractorDocInfo.CanPrintLowResolution}");
            Console.WriteLine($"  CanPrintHighResolution: {XtractorDocInfo.CanPrintHighResolution}");
            Console.WriteLine($"  CanModify: {XtractorDocInfo.CanModify}");
            Console.WriteLine($"  CanCopy: {XtractorDocInfo.CanCopy}");
            Console.WriteLine($"  CanModifyAnnotationsAndFormFields: {XtractorDocInfo.CanModifyAnnotationsAndFormFields}");
            Console.WriteLine($"  CanFillForm: {XtractorDocInfo.CanFillForm}");
            Console.WriteLine($"  CanExtractForAccessibility: {XtractorDocInfo.CanExtractForAccessibility}");
            Console.WriteLine($"  CanAssemblePages: {XtractorDocInfo.CanAssemblePages}");
        }
    }
}
