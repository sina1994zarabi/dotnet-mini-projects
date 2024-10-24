using Golestan.Contracts;
using Golestan.DataBase;
using Golestan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golestan.Repository
{
    public class CourseRepository : ICourseRepository
    {
        
        public List<Course> GetAll()
        {
            return InMemorryDb.AllCourses;
        }

        public void AddCourse(Course course)
        {
            InMemorryDb.AllCourses.Add(course);
        }

        public void IncreaseCapacity(int courseId)
        {
            var course = InMemorryDb.AllCourses.FirstOrDefault(x => x.Id == courseId);
            course.Cap++;
        }

        public void DecreaseCapacity(int courseId)
        {
            var course = InMemorryDb.AllCourses.FirstOrDefault(x => x.Id == courseId);
            course.Cap--;
        }

        public void RemoveCourse(Course course)
        {
            InMemorryDb.AllCourses.Remove(course);
        }
    }
}
