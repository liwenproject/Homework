using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Homework.Models
{
    public class MoneyDAO
    {
        private string ConnectionString { get; set; }

        public MoneyDAO()
        {
            this.ConnectionString = WebConfigurationManager.ConnectionStrings["MoneyEF"].ConnectionString;
        }

        public List<MoneyListViewModels> GetData()
        {
            var result = new List<MoneyListViewModels>();
            string SQL = "SELECT Categoryyy, Amounttt, Dateee FROM AccountBook";

            using (var conn = new SqlConnection(this.ConnectionString))

            using (var command = new SqlCommand(SQL, conn))
            {
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 180;

                if (conn.State != ConnectionState.Open) conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    //var item = new MoneyListViewModels();
                    while (reader.Read())
                    {
                        //請問以下兩個寫法，是否迴圈裡每次都 new 一次? 以前會把 new 寫在迴圈外面

                        //寫法1:
                        //result.Add( new MoneyListViewModels()
                        //{
                        //    Category = reader["Categoryyy"].ToString(),
                        //    Amount = double.Parse(reader["Amounttt"].ToString()),
                        //    BillingDate = DateTime.Parse(reader["Dateee"].ToString())
                        //});

                        //寫法2:
                        var item = new MoneyListViewModels()
                        {
                            Category = reader["Categoryyy"].ToString(),
                            Amount = double.Parse(reader["Amounttt"].ToString()),
                            BillingDate = DateTime.Parse(reader["Dateee"].ToString())
                        };
                        result.Add(item);
                    }
                }
            }

            return result;
        }
    }
}