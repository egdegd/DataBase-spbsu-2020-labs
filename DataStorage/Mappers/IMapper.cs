using System;
using System.Data.SqlClient;

namespace DataStorage.Mappers
{
    public interface IMapper<out T>
    {
        T ReadItem(SqlDataReader rd);
    }

    public class CourseDTOMapper : IMapper<String>
    {
        public String ReadItem(SqlDataReader rd)
        {
            return (string)rd["course_name"];
        }
    }

    public class StudentDTOMapper : IMapper<Student>
    {
        public Student ReadItem(SqlDataReader rd)
        {
            return new Student
            {
                lastName = (string)rd["last_name"],
                firsName = (string)rd["first_name"]
            };
        }
    }

    public class StudentGradeDTOMapper : IMapper<StudentGrade>
    {
        public StudentGrade ReadItem(SqlDataReader rd)
        {
            return new StudentGrade
            {
                lastName = (string)rd["last_name"],
                firsName = (string)rd["first_name"],
                grade = (int)rd["grade"]
            };
        }
    }

    public class GradeDTOMapper : IMapper<int>
    {
        public int ReadItem(SqlDataReader rd)
        {
            return (int)rd["grade"];
        }
    }
}
