using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using HTMLTree;
namespace AWDO.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        // Post form and build /build/
        [HttpPost]
        [Route("/build")]
        public IActionResult Build() {
            LinkedList<String> inputs = new LinkedList<String>();
            inputs.AddFirst("System");
            inputs.AddLast("System.Collections.Generic");
            ControllerBuilder newHome = new ControllerBuilder(inputs, Request.Form["siteName"]);
            String folderName = Request.Form["siteName"];
            String newController = newHome.toString();
            HTMLTree.HTMLTree newHomePage = new HTMLTree.HTMLTree();
            String newWebpage = newHomePage.toString();
            FileManager siteCreator = new FileManager(folderName, folderName);
            siteCreator.MakeUserDirectory();
            siteCreator.MakeUserViewsDirectory();
            siteCreator.MakeFile(newWebpage, ".html");
            siteCreator.MakeFile(newController, ".cs");
            String directory = System.IO.Directory.GetCurrentDirectory();

            return Redirect("");
        }
    }

    // TO DO
    // How to download files
    // Figure out exactly what is needed to run a simple mvc
    // Create classes to generate appropriate strings for simple mvc support files
}
