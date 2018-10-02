using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCorePdf.Models;
using AspNetCorePdf.PdfProvider;
using AspNetCorePdf.PdfProvider.DataModel;
using System.IO;

namespace AspNetCorePdf.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPdfSharpService _pdfService;
        private readonly IMigraDocService _migraDocService;

        public HomeController(IPdfSharpService pdfService, IMigraDocService migraDocService)
        {
            _pdfService = pdfService;
            _migraDocService = migraDocService;
        }

        public IActionResult Index()
        {
          
            return View();
        }

        //[Route("CreatePdf")]
        [HttpGet]
        public FileStreamResult CreatePdf()
        {
            var data = new PdfData
            {
                DocumentTitle = "This is my demo document Title",
                DocumentName = "myFirst",
                CreatedBy = "Damien",
                Description = "some data description which I have, and want to display in the PDF file..., This is another text, what is happening here, why is this text display...",
                DisplayListItems = new List<ItemsToDisplay>
                {
                    new ItemsToDisplay{ Id = "Print Servers", Data1= "some data", Data2 = "more data to display"},
                    new ItemsToDisplay{ Id = "Network Stuff", Data1= "IP4", Data2 = "any left"},
                    new ItemsToDisplay{ Id = "Job details", Data1= "too many", Data2 = "say no"},
                    new ItemsToDisplay{ Id = "Firewall", Data1= "what", Data2 = "Let's burn it"}

                }
            };
            var path = _pdfService.CreatePdf(data);

            var stream = new FileStream(path, FileMode.Open);
            return File(stream, "application/pdf");
        }

        [HttpGet]
        public FileStreamResult CreateMigraDocPdf()
        {
            var data = new PdfData
            {
                DocumentTitle = "This is my demo document Title",
                DocumentName = "myFirst",
                CreatedBy = "Damien",
                Description = "some data description which I have, and want to display in the PDF file..., This is another text, what is happening here, why is this text display...",
                DisplayListItems = new List<ItemsToDisplay>
                {
                    new ItemsToDisplay{ Id = "Print Servers", Data1= "some data", Data2 = "more data to display"},
                    new ItemsToDisplay{ Id = "Network Stuff", Data1= "IP4", Data2 = "any left"},
                    new ItemsToDisplay{ Id = "Job details", Data1= "too many", Data2 = "say no"},
                    new ItemsToDisplay{ Id = "Firewall", Data1= "what", Data2 = "Let's burn it"}

                }
            };
            var path = _migraDocService.CreateMigraDocPdf(data);

            var stream = new FileStream(path, FileMode.Open);
            return File(stream, "application/pdf");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
