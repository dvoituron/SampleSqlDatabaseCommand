using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSqlDatabaseCommand.CommandConsole
{
    public class EntityFramework
    {
        public static void DisplaySmith()
        {
            Console.WriteLine();
            Console.WriteLine("Entity Framework 6.x");
            
            var db = new EF.ScottEntities();
            
            var query = from e in db.EMPs
                        where e.EMPNO == 7369
                        select e.ENAME;

            var name = query.First();

            Console.WriteLine(name);
        }
    }
}
