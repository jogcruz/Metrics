using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataModels
{
    public class Job
    {
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public double TimeRunning { get; set; }
        public double TimeAverage { get; set; }
        public string Reason { get; set; }
    }
}