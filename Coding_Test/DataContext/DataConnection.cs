using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Coding_Test.DataContext
{
    internal class DataConnection
    {
        static SqlConnection conn;
        public static void OpenConncetion()
        {
            try
            {
                if (conn == null)
                {
                    conn = new SqlConnection();
                    conn.ConnectionString = "Server=(localdb)\\MSSQLLocalDB; Database=Assignment;TrustServerCertificate=True;MultipleActiveResultSets=true;";
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("logs/errors.txt", $"{DateTime.Now} - {ex.Message}{Environment.NewLine}");
            }
        }
        public static SqlConnection GetConnection()
        {
            if(conn == null)
            {
                OpenConncetion();
            }
            return conn;
        }
        public static void CloseConnection()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
                conn = null;
            }
        }

    }
}
