using AspNetCorePdf.PdfProvider.DataModel;

namespace AspNetCorePdf.PdfProvider
{
    public interface IMigraDocService
    {
        string CreateMigraDocPdf(PdfData pdfData);
    }
}
