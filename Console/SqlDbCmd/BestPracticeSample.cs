using Apps72.Dev.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSqlDatabaseCommand.CommandConsole
{
    public class BestPracticeSample
    {
        static DataService service = new DataService();

        public static void DisplaySmith()
        {
            Console.WriteLine();
            Console.WriteLine("Best Practice");

            using (var cmd = service.GetDatabaseCommand())
            {
                cmd.CommandText.AppendLine(" SELECT ENAME, DNAME ");
                cmd.CommandText.AppendLine("   FROM EMP ");
                cmd.CommandText.AppendLine("  INNER JOIN DEPT ON EMP.DEPTNO = DEPT.DEPTNO ");
                cmd.CommandText.AppendLine("  WHERE EMPNO = @ID ");

                cmd.Parameters.AddValues(new { ID = 7369 });

                var emp = cmd.ExecuteRow(new { EName = "", DName = "" });

                Console.WriteLine($"{emp.EName} - {emp.DName}");
            }
        }
    }
}
