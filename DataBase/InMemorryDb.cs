using Golestan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golestan.DataBase
{
    public static class InMemorryDb
    {
        public static User CurrentUser { get; set; }

        public static List<User> Users { get; set; } = new List<User>();

        public static List<Course> AllCourses { get; set; } = new List<Course>();
    }
}
