using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicoPlaca
{
    public class PicoPlaca
    {      
        public Schedule schedule_time { get; set; }        
        public Dictionary<string, int[]> restriction { get; set; }

    }

    public class Schedule
    {        
        public TimeSpan start_morning { get; set; }
        public TimeSpan end_morning { get; set; }
        public TimeSpan star_afternoon { get; set; }
        public TimeSpan end_afternoon { get; set; }       

    }
}
