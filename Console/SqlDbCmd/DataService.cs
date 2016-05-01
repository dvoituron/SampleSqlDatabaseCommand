using Apps72.Dev.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSqlDatabaseCommand.CommandConsole
{
    public class DataService
    {
        private const string CONNECTION_STRING = Program.CONNECTION_STRING;

        public SqlDatabaseCommand GetDatabaseCommand()
        {
            var cmd = new SqlDatabaseCommand(CONNECTION_STRING);
            cmd.Log = (message) =>
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(message);
                Console.ResetColor();
            };
            cmd.ExceptionOccured += (sender, e) =>
            {
                Console.WriteLine($"SQL ERROR: {e.Exception.Message}");
            };
            return cmd;
        }

        public SqlDatabaseCommand GetDatabaseCommand(SqlTransaction transaction)
        {
            return new SqlDatabaseCommand(transaction.Connection, transaction);
        }
    }

}
