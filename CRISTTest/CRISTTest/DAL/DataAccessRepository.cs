using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace CRISTTest.DAL
{
    public class DataAccessRepository
    {
        public static string connectionString = "Data Source=.;Initial Catalog=CRISKAshutoshTest;Integrated Security=true";

        public static string GetFormatedDate(DateTime date)
        {
            string formatedDate = date.ToString("dd-MM-yyyy");
            string[] arr = formatedDate.Split('-');
            string day = arr[0];
            string month = arr[1];
            string year = arr[2];
            if(month == "01")
            {
                month = "Jan";
            }
            else if(month == "02")
            {
                month = "Feb";
            }

            return $"{ day}-{month}-{year}";
        }

        public DataSet GetExposureForecastData(DateTime startDate, DateTime endDate)
        {
            //string sDate = GetFormatedDate(startDate);
            //string eDate = GetFormatedDate(endDate);
            if (startDate == Convert.ToDateTime("01-01-0001 00:00:00"))
            {
                startDate = Convert.ToDateTime("01-01-2023 00:00:00");
            }

            DataSet dataSet = new DataSet();

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCommand = new SqlCommand("SP_ExposureForecast", sqlCon);
                SqlParameter param1 = new SqlParameter("@startDate", startDate);
                param1.Direction = ParameterDirection.Input;
                param1.DbType = DbType.DateTime;
                sqlCommand.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@endDate", endDate);
                param2.Direction = ParameterDirection.Input;
                param2.DbType = DbType.DateTime;
                sqlCommand.Parameters.Add(param2);

                //sql_cmnd.Parameters.AddWithValue("@startDate", null);
                //sql_cmnd.Parameters.AddWithValue("@endDate", null);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                //dataAdapter.SelectCommand = sql_cmnd;
                dataAdapter.Fill(dataSet);
                //sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
            return dataSet;
        }
        
        public List<ExposureForecast> ExposureForecastDataSetToEntity(DataSet ds)
        {
            //DataSet ds = GetExposureForecastData();
            List<ExposureForecast> exposureForecasts = new List<ExposureForecast>();
            if (ds != null && ds?.Tables[0]?.Rows?.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach(DataRow dr in dt.Rows)
                {
                    exposureForecasts.Add(new ExposureForecast()
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        Counterparty = Convert.ToString(dr["Counterparty"]),
                        Businessdate = Convert.ToDateTime(dr["Businessdate"]).ToString("dd-MM-yyyy"),
                        Exposure = Convert.ToString(dr["Exposure"])
                    });
                }
            }
            return exposureForecasts;
        }
    }
}

public class ExposureForecast
{
    public int ID { get; set; }
    public string Counterparty { get; set; }
    public string Businessdate { get; set; }
    public string Exposure { get; set; }

}
