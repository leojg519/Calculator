using System.Web.Mvc;

namespace CalculatorService.Controllers
{
    /// <summary>
    /// Class for history tracking
    /// </summary>
    public class QueryController : Controller
    {
        /// <summary>
        /// Query view
        /// </summary>
        /// <returns>Query view</returns>
        public ActionResult Query()
        {
            return View();
        }
    }
}