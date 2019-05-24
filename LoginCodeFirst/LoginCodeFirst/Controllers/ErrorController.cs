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
        
        /// <summary>
        /// Error 400
        /// </summary>
        /// <returns>Error 400 view</returns>
        [Route("Error/400")]
        public IActionResult Error400()
        {
            return View();
        }
        
        /// <summary>
        /// Error 404
        /// </summary>
        /// <returns>Error 404 view</returns>
        [Route("Error/404")]
        public IActionResult Error404()
        {
            return View();
        }
    }
}