using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem_Test.Models
{
    public class LectureEntity
    {
        public Guid Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(20)]
        public virtual List<DepartmentEntity> DepartmentEntities { get; set; }
        //public virtual List<LectureEntity> LectureEntities { get; set; }
        [ForeignKey("department")]
        public Guid DepartmentId { get; set; }
        public LectureEntity(string name, List<DepartmentEntity> departmentEntities, /*List<LectureEntity> lectureEntities,*/ Guid departmentId)
        {
            Id = Guid.NewGuid();
            Name = name;
            DepartmentEntities = new List<DepartmentEntity>();
            /*LectureEntities = new List<LectureEntity>();
            LectureEntities = lectureEntities;*/
            DepartmentId = departmentId;
        }
        public LectureEntity(string name, Guid departmentId)
        {
            Name = name;
            DepartmentId = departmentId;
        }
        public LectureEntity()
        {
        }
    }
}
