using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem_Test.Models
{
    public class StudentEntity
    {
        public Guid Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(20)]
        public string LastName { get; set; }
        [StringLength(20)]
        public virtual List<LectureEntity> LectureEntities { get; set; }
        public virtual DepartmentEntity Department { get; set; }

        public StudentEntity(string name, string lastName, List<LectureEntity> LectureEntities, DepartmentEntity department)
        {
            Id = Guid.NewGuid();
            Name = name;
            LastName = lastName;
            LectureEntities = new List<LectureEntity>(); 
            Department = department;
        }
        public StudentEntity()
        {
        }
    }
}
