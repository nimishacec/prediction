
using System.Data;
using System.Data.SqlClient;
using System.IO.Pipelines;

namespace PredictionData
{
    public interface IDataAccess
    {
        List<HistoricalData> GetHistData(int time);      
    }

    public class DataAccess : IDataAccess
    {
        private string _connectionString = string.Empty;
        private IConfiguration _configuration { get; set; }

        public DataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionStrings"];
        }
        public List<HistoricalData> GetHistData(int time)
        {
            try
            {
                List<HistoricalData> histdataList = new List<HistoricalData>();
               
                string message = "";
                using (SqlConnection Sqlcon = new(_connectionString))
                {
                    if (time == 5)
                    {
                        using (SqlCommand sqlcmd = new())
                        {
                            sqlcmd.Connection = Sqlcon;
                            Sqlcon.Open();
                            sqlcmd.CommandType = CommandType.Text;
                            sqlcmd.CommandText = "Select  * from Historical_Data";
                            using (SqlDataReader reader = sqlcmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        histdataList.Add(new HistoricalData
                                        {
                                            Date = reader["Date"].ToString(),
                                            Open = reader["Open"].ToString(),
                                            High = reader["High"].ToString(),
                                            Low = reader["Low"].ToString(),
                                            Close = reader["Close"].ToString(),
                                            Change_Pips = reader["Change(Pips)"].ToString(),
                                            Change_percent = reader["Change(%)"].ToString()
                                        });

                                    }
                                }

                            }
                        }
                    }
                    else
                    {

                        using (SqlCommand sqlcmd = new())
                        {
                            sqlcmd.Connection = Sqlcon;
                            Sqlcon.Open();
                            sqlcmd.CommandType = CommandType.Text;
                            sqlcmd.CommandText = "Select  * from Historical_DataV2";
                            using (SqlDataReader reader = sqlcmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        histdataList.Add(new HistoricalData
                                        {
                                            Date = reader["Date"].ToString(),
                                            Open = reader["Open"].ToString(),
                                            High = reader["High"].ToString(),
                                            Low = reader["Low"].ToString(),
                                            Close = reader["Close"].ToString(),
                                            Change_Pips = reader["Change(Pips)"].ToString(),
                                            Change_percent = reader["Change(%)"].ToString()
                                        });

                                    }
                                }

                            }
                        }
                    }
                }
                return histdataList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<HistoricalData> GetHistDataV2()
        //{
        //    try
        //    {
        //        List<HistoricalData> histdataList = new List<HistoricalData>();

        //        string message = "";
        //        using (SqlConnection Sqlcon = new(_connectionString))
        //        {
        //            using (SqlCommand sqlcmd = new())
        //            {
        //                sqlcmd.Connection = Sqlcon;
        //                Sqlcon.Open();
        //                sqlcmd.CommandType = CommandType.Text;
        //                sqlcmd.CommandText = "Select  * from Historical_DataV2";
        //                using (SqlDataReader reader = sqlcmd.ExecuteReader())
        //                {
        //                    if (reader.HasRows)
        //                    {
        //                        while (reader.Read())
        //                        {
        //                            histdataList.Add(new HistoricalData
        //                            {
        //                                Date = reader["Date"].ToString(),
        //                                Open = reader["Open"].ToString(),
        //                                High = reader["High"].ToString(),
        //                                Low = reader["Low"].ToString(),
        //                                Close = reader["Close"].ToString(),
        //                                Change_Pips = reader["Change(Pips)"].ToString(),
        //                                Change_percent = reader["Change(%)"].ToString()
        //                            });

        //                        }
        //                    }

        //                }
        //            }
        //        }
        //        return histdataList;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
