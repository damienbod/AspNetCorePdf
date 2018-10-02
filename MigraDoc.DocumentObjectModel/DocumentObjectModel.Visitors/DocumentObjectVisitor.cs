#region MigraDoc - Creating Documents on the Fly
//
// Authors:
//   Stefan Lange
//   Klaus Potzesny
//   David Stephensen
//
// Copyright (c) 2001-2017 empira Software GmbH, Cologne Area (Germany)
//
// http://www.pdfsharp.com
// http://www.migradoc.com
// http://sourceforge.net/projects/pdfsharp
//
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
#endregion

using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using MigraDoc.DocumentObjectModel.Tables;

namespace MigraDoc.DocumentObjectModel.Visitors
{
    /// <summary>
    /// Represents the base visitor for the DocumentObject.
    /// </summary>
    public abstract class DocumentObjectVisitor
    {
        /// <summary>
        /// Visits the specified document object.
        /// </summary>
        public abstract void Visit(DocumentObject documentObject);

        // Chart
        public virtual void VisitChart(Chart chart) { }
        public virtual void VisitTextArea(TextArea textArea) { }
        public virtual void VisitLegend(Legend legend) { }

        // Document
        public virtual void VisitDocument(Document document) { }
        public virtual void VisitDocumentElements(DocumentElements elements) { }
        public virtual void VisitDocumentObjectCollection(DocumentObjectCollection elements) { }

        // Fields

        // Format
        public virtual void VisitFont(Font font) { }
        public virtual void VisitParagraphFormat(ParagraphFormat paragraphFormat) { }
        public virtual void VisitShading(Shading shading) { }
        public virtual void VisitStyle(Style style) { }
        public virtual void VisitStyles(Styles styles) { }

        // Paragraph
        public virtual void VisitFootnote(Footnote footnote) { }
        public virtual void VisitHyperlink(Hyperlink hyperlink) { }
        public virtual void VisitFormattedText(FormattedText formattedText) { }
        public virtual void VisitParagraph(Paragraph paragraph) { }

        // Section
        public virtual void VisitHeaderFooter(HeaderFooter headerFooter) { }
        public virtual void VisitHeadersFooters(HeadersFooters headersFooters) { }
        public virtual void VisitSection(Section section) { }
        public virtual void VisitSections(Sections sections) { }

        // Shape
        public virtual void VisitImage(Image image) { }
        public virtual void VisitTextFrame(TextFrame textFrame) { }

        // Table
        public virtual void VisitCell(Cell cell) { }
        public virtual void VisitColumns(Columns columns) { }
        public virtual void VisitRow(Row row) { }
        public virtual void VisitRows(Rows rows) { }
        public virtual void VisitTable(Table table) { }
    }
}
