using AspNetCorePdf.PdfProvider.DataModel;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using System;

namespace AspNetCorePdf.PdfProvider
{
    public class MigraDocService : IMigraDocService
    {
        private string _createdDocsPath = ".\\PdfProvider\\Created";
        private string _imagesPath = ".\\PdfProvider\\Images";
        private string _resourcesPath = ".\\PdfProvider\\Resources";

        public string CreateMigraDocPdf(PdfData pdfData)
        {
            // Create a MigraDoc document
            Document document = new Document();

            //string ddl = MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToString(document);
            MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToFile(document, "MigraDoc.mdddl");

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
            renderer.Document = document;

            renderer.RenderDocument();

            // Save the document...
            string docName = $"{_createdDocsPath}/{pdfData.DocumentName}-{DateTime.UtcNow.ToOADate()}.pdf";
            renderer.PdfDocument.Save(docName);

            return docName;
        }
    }
}
