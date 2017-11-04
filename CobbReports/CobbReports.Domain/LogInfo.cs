using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.RegularExpressions;

namespace CobbReports.Domain
{
    public class LogInfo
    {
        public LogInfo(string apInfoString)
        {
            var parts = apInfoString.Split("[");
            string replacePattern = @"[\[\]]";
            this.LoggerVersionInfo = Regex.Replace(parts[1], replacePattern, string.Empty);
            this.VehicleInfo = Regex.Replace(parts[2], replacePattern, string.Empty);
            this.MapInfo = Regex.Replace(parts[3], replacePattern, string.Empty);
            this.Logs = new List<Log>();
        }
        public LogInfo()
        {
            this.Logs = new List<Log>();
        }
        public int Id { get; set; }

        public List<Log> Logs{ get; set; }

        public string LoggerVersionInfo { get; set; }
        public string VehicleInfo { get; set; }
        public string MapInfo { get; set; }
        [NotMapped]
        public int LogCount { get; set; }
    }
}
