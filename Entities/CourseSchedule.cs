using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golestan.Entities
{
    public class CourseSchedule
    {
        public DayOfWeek Day1 { get; set; }
        public DayOfWeek Day2 { get; set; }
        public TimeSpan Starttime { get; set; }
        public TimeSpan Endtime { get; set; }

        public CourseSchedule(DayOfWeek day1, DayOfWeek day2, TimeSpan starttime, TimeSpan endtime)
        {
            Day1 = day1;
            Day2 = day2;
            Starttime = starttime;
            Endtime = endtime;
        }

        public override string ToString()
        {
            return $"Days: {Day1} - {Day2}. Time: {Starttime} - {Endtime}";
        }
    }
}
