using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataLibrary.DataAccess
{
    public static class SqlDataAccess
    {
        // Method to GetSQL Connection
        public static string GetConnectionString(string connectionName = "MVCDB")
        {
            // takes argument and pass to this 
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }


        // Load Data - T represents the model to which we want to load data
        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                // This returns Ienumerable, but we convert it to List and Return List<T> - List of Model
                return connection.Query<T>(sql).ToList();
            }
        }

        // This saves one model ie, T - data
        public static int SaveData<T>(string sql,T data)
        {
            using (IDbConnection connection=new SqlConnection(GetConnectionString()))
            {
                // saves data to DB
                return connection.Execute(sql, data);
            }
        }
    }
}
