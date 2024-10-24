using Golestan.Contracts;
using Golestan.DataBase;
using Golestan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Golestan.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public Student CreateNewStudent(User newUser)
        {
            Student newStudent = (Student)newUser;
            string studentNumber = "403111";
            Random random = new Random();
            for (int i = 0;i < 4;i++)
            {
                studentNumber += random.Next(0,10).ToString();
            }
            newStudent.StudentNo = studentNumber;
            return newStudent;
        }

        public List<Student> GetAll()
        {
            var users = InMemorryDb.Users;
            List<Student> result = new List<Student>();
            foreach (User user in users)
            {
                if (user is Student)
                {
                    result.Add((Student)user);
                }
            }
            return result;
        }

        public Student GetCurrentStudent()
        {
            return (Student)InMemorryDb.CurrentUser;
        }
        
        public void AddStudent(Student student)
        {
            InMemorryDb.Users.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            InMemorryDb.Users.Remove(student);
        }
    }
}
