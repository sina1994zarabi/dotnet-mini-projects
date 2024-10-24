using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golestan.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Unit { get; set; }
        public int Cap { get; set; }
        public Teacher Teacher { get; set; }
        public CourseSchedule Schedule { get; set; }
        public List<Course> Precourses { get; set; } = new List<Course>();

        public Course(int id,string title,int unit, Teacher teacher, int cap,CourseSchedule sc)
        {
            Title = title;
            Unit = unit;
            Teacher = teacher;
            Cap = cap;
            Schedule = sc;
            Id = id;
        }

        public override string ToString()
        {
            return $"ID: {Id}\nTitle: {Title}\nUnit: {Unit}\nCapacity: {Cap}\n" +
                $"Teacher: {Teacher.ToString()}\nSchedule: {Schedule.ToString()}\n" +
                $"PreRequisites: {this.DisplayPreCourses()}";
        }

        public string DisplayPreCourses()
        {
            string result = "";
            if (Precourses == null)
            {
                result = "No Pre Requisite Course";
            }
            else
            {
                foreach (Course course in Precourses)
                {
                    result += $"Id: {course.Id} - Title: {course.Title}\n";
                }
            }
            return result;
        }
    }
}
