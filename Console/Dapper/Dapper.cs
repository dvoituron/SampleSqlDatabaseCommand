﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSqlDatabaseCommand.CommandConsole
{
    public class Dapper
    {
        public static void DisplaySmith()
        {
            Console.WriteLine();
            Console.WriteLine("Dapper.NET");

            using (var connection = new SqlConnection(Program.CONNECTION_STRING))
            {
                connection.Open();

                string sql = "SELECT * FROM EMP WHERE EMPNO = @Id";
                var emp = connection.Query<Employee>(sql, new { Id = 7369 });

                Console.WriteLine(emp.First().ENAME);
            }

        }
    }

    public class Employee
    {
        public Int32 EMPNO { get; set; }
        public String ENAME { get; set; }
        public String JOB { get; set; }
        public Int32? MGR { get; set; }
        public DateTime? HIREDATE { get; set; }
        public Int32? SAL { get; set; }
        public Int32? COMM { get; set; }
        public Int32? DEPTNO { get; set; }
    }
}
