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
    public class TeacherRepository : ITeacherRepository
    {
        public void AddTeacher(Teacher teacher)
        {
            InMemorryDb.Users.Add(teacher);
        }

        public List<Teacher> GetAll()
        {
            List<Teacher> teachers = new List<Teacher>();
            var users = InMemorryDb.Users;
            foreach (var user in users)
            {
                if (user is Teacher)
                {
                    teachers.Add((Teacher)user);
                }
            }
            return teachers;
        }

        public Result UpdateTeacher(int teacherId,int courseID)
        {
            var course = InMemorryDb.AllCourses.FirstOrDefault(x => x.Id == courseID);
            var teacher = (Teacher)InMemorryDb.Users.FirstOrDefault(x => x.Id == teacherId);
            if (course != null || teacher != null)
            {
                teacher.courses.Add(course);
                return new Result(true, "Course Successfully Added");
            }
            else
            {
                return new Result(false, "Invalid Course Or Teacher Id");
            }
        }

        public void DeleteTeacher(Teacher teacher)
        {
            InMemorryDb.Users.Remove(teacher);
        }
    }
}
