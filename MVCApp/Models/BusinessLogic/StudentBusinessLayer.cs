using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApp.Models.BusinessLogic
{
    public class StudentBusinessLayer
    {
        public StudentModel GetStudentsById(int id)
        {
            StudentModel student = new StudentModel()
            {
                EmployeeId = id,
                Name = "Adithya",
                Address = "Baby Villa",
                City = "Melattur",
                Gender = "Male",
                Salary = 50000
            };
            return student;
        }
    }
}