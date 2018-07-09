using System.Web.Mvc;

namespace CalculatorService.Controllers
{
    /// <summary>
    /// Class for Home
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Index init page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}