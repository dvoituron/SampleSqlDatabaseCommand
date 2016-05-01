using Apps72.Dev.Data;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

public class SampleCLR
{
    [SqlFunction(DataAccess = DataAccessKind.Read)]
    public static int GetMaximumAge()
    {
        var minDate = DateTime.MinValue;
        var maxDate = DateTime.MaxValue;

        using (var cmd = new SqlDatabaseCommand("context connection=true"))
        {
            cmd.CommandText.AppendLine(" SELECT MIN(HIREDATE) AS MinHiredate FROM EMP ");
            minDate = cmd.ExecuteScalar<DateTime>();
        }

        using (var cmd = new SqlDatabaseCommand("context connection=true"))
        {
            cmd.CommandText.AppendLine(" SELECT MAX(HIREDATE) AS MinHiredate FROM EMP ");
            maxDate = cmd.ExecuteScalar<DateTime>();
        }

        return GetAge(minDate, maxDate);
    }

    private static int GetAge(DateTime minDate, DateTime maxDate)
    {
        int age = maxDate.Year - minDate.Year;

        if (minDate > maxDate.AddYears(-age))
            age--;

        return age;
    }

    [SqlFunction()]
    public static bool IsComparableTo(string text1, string text2)
    {
        return text1.ComparableTo(text2) == 0;
    }
}

