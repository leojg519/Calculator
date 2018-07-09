using System.Web.Mvc;
using System.Web;
using System;

namespace CalculatorService.Controllers
{
    /// <summary>
    /// Class for addition calculations
    /// </summary>
    public class AdditionController : Controller
    {
        /// <summary>
        /// Addition view
        /// </summary>
        /// <returns>Addition view</returns>
        public ActionResult Addition()
        {
            return View();
        }        
    }
}