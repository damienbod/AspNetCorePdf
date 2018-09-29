using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePdf.PdfProvider.DataModel
{
    public class PdfData
    {
        public string DocumentTitle { get; set; }

        public string CreatedBy { get; set; }

        public string Description { get; set; }

        public List<ItemsToDisplay>  DisplayListItems { get; set; }
        public object DocumentName { get; internal set; }
    }
}
