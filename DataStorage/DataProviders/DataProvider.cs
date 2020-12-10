using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataStorage.Mappers;
using SqlHelper;

namespace DataStorage.DataProviders
{
    public class DataProvider
    {
        public static IList<String> GetAllCourses()
        {
            string sqlQuery = XmlStrings.GetString(Tables.Course, "GetAllCourses");
            var result = DBHelper.GetData(
                new CourseDTOMapper(),
                sqlQuery);
            return result;
        }

        public static IList<Student> GetAllStudents()
        {
            string sqlQuery = XmlStrings.GetString(Tables.Student, "GetAllStudents");
            var result = DBHelper.GetData(
                new StudentDTOMapper(),
                sqlQuery);
            return result;
        }
        public static IList<StudentGrade> StudentsGrade(string courseName)
        {
            string sqlQuery = XmlStrings.GetString(Tables.StudentGrade, "StudentsGrade");
            SqlParameter param = new SqlParameter("@courseName", courseName);
            var result = DBHelper.GetData(
                new StudentGradeDTOMapper(),
                sqlQuery, param);
            return result;
        }

        public static IList<int> StudentGrade(string courseName, string lastName)
        {
            string sqlQuery = XmlStrings.GetString(Tables.StudentGrade, "StudentGrade");
            SqlParameter param1 = new SqlParameter("@courseName", courseName);
            SqlParameter param2 = new SqlParameter("@lastName", lastName);
            var result = DBHelper.GetData(
                new GradeDTOMapper(),
                sqlQuery, param1, param2);
            return result;
        }
        public static void AddGrade(string courseName, string lastName, string grade)
        {
            string sqlQuery = XmlStrings.GetString(Tables.StudentGrade, "AddGrade");
            SqlParameter param1 = new SqlParameter("@courseName", courseName);
            SqlParameter param2 = new SqlParameter("@lastName", lastName);
            SqlParameter param3 = new SqlParameter("@grade", grade);
            DBHelper.GetData(new GradeDTOMapper(), sqlQuery, param1, param2, param3);
        }
    }
}
