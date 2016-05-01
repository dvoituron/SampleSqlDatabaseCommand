using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSqlDatabaseCommand.CommandConsole
{
    public class AdoNet
    {
        public static void DisplaySmith()
        {
            Console.WriteLine("ADO.NET");

            using (var connection = new SqlConnection(Program.CONNECTION_STRING))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT ENAME " +
                                      "  FROM EMP " +
                                      " WHERE EMPNO = 7369 ";
                                        using (var adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        string name = table.Rows[0].Field<string>("ENAME");
                        Console.WriteLine(name);
                    }
                }
                connection.Close();
            }
        }
    }
}
