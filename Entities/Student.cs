using Golestan.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golestan.Entities
{
    public class Student : User
    {
        public string StudentNo { get; set; }
        public StudentStatusEnum Status { get; set; }
        public List<Course> courses { get; set; } = new List<Course>();

        public Student(string firstName,string lastName,string email) : base(firstName,lastName,email)
        {
            Status = StudentStatusEnum.Inactive;
        }

        public void ChangeStatus(StudentStatusEnum newStatus)
        {
            Status = newStatus;
        }

        public override void SetId()
        {
            Random random = new Random();
            int id = random.Next(100, 200);
            this.Id = id;
        }

        public override string ToString()
        {
            return $"Name: {this.Firstname} - {this.Lastname} _Student Number {this.StudentNo}";
        }

        public string DisplaySchedule()
        {
            string result = "";
            foreach (var course in this.courses)
            {
                result += course.Schedule.ToString() + "\n" + "*************";
            }
            return result;
        }
    }
}
