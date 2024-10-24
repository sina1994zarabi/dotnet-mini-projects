using Golestan.Contracts;
using Golestan.Entities;
using Golestan.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golestan.Services
{
    public class CourseService
    {
        ICourseRepository _courseRepository;
        public List<Course> Pre { get; set; } = new List<Course>();

        public CourseService()
        {
            _courseRepository = new CourseRepository();
        }

        public CourseSchedule SetCourseSchedule(string day1, string day2, string starttime, string endtime)
        {
            DayOfWeek firstDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), day1, true);
            DayOfWeek secondDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), day2, true);
            TimeSpan startTime = TimeSpan.Parse(starttime);
            TimeSpan endTime = TimeSpan.Parse(endtime);
            CourseSchedule sc = new CourseSchedule(firstDay, secondDay, startTime, endTime);
            return sc;
        }

        public void AddPre(int courseID)
        {
            var course = _courseRepository.GetAll().FirstOrDefault(x => x.Id == courseID);
            Pre.Add(course);
        }

        public List<Course> GetCourses()
        { 
            return _courseRepository.GetAll();
        }
        
    }
}
