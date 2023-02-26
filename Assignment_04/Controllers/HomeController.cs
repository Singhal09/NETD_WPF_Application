/**
 * Author: Sanya Singhal
 * Date: 21 November, 2022
 * Course: NETD 3202
 * Description: HomeController Class
 *              
*/

#region Using Statements
using Assignment_04.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
#endregion

namespace Assignment_04.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Entry()
        {
            return View();
        }

        [HttpPost]
        /// <summary>
        /// Using the PieceworkWorkerModel model to assign values 
        /// </summary>
        public IActionResult Entry(PieceworkWorkerModel model)
        {
            // If all of the input is valid for this model.
            if (ModelState.IsValid)
            {
                //If the worker is senior
                if (model.IsSenior == true)
                {
                    //If the worker is senior creating a SeniorWorkerModel model
                    model = new SeniorWorkerModel(model.Name, model.Message);
                }
                
                //Using the model GetPay method to assign values
                model.GetPay();
                return View(model);
            }
            else
            {
                return View();
            }

        }

    }
}