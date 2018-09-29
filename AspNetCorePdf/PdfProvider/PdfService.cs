using AspNetCorePdf.PdfProvider.DataModel;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using System;
using System.IO;

namespace AspNetCorePdf.PdfProvider
{
    public class PdfService : IPdfService
    {
        private string createdDocsPath = ".\\PdfProvider\\Created";
        private string imagesPath = ".\\PdfProvider\\Images";

        public string CreatePdf(PdfData pdfData)
        {
            GlobalFontSettings.FontResolver = new FontResolver();

            var document = new PdfDocument();
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);
    
            AddTitleLogo(gfx, page, $"{imagesPath}\\logo.jpg", 0, 0);
            AddTitleAndFooter(page, gfx, pdfData.DocumentTitle, document, pdfData);

            AddDescription(gfx, pdfData);

            AddList(gfx, pdfData);

            string docName = $"{createdDocsPath}/{pdfData.DocumentName}-{DateTime.UtcNow.ToOADate()}.pdf";
            document.Save(docName);
            return docName;
        }

        void AddTitleLogo(XGraphics gfx, PdfPage page, string imagePath, int xPosition, int yPosition)
        {
            if (!File.Exists(imagePath))
            {
                throw new FileNotFoundException(String.Format("Could not find image {0}.", imagePath));
            }

            XImage xImage = XImage.FromFile(imagePath);
            gfx.DrawImage(xImage, xPosition, yPosition, xImage.PixelWidth / 8, xImage.PixelWidth / 8);
        }

        void AddTitleAndFooter(PdfPage page, XGraphics gfx, string title, PdfDocument document, PdfData pdfData)
        {
            XRect rect = new XRect(new XPoint(), gfx.PageSize);
            rect.Inflate(-10, -15);
            XFont font = new XFont("OpenSans", 14, XFontStyle.Bold);
            gfx.DrawString(title, font, XBrushes.MidnightBlue, rect, XStringFormats.TopCenter);

            rect.Offset(0, 5);
            font = new XFont("OpenSans", 8, XFontStyle.Italic);
            XStringFormat format = new XStringFormat();
            format.Alignment = XStringAlignment.Near;
            format.LineAlignment = XLineAlignment.Far;
            gfx.DrawString("Created by " + pdfData.CreatedBy, font, XBrushes.DarkOrchid, rect, format);

            font = new XFont("OpenSans", 8);
            format.Alignment = XStringAlignment.Center;
            gfx.DrawString(document.PageCount.ToString(), font, XBrushes.DarkOrchid, rect, format);

            document.Outlines.Add(title, page, true);
        }

        void AddDescription(XGraphics gfx, PdfData pdfData)
        {
            var font = new XFont("OpenSans", 14, XFontStyle.Regular);
            XTextFormatter tf = new XTextFormatter(gfx);
            XRect rect = new XRect(40, 100, 520, 100);
            gfx.DrawRectangle(XBrushes.White, rect);
            tf.DrawString(pdfData.Description, font, XBrushes.Black, rect, XStringFormats.TopLeft);
        }

        void AddList(XGraphics gfx, PdfData pdfData)
        {
            int startingHeight = 200;
            for (int i = 0; i < pdfData.DisplayListItems.Count; i++)
            {
                var font = new XFont("OpenSans", 14, XFontStyle.Regular);
                XTextFormatter tf = new XTextFormatter(gfx);
                XRect rect = new XRect(60, startingHeight, 500, 30);
                gfx.DrawRectangle(XBrushes.White, rect);
                var data = $"{i}. {pdfData.DisplayListItems[i].Id} | {pdfData.DisplayListItems[i].Data1} | {pdfData.DisplayListItems[i].Data2}";
                tf.DrawString(data, font, XBrushes.Black, rect, XStringFormats.TopLeft);

                startingHeight = startingHeight + 30;
            }
        }

    }
}
