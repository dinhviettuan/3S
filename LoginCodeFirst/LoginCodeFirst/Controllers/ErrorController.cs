using Microsoft.AspNetCore.Mvc;

namespace LoginCodeFirst.Controllers
{
    public class ErrorController : Controller
    {

        /// <summary>
        /// Error 401
        /// </summary>
        /// <returns>Error 401 view</returns>
        
        [Route("Error/401")]
        public IActionResult Error401()
        {
            return View();
        }
        
        [Route("Error/400")]
        public IActionResult Error400()
        {
            return View();
        }
    }
}