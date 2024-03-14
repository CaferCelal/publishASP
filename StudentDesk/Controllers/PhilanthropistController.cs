using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentDesk.Model;

namespace StudentDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhilanthropistController : ControllerBase {
        private readonly IConfiguration _configuration;
        private PhilanthropistDao _dao;

        public PhilanthropistController(IConfiguration configuration) {
            _configuration = configuration;
            _dao = new PhilanthropistDao(_configuration);
        }
        

        
        [HttpGet]
        public IActionResult GetPhilanthropists() // Plural for consistency
        {
            List<Philanthropist> philanthropists = _dao.GetAll();
            return StatusCode(201, philanthropists);
        }

        [HttpPost]
        public IActionResult AddNewPhilanthropist([FromBody] Philanthropist philanthropist)
        {
            try
            {
                // Remove the Id property (since it's automatically handled by the database)
                philanthropist.Id = 0; // Set to default value (or omit it altogether)
        
                _dao.AddPhilanthropist(philanthropist);
                return Ok("Philanthropist added successfully!");
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., invalid JSON format)
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
    }

