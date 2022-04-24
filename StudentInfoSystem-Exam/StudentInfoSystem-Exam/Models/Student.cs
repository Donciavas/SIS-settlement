using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentInfoSystem_Exam.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(20)]
        public string LastName { get; set; }
        public Department Department { get; set; }
        public List<Lecture> ListLecture { get; set; }

        public override string ToString()
        {
            return $"{Name} {LastName}";
        }
    }
}
