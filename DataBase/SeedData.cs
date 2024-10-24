using Golestan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golestan.DataBase
{
    public static class SeedData
    {
        public static void Seed()
        {
            Operator @operator = new Operator("Frau", "Merkel", "admin@gmail.com");
            @operator.SetPassword("Operator.Password");
            @operator.SetId();
            @operator.SetActive();
            InMemorryDb.Users.Add(@operator);


            // define some defualt teachers
            Teacher teacher1 = new Teacher("DR.Mostafa", "Hossieni", "DR.MostafaHossieni@gmail.com");
            teacher1.SetPassword("teacher1.Password");
            teacher1.SetId();
            teacher1.SetActive();
            InMemorryDb.Users.Add(teacher1);

            Teacher teacher2 = new Teacher("Rasool", "Yekta", "RasoolYekta@gmail.com");
            teacher2.SetId();
            teacher2.SetActive();
            InMemorryDb.Users.Add(teacher2);

            // define some default courses

            CourseSchedule courseSchedule1 = new CourseSchedule(DayOfWeek.Saturday,DayOfWeek.Monday,TimeSpan.Parse("10:00"),TimeSpan.Parse("12:00"));
            Course course1 = new Course(1, "Os", 3, teacher1, 30, courseSchedule1);
            InMemorryDb.AllCourses.Add(course1);
            CourseSchedule courseSchedule2 = new CourseSchedule(DayOfWeek.Sunday, DayOfWeek.Tuesday, TimeSpan.Parse("10:00"), TimeSpan.Parse("12:00"));
            Course course2 = new Course(2,"DS",3, teacher2, 30, courseSchedule2);
            course2.Precourses.Add(course1);
            InMemorryDb.AllCourses.Add(course2);
            


            // define some default students
            Student student1 = new Student("st1Name","st1LastName","st1@gmail.com");
            student1.SetPassword("st1@Pass");
            student1.SetId();
            student1.SetActive();
            InMemorryDb.Users.Add(student1);
            Student student2 = new Student("st2Name", "st2LastName", "st2@gmail.com");
            student2.SetId();
            student2.SetActive();
            InMemorryDb.Users.Add(student2);
            Student student3 = new Student("st3Name", "st3LastName", "st3@gmail.com");
            student3.SetId();
            student3.SetActive();
            InMemorryDb.Users.Add(student3);



        }
    }
}
