using System.IO.Pipelines;

namespace PredictionData
{
    public class HistoricalData
    {
        public string Date { get; set; }      
        public string Open { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Close { get; set; }
        public string Change_Pips { get; set; }
        public string Change_percent { get; set; }
    }
}
