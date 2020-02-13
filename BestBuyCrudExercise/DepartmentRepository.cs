using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace BestBuyCrudExercise
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly string _connectionString;

        public DepartmentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            using(var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * from Departments;";

                MySqlDataReader reader = cmd.ExecuteReader();

                List<Department> allDepartments = new List<Department>();

                while (reader.Read() ==true)
                {
                    var currentDepartment = new Department();
                    currentDepartment.ID = (int)reader["DepartmentID"];
                    currentDepartment.Name = (string)reader["Name"];

                    allDepartments.Add(currentDepartment);

                }
                return allDepartments;
                                               
            }
            
        }
    }
}
