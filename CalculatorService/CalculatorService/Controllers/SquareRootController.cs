using System.Web.Mvc;

namespace CalculatorService.Controllers
{
    /// <summary>
    /// Class for square root calculations
    /// </summary>
    public class SquareRootController : Controller
    {
        /// <summary>
        /// Square root view
        /// </summary>
        /// <returns>Square root view</returns>
        public ActionResult SquareRoot()
        {
            return View();
        }
    }
}