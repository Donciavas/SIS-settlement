using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem_Test.Models
{
    internal class StudentEntity
    {
        public Guid Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(20)]
        public string LastName { get; set; }
        //[StringLength(20)]
    }
}
