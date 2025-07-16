using Coding_Test.DataContext;
using Coding_Test.Model;
using Coding_Test.Models.DTO;
using DevExpress.XtraEditors.Filtering.Templates;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Test.Service
{
    public class SalesService
    {


        public static List<SaleDto> GetSales(DateTime? startDate, DateTime? endDate)
        {
            var sales = new List<SaleDto>();
            try
            {
                string connectionString = DataConnection.GetConnection().ConnectionString;
                using SqlConnection conn = new(connectionString);
                //string query = @"
                //                SELECT SALEID, PRODUCTCODE, PRODUCTNAME, QUANTITY, UNITPRICE, SALEDATE 
                //                FROM PRODUCTSALES
                //                WHERE (@STARTDATE IS NULL OR SALEDATE >= @STARTDATE)
                //                  AND (@ENDDATE IS NULL OR SALEDATE <= @ENDDATE)";

                using SqlCommand cmd = new("GetProductSalesByDate", conn);
                cmd.Parameters.AddWithValue("@STARTDATE", (object?)startDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ENDDATE", (object?)endDate ?? DBNull.Value);

                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var sale = new SaleDto
                    {
                        SaleId = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        ProductCode = reader.IsDBNull(1) ? null : reader.GetString(1),
                        ProductName = reader.IsDBNull(2) ? null : reader.GetString(2),
                        Quantity = reader.IsDBNull(3) ? null : reader.GetInt32(3),
                        UnitPrice = reader.IsDBNull(4) ? null : reader.GetDecimal(4),
                        SaleDate = reader.IsDBNull(5) ? null : reader.GetDateTime(5)
                    };
                    sales.Add(sale);
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("logs/errors.txt", $"{DateTime.Now} - {ex.Message}{Environment.NewLine}");
            }

            return sales;
        }
    }
}
