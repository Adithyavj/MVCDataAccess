using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class StudentattrController : Controller
    {
        static List<StudentAttr> students = new List<StudentAttr>()
        {
            new StudentAttr() { Id = 1, Name = "Pranaya" },
            new StudentAttr() { Id = 2, Name = "Priyanka" },
            new StudentAttr() { Id = 3, Name = "Anurag" },
            new StudentAttr() { Id = 4, Name = "Sambit" }
        };


        // GET: Studentattr
        public ActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public ActionResult GetStudents()
        {
            return View(students); // strong typed model
        }

        [HttpGet]
        public ActionResult GetStudentByID(int studentID)
        {
            StudentAttr studentDetails = students.FirstOrDefault(s => s.Id == studentID);
            return View(studentDetails);
        }

        [HttpGet]
        public ActionResult GetStudentCourses(int studentID)
        {
            List<string> CourseList = new List<string>();
            if (studentID == 1)
                CourseList = new List<string>() { "ASP.NET", "C#.NET", "SQL Server" };
            else if (studentID == 2)
                CourseList = new List<string>() { "ASP.NET MVC", "C#.NET", "ADO.NET" };
            else if (studentID == 3)
                CourseList = new List<string>() { "ASP.NET WEB API", "C#.NET", "Entity Framework" };
            else
                CourseList = new List<string>() { "Bootstrap", "jQuery", "AngularJs" };
            ViewBag.CourseList = CourseList;
            return View();
        }
    }
}