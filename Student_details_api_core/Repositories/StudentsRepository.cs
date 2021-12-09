using Microsoft.EntityFrameworkCore;
using Student_details_api_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_details_api_core.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
        //constructor
        public readonly StudentContext _context;
        public StudentsRepository(StudentContext context)
        {
            this._context = context;
        }
     

        public async Task<Students> Create(Students students)
        {
            _context.Student.Add(students);
            await _context.SaveChangesAsync();
            return students;
        }

        public async Task Delete(int id)
        {
            var studentToDelete = await _context.Student.FindAsync(id);
            _context.Student.Remove(studentToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Students>> Get()
        {
            return await _context.Student.ToListAsync();
        }

        public async Task<Students> Get(int id)
        {
            return await _context.Student.FindAsync(id);
        }

        public async Task Update(Students students)
        {
            _context.Entry(students).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
