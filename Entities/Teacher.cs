using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golestan.Entities
{
    public class Teacher : User
    {
        public List<Course> courses { get; set; } = new List<Course>();

        public Teacher(string firstName,string lastName,string email) : base(firstName,lastName,email)
        {
            
        }

        
        public override void SetId()
        {
            Random random = new Random();
            int id = random.Next(200, 300);
            this.Id = id;
        }
    }
}
