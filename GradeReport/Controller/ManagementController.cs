using GradeReport.DataAccess;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeReport.Controller
{
    class ManagementController
    {
        internal static DataTable GetListStudent(string rollTeacher)
        {
            string sql = @"SELECT * FROM Subject join(SELECT DISTINCT rollsubject FROM SubjectClass WHERE rollteacher = @rollteacher) AS t on Subject.roll = t.rollSubject";

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@rollTeacher",SqlDbType.NChar) {Value = rollTeacher}
            };

            return DAO.GetDataBySQL(sql, parameter);
        }

        internal static DataTable GetListClass(string rollTeacher, string rollSubject)
        {
            string sql = @"SELECT * FROM SubjectClass WHERE rollteacher = "
        }
    }
}
