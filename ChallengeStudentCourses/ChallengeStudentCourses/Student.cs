using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeStudentCourses
{
    [Serializable]
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; }

        public Student()
        {
            this.StudentId = 000000;
            this.Name = "unknown";
            this.Courses = new List<Course>();
        }
        public Student(Random rando, string fName, string lName)
        {
            this.StudentId = rando.Next(100000, 999999);
            this.Name = fName + " " + lName;
            this.Courses = new List<Course>();
        }  

        public string DisplayStudentName()
        {
            return "[#"+this.StudentId + "] " + this.Name+ "<br />";
        }

        public string DisplayStudentCourses()
        {
            string courseList = "";
            foreach (var studentCourse in this.Courses)
            {
                courseList += studentCourse.Name+"<br />";
            }
            return courseList;
        }
    }
}