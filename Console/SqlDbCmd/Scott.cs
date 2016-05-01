
// *********************************************
// Code Generated with Apps72.Dev.Data.Generator
// *********************************************
using System;

namespace SampleSqlDatabaseCommand.CommandConsole.SqlDbCmd.Scott
{
    /// <summary />
    public partial class DEPT
    {
        /// <summary />
        public virtual Int32 DEPTNO { get; set; }
        /// <summary />
        public virtual String DNAME { get; set; }
        /// <summary />
        public virtual String LOC { get; set; }
    }
    /// <summary />
    public partial class EMP
    {
        /// <summary />
        public virtual Int32 EMPNO { get; set; }
        /// <summary />
        public virtual String ENAME { get; set; }
        /// <summary />
        public virtual String JOB { get; set; }
        /// <summary />
        public virtual Int32? MGR { get; set; }
        /// <summary />
        public virtual DateTime? HIREDATE { get; set; }
        /// <summary />
        public virtual Int32? SAL { get; set; }
        /// <summary />
        public virtual Int32? COMM { get; set; }
        /// <summary />
        public virtual Int32? DEPTNO { get; set; }
    }
}
