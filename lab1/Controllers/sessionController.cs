using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab1.Controllers
{
    public class sessionController : Controller
    {
        public IActionResult setSession ()
        {
            HttpContext.Session.SetString("data", "this is test data from session");
            return Content("data set succesfully ");
        }
        public IActionResult getSession()
        {
            return Content($" { HttpContext.Session.GetString("data")}");
        }
    }
}
