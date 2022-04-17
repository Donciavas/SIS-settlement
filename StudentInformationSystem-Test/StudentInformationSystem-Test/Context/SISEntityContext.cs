using Microsoft.EntityFrameworkCore;
using StudentInformationSystem_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem_Test.Context
{
    internal class SISEntityContext : DbContext
    {
        public DbSet<DepartmentEntity> DepartmentEntities { get; set; }
        public DbSet<LectureEntity> LectureEntities { get; set; }
        public DbSet<StudentEntity> StudentEntities { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Server=localhost;Database=SISApplication;Trusted_Connection=True;");
    }
}
