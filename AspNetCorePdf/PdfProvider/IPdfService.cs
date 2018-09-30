using AspNetCorePdf.PdfProvider.DataModel;

namespace AspNetCorePdf.PdfProvider
{
    public interface IPdfService
    {
        string CreatePdf(PdfData pdfData);
    }
}
