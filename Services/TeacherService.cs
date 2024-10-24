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
    public class TeacherService
    {
        ITeacherRepository _teacherRepository;
        ICourseRepository _courseRepository;
        IUserRepository _userRepository;
        IStudentRepository _studentRepository;


        public TeacherService()
        {
            _teacherRepository = new TeacherRepository();
            _courseRepository = new CourseRepository();
            _userRepository = new UserRepository();
            _studentRepository = new StudentRepository();
        }

        
        public Result DefineNewCourse(int id,string title, int unit, string day1, string day2, string starttime, string endtime, Teacher teacher, int cap)
        {
            DayOfWeek firstDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), day1, true);
            DayOfWeek secondDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), day2, true);
            TimeSpan startTime = TimeSpan.Parse(starttime);
            TimeSpan endTime = TimeSpan.Parse(endtime);
            CourseSchedule sc = new CourseSchedule(firstDay, secondDay, startTime, endTime);
            Course newCourse = new Course(id,title, unit, teacher, cap, sc);
            _courseRepository.AddCourse(newCourse);
            _teacherRepository.UpdateTeacher(_userRepository.GetCurrentUser().Id,newCourse.Id);
            return new Result(true,"Course Successfully Created and Added");
        }

        public List<Student> GetStudents(int courseID)
        {
            var course = _courseRepository.GetAll().FirstOrDefault(x => x.Id == courseID);
            List<Student> result = new List<Student>();
            var students = _studentRepository.GetAll();
            foreach (var student in students)
            {
                foreach (var c in student.courses)
                {
                    if (c.Id == course.Id)
                    {
                        result.Add(student);
                    }
                }
            }
            return result;
        }
    }
}
