using Apps72.Dev.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSqlDatabaseCommand.CommandConsole
{
    public class SqlDbCommand
    {
        public static void DisplaySmith()
        {
            Console.WriteLine();
            Console.WriteLine("SqlDatabaseCommand");

            using (var cmd = new SqlDatabaseCommand(Program.CONNECTION_STRING))
            {
                cmd.Log = (message) =>
                {
                    string trace = $"<h1>{DateTime.Now.ToLongTimeString()}</h1>" +
                                   $"<font face='Courier New'>{cmd.GetCommandTextFormatted(QueryFormat.Html)}</font><hr/>";

                    File.AppendAllText(@"C:\_Temp\SqlDbCmd.html", trace);
                };

                cmd.CommandText.AppendLine(" SELECT ENAME ");
                cmd.CommandText.AppendLine("   FROM EMP ");
                cmd.CommandText.AppendLine("  WHERE HIREDATE = @HireDate ");

                cmd.Parameters.AddValues(new
                {
                    HireDate = new DateTime(1980, 12, 17)
                });
                
                var emp = cmd.ExecuteScalar<string>();
                Console.WriteLine(emp);
            }
        }
    }
}
