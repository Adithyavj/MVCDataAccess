using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    // We make this static because we don't need to store data here
    public static class EmployeeProcessor
    {
        // Create Employee
        public static int CreateEmployee(int employeeId, string firstName,
            string lastName, string emailAddress)
        {
            EmployeeModel data = new EmployeeModel
            {
                EmployeeId = employeeId,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress
            };

            // Insert data to table using parameterised query
            string sql = @"insert into dbo.Employee(EmployeeId, FirstName, LastName, EmailAddress)
                           values (@EmployeeId, @FirstName, @LastName, @EmailAddress)";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<EmployeeModel> LoadEmployees()
        {
            string sql = @"select Id, EmployeeId, FirstName, LastName, EmailAddress 
                           from dbo.Employee";

            // This Return EmployeeModel <T>
            return SqlDataAccess.LoadData<EmployeeModel>(sql);
        }
    }
}
