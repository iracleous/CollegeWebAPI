using CollegeWebAPI.dtos;
using CollegeWebAPI.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeWebAPI.services
{
    public class CollegeServices
    {
        public List<Student> GetStudents(int howMany)
        {
            List<Student> students;
            using CollegeDbContent college = new CollegeDbContent();
            students = college.Students
                .Take(howMany)
                .ToList();
            return students;
        }

        public Student CreateStudent(StudentDto studentDto)
        {
            Student s = new Student
            {
                Name = studentDto.Name,
                Address = studentDto.Address + " GR",
                Dob = studentDto.Dob,
            };

            using CollegeDbContent college = new CollegeDbContent();
            college.Students.Add(s);
            college.SaveChanges();
            return s;
        }

        public ReturnData<Student> GetStudent(int studentId)
        {
            using CollegeDbContent college = new CollegeDbContent();
            Student student = college.Students.Find(studentId);
            return new ReturnData<Student>
            {
                Data = student,
                Error = (student == null) ? 1 : 0,
                Description = (student == null) ? "no such student id= "
                + studentId : "ok"
            };

        }


        public ReturnData<List<Student>> GetStudent(string studentName)
        {
            using CollegeDbContent college = new CollegeDbContent();
            List<Student> students = college.Students
                .Where(s => s.Name.StartsWith(studentName)).ToList();
            return new ReturnData<List<Student>>
            {
                Data = students,
                Error = (students == null) ? 1 : 0,
                Description = (students == null) ? "no such student name= "
                + studentName : "ok"
            };

        }




        public ReturnData<Student> UpdateStudent(int studentId, StudentDto studentDto)
        {
            if (studentDto == null)
            {
                return new ReturnData<Student>
                {
                    Error = 1001,
                    Description = "no data were given"
                };
            }

            using CollegeDbContent college = new CollegeDbContent();
            Student student = college.Students.Find(studentId);
            if (student == null)
            {
                return new ReturnData<Student>
                {
                    Error = 1002,
                    Description = "no such studentId"
                };
            }
            if (studentDto.Address != null)
                student.Address = studentDto.Address;
            if (studentDto.Name != null)
                student.Name = studentDto.Name;

            college.SaveChanges();
            return new ReturnData<Student>
            {
                Data = student,
                Error = 0,
                Description = "no errors"
            };
        }


        public ReturnData<Department>  Register(int studentId, DepartmentDto departmentDto)
        {
            return null;
        }


        public ReturnData<List<MarkModule>> AddMarks( int studentId, MarksDto marksDto)
        {
              return null;
        }


        public ReturnData<List<MarkModule>> GetMarks(  int studentId)
        {
               return null;
        }



    }
}
