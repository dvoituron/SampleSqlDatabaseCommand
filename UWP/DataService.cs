using Apps72.Dev.Data;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSqlDatabaseCommand.Uwp
{
    public class DataService
    {
        public DataService()
        {
            Scott.CreateScottDatabase();
        }

        public SqliteDatabaseCommand GetDatabaseCommand()
        {
            return new SqliteDatabaseCommand("Filename=" + Scott.DB_NAME);
        }

        public SqliteDatabaseCommand GetDatabaseCommand(SqliteTransaction transaction)
        {
            return new SqliteDatabaseCommand(transaction.Connection, transaction);
        }

        public IEnumerable<Scott.EMP> GetAllEmployees()
        {
            using (var cmd = this.GetDatabaseCommand())
            {
                cmd.CommandText.AppendLine(" SELECT * ");
                cmd.CommandText.AppendLine("   FROM EMP ");
                return cmd.ExecuteTable<Scott.EMP>();
            }
        }
    }
}
