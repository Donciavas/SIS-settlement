using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace StudentInformationSystem_Test.Models
{
    public class DepartmentEntity
    {
        public Guid Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(20)]
        public virtual List<LectureEntity> LectureEntities { get; set; }
        public virtual List<StudentEntity> StudentEntities { get; set; }
        public DepartmentEntity(string name, List<LectureEntity> lectureEntities, List<StudentEntity> studentEntities)
        {
            Id = Guid.NewGuid();
            Name = name;
            LectureEntities = new List<LectureEntity>();
            StudentEntities = new List<StudentEntity>();
            LectureEntities = lectureEntities;
            StudentEntities = studentEntities;
        }
        public DepartmentEntity(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public DepartmentEntity()
        {
        }
    }
}
