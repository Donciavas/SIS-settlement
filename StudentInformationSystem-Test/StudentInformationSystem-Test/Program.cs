using Microsoft.EntityFrameworkCore;
using StudentInformationSystem_Test.Context;
using StudentInformationSystem_Test.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace StudentInformationSystem_Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            using var dbContext = new SISEntityContext();
            var department = new DepartmentEntity(new Guid(), "Mathematics");
            dbContext.Add(department);
            List<DepartmentEntity> departmentEntities = new List<DepartmentEntity>
            {
                department
            };
            dbContext.Add(department);
            //dbContext.DepartmentEntities = departmentEntities;
            //var department3 = dbContext.DepartmentEntities.Where(department3 => department3.Id == new Guid("3FEE6644-B5A5-412F-D057-08DA22F710E5"));
            var lecture = new LectureEntity("Matrix", department.Id);
            dbContext.Add(lecture);
            List<LectureEntity> lectureEntities = new List<LectureEntity>
            {
                lecture
            };
            dbContext.Add(lecture);
            var student1 = new StudentEntity("Danziel", "Washington", lectureEntities, department);
            dbContext.Add(student1);
            //var department2 = new DepartmentEntity("Engineering", lecture1, student1);
            //var book = dbContext.Books.Where(book => book.Id == new Guid("F644B43D-87D3-42E9-CCD5-08DA1263F89B")).Include(x => x.Pages).First();
            //var department1 = new DepartmentEntity { Name = "Science"};
            dbContext.LectureEntities.Add(lecture);
            dbContext.SaveChanges();
                
            // naudoti grazinimui .ToList();
        }
    }
}
