using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using Microsoft.Data.SqlClient;

namespace GradeReport.DataAccess
{
    class DAO
    {

        private static string GetConnection()
        {
            IConfiguration config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, true).Build();
            return config["ConnectionStrings:MRAProjectDB"];
        }

        public static DataTable GetDataBySQL(string sql, SqlParameter[] parameters)
        {
            using (SqlCommand command = new SqlCommand(sql, new SqlConnection(GetConnection())))
            {
                command.Parameters.AddRange(parameters);
                try
                {
                    command.Connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();

                    da.Fill(dataSet);
                    return dataSet.Tables[0];
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    command.Connection.Close();
                }                
            }
        }

        public static int ExecuteSQL(string sql, SqlParameter[] parameters)
        {
            using (SqlCommand command = new SqlCommand(sql, new SqlConnection(GetConnection())))
            {
                command.Parameters.AddRange(parameters);
                try
                {
                    command.Connection.Open();
                    int count = command.ExecuteNonQuery();
                    return count;
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    command.Connection.Close();
                }
                
            }
        }
    }
}
