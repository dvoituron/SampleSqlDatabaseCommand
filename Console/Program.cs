using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSqlDatabaseCommand.CommandConsole
{
    class Program
    {
        public const string CONNECTION_STRING = @"Server=(localdb)\ProjectsV12;Database=Scott;Integrated Security=true;";

        static void Main(string[] args)
        {

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
