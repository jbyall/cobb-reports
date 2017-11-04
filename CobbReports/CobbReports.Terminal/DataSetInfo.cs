//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Text.RegularExpressions;

//namespace CobbReports.Terminal
//{
//    public class DataSetInfo
//    {
//        public DataSetInfo(string apInfoString)
//        {
//            var parts = apInfoString.Split("[");
//            string replacePattern = @"[\[\]]";
//            this.LoggerVersionInfo = Regex.Replace(parts[1], replacePattern, string.Empty);
//            this.VehicleInfo = Regex.Replace(parts[2], replacePattern, string.Empty);
//            this.MapInfo = Regex.Replace(parts[3], replacePattern, string.Empty);
//            this.DataSet = new List<LoggerDataSet>();
//        }
//        public DataSetInfo()
//        {
//            this.DataSet = new List<LoggerDataSet>();
//        }
//        public int Id { get; set; }

//        public List<LoggerDataSet> DataSet { get; set; }

//        public string LoggerVersionInfo { get; set; }
//        public string VehicleInfo { get; set; }
//        public string MapInfo { get; set; }
//    }
//}
