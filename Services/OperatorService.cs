using Golestan.Contracts;
using Golestan.Entities;
using Golestan.Enums;
using Golestan.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golestan.Services
{
    public class OperatorService
    {
        IOperatorRepository _operatorRepository;
        IUserRepository _userRepository;
        IStudentRepository _studentRepository;
        ICourseRepository _courseRepository;
        

        public OperatorService()
        {
            _operatorRepository = new OperatorRepository();
            _userRepository = new UserRepository();
            _studentRepository = new StudentRepository();
        }

        public Result Activate(int userId)
        {
            var user = _userRepository.GetUsers().FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                user.SetActive();
                return new Result(true, "User Successfully Activated");
            }
            return new Result(false, "User Not Found");
        }

        public Result DeActivate(int userId)
        {
            var user = _userRepository.GetUsers().FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                user.Active = false;
                return new Result(true, "User Successfully DeActivated");
            }
            return new Result(false, "User Not Found");
        }

        public Result ChangeStudentStatus(string studentN,StudentStatusEnum status)
        {
            var student = _studentRepository.GetAll().FirstOrDefault(x => x.StudentNo == studentN);
            if (student != null)
            {
                student.Status = status;
                return new Result(true, "Done");
            }
            else
            {
                return new Result(false, "Student Not Found");
            }
        }

        public Result IncreaseCapacity(int courseID,int addition)
        {
            var course = _courseRepository.GetAll().FirstOrDefault(x => x.Id == courseID);
            if (course != null)
            {
                course.Cap += addition;
                return new Result(true, "Done");
            }
            else
            {
                return new Result(false, "Course Not Found");
            }
        }
    }
}
