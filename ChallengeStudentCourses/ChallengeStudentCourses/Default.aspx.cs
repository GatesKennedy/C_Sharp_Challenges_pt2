using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeStudentCourses
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<Student> students = new List<Student>();
                ViewState.Add("Students", students);
                
                List<Course> courses = new List<Course>()
                {
                    new Course(1002, "Human Folly 231"),
                    new Course(1003, "Existential Crises 232"),
                    new Course(1021, "Fluid Mecanics 243"),
                    new Course(1022, "Ecology 244") 
                };
                ViewState.Add("Courses", courses);

                List<StudentGrades> studentGrades = new List<StudentGrades>();
                ViewState.Add("Grades", studentGrades);
            }
        }
        //const string studentsViewState = "Students";

        Random rando = new Random();

        List<string> nameTrashPile = new List<string>()
        {
            // First Names
            {"Chunk"},
            {"Bun"},
            {"Gumz" },
            {"Taggert" },
            {"Milk" },
            {"Graze" },
            {"Tiren" },
            {"Tred" },
            {"Brood" },
            //Last Names
            {"Bufflin" },
            {"Milton" },
            {"Pleth" },
            {"Gurmin" },
            {"Tuggins" },
            {"Shockton" }
            
        };

        protected void studentCreateButton_Click(object sender, EventArgs e)
        {
            GenerateStudent(out List<Student> studentList);
            GenerateGradeLog(studentList.Last(), out List<StudentGrades> gradesLog);
            AssignClasses(rando, studentList, gradesLog);
            studentCountLabel.Text = String.Format("There are now {0} students", studentList.Count);
        }

        public List<Student> GenerateStudent(out List<Student> students)
        {
            students = (List<Student>)ViewState["Students"];
            string fName = nameTrashPile.ElementAt(rando.Next(0, 9));
            string lName = nameTrashPile.ElementAt(rando.Next(9, 15));
            students.Add(new Student(rando, fName, lName));
            ViewState["Students"] = students;
            return students;
        }

        public void AssignClasses(Random rando, List<Student> studentList, List<StudentGrades> gradesLog)
        {
            List<Course> courses = (List<Course>)ViewState["Courses"];
            int[] cycleIndex = new int[7] { 0, 1, 2, 3, 0, 1, 2 };
            int tempIndex = (rando.Next(0, 4));
            for (int i = 0; i < 3; i++)
            {
                int courseIndex = cycleIndex[tempIndex + i];
                studentList.Last().Courses.Add(courses.ElementAt(courseIndex));
                courses.ElementAt(courseIndex).Students.Add(studentList.Last());
                gradesLog.Last().UpdateGrade(courses.ElementAt(courseIndex).Name, rando);
            }
            ViewState["Grades"] = gradesLog;
            ViewState["Courses"] = courses;
        }

        public List<StudentGrades> GenerateGradeLog(Student _currentStudent, out List<StudentGrades> gradesLog)
        {
            gradesLog = (List<StudentGrades>)ViewState["Grades"];
            string tempName = _currentStudent.Name;
            gradesLog.Add(new StudentGrades(_currentStudent));
            ViewState["Grades"] = gradesLog;
            return gradesLog;
        }

        protected void assignment1Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a List of Courses (add three example Courses ...
             * make up the details).  Each Course should have at least two
             * Students enrolled in them.  Use Object and Collection
             * Initializers.  Then, iterate through each Course and print
             * out the Course's details and the Students that are enrolled in
             * each Course. 
             */
            resultLabel.Text = "";
            List<Course> courses = (List<Course>)ViewState["Courses"];
            foreach (Course CourseItem in courses)
            {
                resultLabel.Text += "<h3>" + CourseItem.Name + " [Course #: "+ CourseItem.CourseId+"]</h3>";
                foreach (Student courseStudent in CourseItem.Students)
                {
                    resultLabel.Text += courseStudent.DisplayStudentName();
                }
            }
        }

        protected void assignment2Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a Dictionary of Students (add three example Students
             * ... make up the details).  Use the StudentId as the 
             * key.  Each student must be enrolled in two Courses.  Use
             * Object and Collection Initializers.  Then, iterate through
             * each student and print out to the web page each Student's
             * info and the Courses the Student is enrolled in.
             */

            resultLabel.Text = "";
            var students = (List<Student>)ViewState["Students"];
            foreach (Student studentMember in students)
            {
                resultLabel.Text += "<h3>"+studentMember.DisplayStudentName()+"</h3>";
                resultLabel.Text += studentMember.DisplayStudentCourses();
            }
        }

        protected void assignment3Button_Click(object sender, EventArgs e)
        {
            /*
             * We need to keep track of each Student's grade (0 to 100) in a 
             * particular Course.  This means at a minimum, you'll need to add 
             * another class, and depending on your implementation, you will 
             * probably need to modify the existing classes to accommodate this 
             * new requirement.  Give each Student a grade in each Course they
             * are enrolled in (make up the data).  Then, for each student, 
             * print out each Course they are enrolled in and their grade.
             */
            resultLabel.Text = "";
            var gradesLog = (List<StudentGrades>)ViewState["Grades"];
            foreach (StudentGrades studentMember in gradesLog)
            {
                resultLabel.Text += "<h3>" + studentMember.StudentInfo.Name + "</h3>";
                resultLabel.Text += studentMember.DisplayGrades();
            }
        }

        
    }
}