using Microsoft.EntityFrameworkCore;
using StudentInfoSystem_Exam.Models;


namespace StudentInfoSystem_Exam.Context
{
    public class SISContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Student> Student { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlServer($"Server = localhost; Database=StudentInfoSystem; Trusted_Connection=True;");
    }
}

