using Golestan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golestan.Contracts
{
    public interface ITeacherRepository
    {
        public void AddTeacher(Teacher teacher);

        public List<Teacher> GetAll();

        public Result UpdateTeacher(int teacherID,int courseID);

        public void DeleteTeacher(Teacher teacher);
    }
}
