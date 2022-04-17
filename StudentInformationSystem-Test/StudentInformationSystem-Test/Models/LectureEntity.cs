using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem_Test.Models
{
    internal class LectureEntity
    {
        public Guid Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(20)]
        public virtual List<DepartmentEntity> DepartmentEntities { get; set; }

        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; }
        public virtual DepartmentEntity Department { get; set; }

        public LectureEntity(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            DepartmentEntities = new List<DepartmentEntity>();
        }

        public LectureEntity(Guid id)
        {
            Id = id;
        }
    }
}
