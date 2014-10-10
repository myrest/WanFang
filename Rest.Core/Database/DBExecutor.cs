using Rest.Core.Constancy;
using Rest.Core.PetaPoco;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Rest.Core
{
    public class DBExecutor
    {
        public DBExecutor()
        {
        }

        public Database GetDatabase()
        {
            string connectionString = string.Format(
                "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}"
                , "192.168.52.110", "wfweb", "wfwebuser", "abcd1234#");
#if DEBUG
            return new Database("WanfangSqlServerTEST");
#else
            return new Database("WanfangSqlServer");
#endif
        }
    }
}