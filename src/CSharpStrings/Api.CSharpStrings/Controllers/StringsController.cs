using Microsoft.AspNetCore.Mvc;

namespace Api.CSharpStrings.Controllers
{
    public class StringsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
