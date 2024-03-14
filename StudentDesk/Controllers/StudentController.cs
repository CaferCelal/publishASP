using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentDesk.Model;

namespace StudentDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase {
        private readonly IConfiguration _configuration;
        private StudentDao _dao;

        public StudentController(IConfiguration configuration) {
            _configuration = configuration;
            _dao = new StudentDao(_configuration);
        }

        [HttpPost]
        public IActionResult AddNewStudent([FromBody] Student student) {
            try {
                student.Id = 0;
                _dao.AddStudent(student);
                return Ok("A new student successfully added !");
            }
            catch (Exception ex) {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
