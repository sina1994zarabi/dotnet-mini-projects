using Golestan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golestan.Contracts
{
    public interface IStudentRepository
    {
        public Student CreateNewStudent(User newUser);

        public List<Student> GetAll();

        public Student GetCurrentStudent();

        public void AddStudent(Student student);

        public void RemoveStudent(Student student);
    }
}
