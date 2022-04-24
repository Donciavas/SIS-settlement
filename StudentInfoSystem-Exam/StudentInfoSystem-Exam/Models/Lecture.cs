using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentInfoSystem_Exam.Models
{
    public class Lecture
    {
        public Guid Id { get; set; }
        [StringLength(20)]
        public string LectureName { get; set; }
        public List<Student> Student { get; set; }
        public List<Department> ListDepartments { get; set; }

        public override string ToString()
        {
            return $"{LectureName}";
        }
    }
}
