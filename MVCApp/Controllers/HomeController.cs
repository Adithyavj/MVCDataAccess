using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using static DataLibrary.BusinessLogic.EmployeeProcessor;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // Display data
        public ActionResult ViewEmployees()
        {
            ViewBag.Message = "Employees List";

            // Load all employee details to a var
            var data = LoadEmployees();

            List<EmployeeModel> employees = new List<EmployeeModel>();

            // loop through the var data and add values to EmployeeMode (front end MVC model)
            foreach (var row in data)
            {
                employees.Add(new EmployeeModel
                {
                    EmployeeId = row.EmployeeId,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    EmailAddress = row.EmailAddress,
                    ConfirmEmail = row.EmailAddress
                });
            }

            return View(employees);
        }


        // Get Req for signup calls signup view
        public  ActionResult SignUp()
        {
            ViewBag.Message = "Employee Sign Up";

            return View();
        }

        // POST METHOD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(EmployeeModel model)
        {
            // Check is the incoming model is valid (passes all the validation methods)
            if (ModelState.IsValid)
            {
                // post the data in form and return to the index page

                int recordsCreated = CreateEmployee(model.EmployeeId,
                    model.FirstName,
                    model.LastName,
                    model.EmailAddress);

                return RedirectToAction("Index");
            }
            // else stay at same page
            return View();
        }
    }
}