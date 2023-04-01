using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRestAPI.Data;
using StudentRestAPI.Models;
using StudentRestAPI.Repository;
using System.Linq.Expressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IRepository<Student> repository;

        public StudentController (IRepository<Student> repository)
        {
            this.repository = repository;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students =  await repository.ReadAll();
            return Ok(students);
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await repository.ReadOne(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // GET api/<StudentController>/search?name=john
        [HttpGet("search")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            Expression<Func<Student, bool>> criteria = (student) => student.Name.Contains(name);
            var students = await repository.ReadByCriteria(criteria);
            return Ok(students);
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<IActionResult> Post(Student student)
        {
            await repository.Create(student);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            await repository.Update(student);
            return NoContent();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await repository.ReadOne(id);
            if (student == null)
            {
                return NotFound();
            }

            await repository.Delete(student);
            return NoContent();
        }
    }
}
