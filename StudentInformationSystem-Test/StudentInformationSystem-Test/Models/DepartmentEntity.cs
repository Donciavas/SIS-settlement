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

        public DepartmentEntity(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            //LectureEntities = new List<LectureEntity>();
            //StudentEntities = new List<StudentEntity>();
        }
    }
}
