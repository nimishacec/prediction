
namespace PredictionData
{
    public interface IPredictlogic
    {
        List<HistoricalData> GetHistData(int time);        
    }
    public class PredictLogic : IPredictlogic
    {
        private readonly IDataAccess _dataAccess;
        public PredictLogic(IDataAccess dataAccess) 
        {
            _dataAccess = dataAccess;
        }
        public List<HistoricalData> GetHistData(int time)
        {
            try
            {
             //   var resp = GetHistAPI();
                var data = new List<HistoricalData>();
               
                 data  = _dataAccess.GetHistData(time);
                return data;
               

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
        //public List<HistoricalData> GetHistData2()
        //{
        //    try
        //    {
        //        var resp = GetHistAPI();
        //        //var data = new List<HistoricalData>();

        //        //data = _dataAccess.GetHistData();
        //        return data;


        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public async GetHistAPI()
        //{
        //    string start_date = "1712195619";
        //    string end_date = "1712558942";
        //    string interval = "5";
        //        string apiUrl = "https://priceapi.moneycontrol.com/techCharts/indianMarket/stock/history?symbol=RELIANCE&resolution='+str(interval)+'&from='+str(start_date)+'&to='+str(end_date)+'&countback=328&currencyCode=INR";


        //        HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            string responseData = await response.Content.ReadAsStringAsync();

        //            // Convert API response to JSON
        //            dynamic jsonData = JsonConvert.DeserializeObject(responseData);

        //            return Json(jsonData, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            // Handle API request failure
        //            return Content("Failed to fetch data from API");
        //        }
        //    }
    }
    }



