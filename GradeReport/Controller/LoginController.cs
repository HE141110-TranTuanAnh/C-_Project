using GradeReport.DataAccess;
using GradeReport.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeReport.Controller
{
    class LoginController
    {
        internal static Account GetAccount(string roll, string password)
        {
            string sql = "Select * from [MRA_Project].[dbo].[Teacher] where [roll] = @roll and [password] = @password";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@roll", SqlDbType.NChar){Value = roll},
                new SqlParameter("@password", SqlDbType.NVarChar){Value = password}
            };
            return GetAccountByDataTable(DAO.GetDataBySQL(sql, parameters));
        }

        public static Account GetAccountByDataTable(DataTable dataTable)
        {
            if (dataTable.Rows.Count == 0)
            {
                return null;
            }
            string roll = dataTable.Rows[0]["roll"].ToString();
            string password = dataTable.Rows[0]["password"].ToString();
            string name = dataTable.Rows[0]["name"].ToString();
            return new Account(roll, password, name);
        }
    }
}
