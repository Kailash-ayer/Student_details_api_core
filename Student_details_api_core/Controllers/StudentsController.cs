using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_details_api_core.Models;
using Student_details_api_core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_details_api_core.Controllers
{
    [Route("api/[controller]")] //define path
    [ApiController] //it provide automatic model validation
    public class StudentsController : ControllerBase
    {
        //consturctor
        private readonly IStudentsRepository _studentsRepository;
        public StudentsController(IStudentsRepository studentsReporitory)
        {
            _studentsRepository = studentsReporitory;
        }

        [HttpGet]
        public async Task<IEnumerable<Students>> GetStudents()
        {
            return await _studentsRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Students>> GetStudents(int id)
        {
            return await _studentsRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Students>> PostStudents([FromBody] Students student)
        {
            var newBbook = await _studentsRepository.Create(student);
            return CreatedAtAction(nameof(GetStudents), new { id = newBbook.Id }, newBbook);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutStudents(int id, [FromBody] Students student)
        {
            if (id != student.Id)
            {
                //return BadRequest();
            }
            await _studentsRepository.Update(student);

            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var studentToDelete = await _studentsRepository.Get(id);
            if (studentToDelete == null)
                return NoContent();

            await _studentsRepository.Delete(studentToDelete.Id);
            return NoContent();
        }
    }
}
