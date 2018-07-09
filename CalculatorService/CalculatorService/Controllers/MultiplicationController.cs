using System.Web.Mvc;

namespace CalculatorService.Controllers
{
    /// <summary>
    /// Class for multiplication calculations
    /// </summary>
    public class MultiplicationController : Controller
    {
        /// <summary>
        /// Multiplication view
        /// </summary>
        /// <returns>Multiplication view</returns>
        public ActionResult Multiplication()
        {
            return View();
        }
    }
}