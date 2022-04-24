using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentInfoSystem_Exam.Models
{
    public class Department
    {
        public Guid Id { get; set; }
        [StringLength(20)]
        public string DepartmentName { get; set; }
        public List<Lecture> ListLectures { get; set; }
        public List<Student> ListStudents { get; set; }

        public override string ToString()
        {
            return $"{DepartmentName}";
        }
    }
}
