using Golestan.Contracts;
using Golestan.Entities;
using Golestan.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Golestan.Services
{
    public class StudentService
    {
        IStudentRepository _studentRepository;
        ICourseRepository _courseRepository;

        public StudentService()
        {
            _studentRepository = new StudentRepository();
            _courseRepository = new CourseRepository();
        }


        // select & Register Course

        public Result SelectCourse(int courseId)
        {
            var newCourse = _courseRepository.GetAll().FirstOrDefault(x => x.Id == courseId);
            var currentUser = _studentRepository.GetCurrentStudent();
            if (currentUser.courses == null)
            {
                currentUser.courses.Add(newCourse);
                _courseRepository.DecreaseCapacity(newCourse.Id);
                return new Result(true, "Course Registered Successfully");
            }
            if (newCourse != null)
            {
                if (!IsDuplicate(currentUser.courses, newCourse))
                {
                    if (!HasTimeConflict(currentUser.courses, newCourse))
                    {
                        if (newCourse.Cap >= 1)
                        {
                            if (currentUser.courses.Sum(x => x.Unit) + newCourse.Unit < 20 )
                            {
                                currentUser.courses.Add(newCourse);
                                _courseRepository.DecreaseCapacity(newCourse.Id);
                                return new Result(true, "Course Registered Successfully");
                            }
                            else
                            {
                                return new Result(false, "You Have Reached The Limit");
                            }
                        }
                        else
                        {
                            return new Result(false, "No Room for a new student");
                        }
                    }
                    else
                    {
                        return new Result(false, "Time Conflict Error");
                    }
                }
                else
                {
                    return new Result(false, "Course Already Selected");
                }
            }
            else
            {
                return new Result(false, "Course Could not be found");
            }
        }

        public bool IsDuplicate(List<Course> courses, Course newCourse)
        {
            if (courses == null)
            {
                return false;
            }
            foreach (var course in courses)
            {
                if (course.Id == newCourse.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasTimeConflict(List<Course> courses, Course newCourse)
        {
            if (courses == null)
            {
                return false;
            }
            foreach (var course in courses)
            {
                var sc = course.Schedule;
                if (sc.Day1 == newCourse.Schedule.Day1)
                {
                    if (sc.Day2 == newCourse.Schedule.Day2)
                    {
                        if (sc.Starttime == newCourse.Schedule.Starttime)
                        {
                            return true;
                        }
                    }
                    else if (sc.Starttime == newCourse.Schedule.Starttime)
                    {
                        return true;
                    }                    
                }
                else if (sc.Day2 == newCourse.Schedule.Day2)
                {
                    if (sc.Starttime == newCourse.Schedule.Starttime)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        
    }
}
