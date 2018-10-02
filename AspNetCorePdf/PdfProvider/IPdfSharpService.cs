using AspNetCorePdf.PdfProvider.DataModel;

namespace AspNetCorePdf.PdfProvider
{
    public interface IPdfSharpService
    {
        string CreatePdf(PdfData pdfData);
    }
}
