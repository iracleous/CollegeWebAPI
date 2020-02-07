using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeWebAPI.dtos;
using CollegeWebAPI.models;
using CollegeWebAPI.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CollegeWebAPI.Controllers
{
    [ApiController]
    [Route("")]
    public class CollegeController : ControllerBase
    {

        private readonly ILogger<CollegeController> _logger;

        public CollegeController(ILogger<CollegeController> logger)
        {
            _logger = logger;
        }



        [HttpGet("info")]
        public string ShowInfo()
        {
            return "hello";
        }

        [HttpGet("students")]
        public List<Student> GetStudents()
        {
            CollegeServices cs = new CollegeServices();
            return cs.GetStudents(20);
        }



        [HttpGet("studentByName/{name}")]
        public ReturnData<List<Student>> GetStudent([FromRoute] string name)
        {
            CollegeServices cs = new CollegeServices();
            return cs.GetStudent(name);
        }

        [HttpGet("student/{id}")]
        public ReturnData<Student> GetStudent([FromRoute] int id)
        {
            CollegeServices cs = new CollegeServices();
            return cs.GetStudent(id);
        }

        [HttpPost("student")]
        public Student CreateStudentController([FromBody]  StudentDto studentDto)
        {
            CollegeServices cs = new CollegeServices();
            return cs.CreateStudent(studentDto);

        }

        [HttpPut("student/{id}")]
        public ReturnData<Student> UpdateStudentController(
            [FromRoute] int id, [FromBody]  StudentDto studentDto)
        {
            CollegeServices cs = new CollegeServices();
            return cs.UpdateStudent(id, studentDto);
        }



        [HttpPost("student/{id}/registration")]
        public ReturnData<Department> Register([FromRoute] int id, [FromBody] DepartmentDto departmentDto )
        {
            CollegeServices cs = new CollegeServices();
            return cs.Register(id, departmentDto);
        }


        [HttpPost("student/{id}/marks")]
        public ReturnData<List<MarkModule>> AddMarks([FromRoute] int id, [FromBody] MarksDto marksDto)
        {
            CollegeServices cs = new CollegeServices();
            return cs.AddMarks(id, marksDto);
        }

        [HttpGet("student/{id}/marks")]
        public ReturnData<List<MarkModule>> GetMarks([FromRoute] int id)
        {
            CollegeServices cs = new CollegeServices();
            return cs.GetMarks(id);
        }


    }
}
