using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStorage;
using DataStorage.DataProviders;

namespace HW_13
{
    public class ConsoleClient
    {
        bool endApp = false;
        public void Run()
        {
            Help();

            while (!endApp)
            {
                string cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "help":
                        Help();
                        break;
                    case "c":
                        GetAllCourses();
                        break;
                    case "s":
                        GetAllStudents();
                        break;
                    case "g":
                        GetStidentsGrade();
                        break;
                    case "g2":
                        GetStidentGrade();
                        break;
                    case "u":
                        AddGrade();
                        break;
                    case "exit":
                        endApp = true;
                        break;

                }
            }
        }
        public void Help()
        {
            Console.WriteLine("Choose a command from the following list:");
            Console.WriteLine("\thelp - show a list of commands on the screen");
            Console.WriteLine("\tc - list of courses sorted by name.");
            Console.WriteLine("\ts - list of all students.");
            Console.WriteLine("\tg - list of students (last name and first name) who passed the course_name course <course_name>.");
            Console.WriteLine("\tg2 - grade of the student with the last name <last_name> for the course <course_name>.");
            Console.WriteLine("\tu - add the student with the last name <last_name> a <grade> for the course <course_name>");
            Console.WriteLine("\texit - end program execution");
        }
        public void GetAllCourses()
        {
            IList<String> courses = DataProvider.GetAllCourses();
            foreach (string c in courses)
            {
                Console.WriteLine(c);
            }
        }

        public void GetAllStudents()
        {
            IList<Student> students = DataProvider.GetAllStudents();
            foreach (Student s in students)
            {
                Console.WriteLine(s.lastName + ' ' + s.firsName);
            }
        }
        public void GetStidentsGrade()
        {
            Console.WriteLine("Name of course: ");
            string courseNmae = Console.ReadLine();
            IList<StudentGrade> studentsGrade = DataProvider.StudentsGrade(courseNmae);
            foreach (StudentGrade sg in studentsGrade)
            {
                Console.WriteLine(sg.lastName + ' ' + sg.firsName + ' ' + sg.grade);
            }
        }

        public void GetStidentGrade()
        {
            Console.WriteLine("Last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Name of course: ");
            string courseName = Console.ReadLine();
            IList<int> studentGrade = DataProvider.StudentGrade(courseName, lastName);
            foreach (int grade in studentGrade)
            {
                Console.WriteLine(grade);
            }
        }

        public void AddGrade()
        {
            Console.WriteLine("Last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Name of course: ");
            string courseName = Console.ReadLine();
            Console.WriteLine("Grade: ");
            string grade = Console.ReadLine();
            DataProvider.AddGrade(courseName, lastName, grade);
        }

    }
}
