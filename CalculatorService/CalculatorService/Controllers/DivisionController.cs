using System.Web.Mvc;

namespace CalculatorService.Controllers
{
    /// <summary>
    /// Class for division calculations
    /// </summary>
    public class DivisionController : Controller
    {
        /// <summary>
        /// Division view
        /// </summary>
        /// <returns>Division view</returns>
        public ActionResult Division()
        {
            return View();
        }
    }
}