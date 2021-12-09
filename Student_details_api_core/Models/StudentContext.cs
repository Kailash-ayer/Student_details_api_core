using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_details_api_core.Models
{
    public class StudentContext : DbContext //inherit by dbcontext class
    {
        //Constructor

        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Students> Student { get; set; } //represnt the collection of student

    }
}
