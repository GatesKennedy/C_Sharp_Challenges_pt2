using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeStudentCourses
{
    [Serializable]
    public class Course
    {
        public int CourseId { get;  set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }

        public Course(int _courseId, string _courseName)
        {
            this.CourseId = _courseId;
            this.Name = _courseName;
            this.Students = new List<Student>();
        }

    }
}