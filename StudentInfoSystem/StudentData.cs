using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    static class StudentData
    {
        static private List<Student> _testStudents;
        static public List<Student> TestStudents
        {
            get 
            {
                return _testStudents = new List<Student>
                {
                    new Student() 
                    {
                        StudentId = 1,
                        FirstName = "Cvetan",
                        Surname = "Marinov",
                        LastName = "Petkov",
                        Faculty = "FCST",
                        Programme = "CSE",
                        Qualification = (int) Qualification.BACHELOR,
                        Status = (int) Status.FULL_TIME,
                        FacultyNumber = "121217069",
                        Course = "3",
                        Stream="9",
                        Group="38"
                    },
                    new Student()
                    {
                        StudentId = 2,
                        FirstName = "Rositsa",
                        Surname = "Violetova",
                        LastName = "Kukunova",
                        Faculty = "FIT",
                        Programme = "CSS",
                        Qualification = (int) Qualification.BACHELOR,
                        Status = (int) Status.FULL_TIME,
                        FacultyNumber = "121217007",
                        Course = "4",
                        Stream="9",
                        Group="36"
                    }
                };
            }
            private set => _testStudents = value;
        }
        static public Student IsThereStudent(string facultyNumber)
        {
            StudentContext studentContext = new StudentContext();
            Student result = (from student in studentContext.Students where student.FacultyNumber.Equals(facultyNumber) select student).First();
            return result;
        }
        static public void DeleteStudentByFacultyNumber(string facultyNumber)
        {
            StudentContext studentContext = new StudentContext();
            Student delObj = (from student in studentContext.Students where student.FacultyNumber == facultyNumber select student).First();
            studentContext.Students.Remove(delObj);
            studentContext.SaveChanges();
        }
    }
}
