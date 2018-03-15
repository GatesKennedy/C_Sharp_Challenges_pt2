using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeStudentCourses
{
    [Serializable]
    public class StudentGrades
    {
        public Student StudentInfo { get; set; }
        public Dictionary<string, int> Grades { get; set; }

        public StudentGrades(Student _student)
        {
            this.StudentInfo = _student;
            this.Grades = new Dictionary<string, int>();
        }

        public void UpdateGrade(string _courseName, Random rando)
        {
            int[] weightArray = new int[7] { 10, 40, 55, 65, 70, 75, 90 };
            int gradeBase = weightArray[rando.Next(0, 7)];
            int gradeResult = gradeBase + rando.Next(-10, 11);
            this.Grades.Add(_courseName, gradeResult);
        }

        public string DisplayGrades()
        {
            string resultString = "";
            foreach (var gradeRecord in Grades) resultString += "    [" + gradeRecord.Value + "/100] "+gradeRecord.Key+ "<br />";
            return resultString;
        }
    }
}