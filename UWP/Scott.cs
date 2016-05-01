using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace SampleSqlDatabaseCommand.Uwp
{

    public class Scott
    {
        private const string PICTURE_URL = "http://samplemvvmlight.azurewebsites.net/People/{0}.jpg";

        /// <summary />
        public partial class DEPT
        {
            /// <summary />
            public virtual Int64 DEPTNO { get; set; }
            /// <summary />
            public virtual String DNAME { get; set; }
            /// <summary />
            public virtual String LOC { get; set; }
        }
        /// <summary />
        public partial class EMP
        {
            /// <summary />
            public virtual Int64 EMPNO { get; set; }
            /// <summary />
            public virtual String ENAME { get; set; }
            /// <summary />
            public virtual String JOB { get; set; }
            /// <summary />
            public virtual Int64? MGR { get; set; }
            /// <summary />
            public virtual String HIREDATE { get; set; }
            /// <summary />
            public virtual Int64? SAL { get; set; }
            /// <summary />
            public virtual Int64? COMM { get; set; }
            /// <summary />
            public virtual Int64? DEPTNO { get; set; }
            /// <summary />
            public virtual String PICTURE { get { return String.Format(PICTURE_URL, EMPNO); } }
        }

        public const string DB_NAME = "Scott.db";

        public static SqliteConnection CreateScottDatabase()
        {
            string filename = Path.Combine(ApplicationData.Current.LocalFolder.Path, DB_NAME);
            bool isExistingFile = File.Exists(filename);

            System.Diagnostics.Debug.WriteLine("Creation of " + filename);

            SqliteConnection connection = new SqliteConnection("Filename=" + DB_NAME);
            connection.Open();

            if (!isExistingFile)
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                                            CREATE TABLE DEPT
                                                    (DEPTNO INT CONSTRAINT PK_DEPT PRIMARY KEY,
                                                    DNAME VARCHAR(14),
                                                    LOC VARCHAR(13) );

                                            CREATE TABLE EMP
                                                   (EMPNO INT CONSTRAINT PK_EMP PRIMARY KEY,
                                                    ENAME VARCHAR(10),
                                                    JOB VARCHAR(9),
                                                    MGR INT,
                                                    HIREDATE DATETIME,
                                                    SAL NUMERIC,
                                                    COMM INT,
                                                    DEPTNO INT CONSTRAINT FK_DEPTNO REFERENCES DEPT);

                                            INSERT INTO DEPT VALUES (10,'ACCOUNTING','NEW YORK');
                                            INSERT INTO DEPT VALUES (20,'RESEARCH','DALLAS');
                                            INSERT INTO DEPT VALUES (30,'SALES','CHICAGO');
                                            INSERT INTO DEPT VALUES (40,'OPERATIONS','BOSTON');

                                            INSERT INTO EMP VALUES  (1,'SMITH','CLERK',7902,'1980-12-17 00:00:00',800,NULL,20);
                                            INSERT INTO EMP VALUES  (2,'ALLEN','SALESMAN',7698,'1981-2-20 00:00:00',1600,300,30);
                                            INSERT INTO EMP VALUES  (3,'WARD','SALESMAN',7698,'1981-2-22 00:00:00',1250,500,30);
                                            INSERT INTO EMP VALUES  (4,'JONES','MANAGER',7839,'1981-4-2 00:00:00',2975,NULL,20);
                                            INSERT INTO EMP VALUES  (5,'MARTIN','SALESMAN',7698,'1981-9-28 00:00:00',1250,1400,30);
                                            INSERT INTO EMP VALUES  (6,'BLAKE','MANAGER',7839,'1981-5-1 00:00:00',2850,NULL,30);
                                            INSERT INTO EMP VALUES  (7,'CLARK','MANAGER',7839,'1981-6-9 00:00:00',2450,NULL,10);
                                            INSERT INTO EMP VALUES  (8,'SCOTT','ANALYST',7566,'1987-07-13 00:00:00',3000,NULL,20);
                                            INSERT INTO EMP VALUES  (9,'KING','PRESIDENT',NULL,'1981-11-17 00:00:00',5000,NULL,10);
                                            INSERT INTO EMP VALUES  (10,'TURNER','SALESMAN',7698,'1981-9-8 00:00:00',1500,0,30);
                                            INSERT INTO EMP VALUES  (11,'ADAMS','CLERK',7788,'1987-07-13 00:00:00',1100,NULL,20);
                                            INSERT INTO EMP VALUES  (12,'JAMES','CLERK',7698,'1981-12-3 00:00:00',950,NULL,30);
                                            INSERT INTO EMP VALUES  (13,'FORD','ANALYST',7566,'1981-12-3 00:00:00',3000,NULL,20);
                                            INSERT INTO EMP VALUES  (14,'MILLER','CLERK',7782,'1982-1-23 00:00:00',1300,NULL,10);
                                            ";
                    command.ExecuteNonQuery();
                }
            }

            return connection;
        }
    }
}
