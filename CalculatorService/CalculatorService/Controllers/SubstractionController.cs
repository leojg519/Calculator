using System.Web.Mvc;

namespace CalculatorService.Controllers
{
    /// <summary>
    /// Class for substraction calculations
    /// </summary>
    public class SubstractionController : Controller
    {
        /// <summary>
        /// Substraction view
        /// </summary>
        /// <returns>Substraction view</returns>
        public ActionResult Substraction()
        {
            return View();
        }
    }
}