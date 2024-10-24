using Golestan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golestan.Contracts
{
    public interface ICourseRepository
    {

        public List<Course> GetAll();

        public void AddCourse(Course course);

        public void RemoveCourse(Course course);

        public void IncreaseCapacity(int courseId);

        public void DecreaseCapacity(int courseId);
    }
}
