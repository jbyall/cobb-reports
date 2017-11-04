using System;
using System.Collections.Generic;
using System.Text;

namespace CobbReports.Domain
{
    public class Log
    {
        public int Id { get; set; }

        public int LogInfoId { get; set; }
        public LogInfo LogInfo { get; set; }

        public double? Time { get; set; }
        public double? AccelPosition { get; set; }
        public double? AmbientAirTemp { get; set; }
        public double? BaroPressure { get; set; }
        public double? Boost { get; set; }
        public int? GearPosition { get; set; }
        public double? IgnitionTiming { get; set; }
        public int? IntakeTemp { get; set; }
        public int? IntakeTempManifold { get; set; }
        public double? ManAbsPress { get; set; }
        public int? RPM { get; set; }
        public double? TDBoostError { get; set; }
        public double? TDIntegral { get; set; }
        public double? TDProportional { get; set; }
        public double? TargetBoost { get; set; }
        public double? TargetBoostAbs { get; set; }
        public double? TargetThrottle { get; set; }
        public int? ThrottlePos { get; set; }
        public int? VehicleSpeed { get; set; }
        public double? WastegateDuty { get; set; }
        public double? WategateMax { get; set; }
    }
}
