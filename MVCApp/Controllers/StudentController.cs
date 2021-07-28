using MVCApp.Models;
using MVCApp.Models.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentBusinessLayer studentBusinessLayer = new StudentBusinessLayer();
            StudentModel student = studentBusinessLayer.GetStudentsById(1);

            ViewData["Student"] = student;
            ViewData["Header"] = "Student Details";

            return View();
        }

        public ActionResult Method1()
        {
            TempData["Name"] = "Pranaya";
            TempData["Age"] = 30;
            return View();
        }

        public ActionResult Method2()
        {
            string Name;
            int Age;
            if (TempData.ContainsKey("Name"))
                Name = TempData["Name"].ToString();
            if (TempData.ContainsKey("Age"))
                Age = int.Parse(TempData["Age"].ToString());
            // do something with userName or userAge here 
            return View();
        }

        public ActionResult Method3()
        {
            string Name;
            int Age;
            if (TempData.ContainsKey("Name"))
                Name = TempData["Name"].ToString();
            if (TempData.ContainsKey("Age"))
                Age = int.Parse(TempData["Age"].ToString());
            // do something with userName or userAge here 
            return View();
        }
    }
}