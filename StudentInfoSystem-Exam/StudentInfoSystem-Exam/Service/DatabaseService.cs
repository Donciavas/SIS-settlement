﻿using Microsoft.EntityFrameworkCore;
using StudentInfoSystem_Exam.Context;
using StudentInfoSystem_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentInfoSystem_Exam.Contexts
{
    public class DatabaseService
    {
        private readonly static SISContext _dbContext = new SISContext();
        public Department GetOrCreateDepartment(string departmentName)
        {
            var department = _dbContext.Departments.SingleOrDefault(x => x.DepartmentName == departmentName);
            if (department == null)
            {
                department = new Department { Id = Guid.NewGuid(), DepartmentName = departmentName };
                _dbContext.Departments.Add(department);
                _dbContext.SaveChanges();
            }
            return department;
        }
        public Lecture GetOrCreateLecture(string lectureName)
        {
            var lecture = _dbContext.Lectures.FirstOrDefault(x => x.LectureName == lectureName);
            if (lecture == null)
            {
                lecture = new Lecture { Id = Guid.NewGuid(), LectureName = lectureName };
                _dbContext.Lectures.Add(lecture);
                _dbContext.SaveChanges();
            }
            return lecture;
        }
        public Student GetOrCreateSudent(string name, string lastName, Department department)
        {
            var student = _dbContext.Student.Where(x => x.Name == name && x.LastName == lastName).SingleOrDefault();
            if (student == null)
            {
                student = new Student
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    LastName = lastName,
                    Department = department,
                    ListLecture = new List<Lecture>()
                };
                _dbContext.Student.Add(student);
                _dbContext.SaveChanges();
            }
            return student;
        }
        public Student GetOrCreateSudent(Student student, Department department)
        {
            var newStudent = new Student
            {
                Id = student.Id,
                Name = student.Name,
                LastName = student.LastName,
                Department = department,
                ListLecture = new List<Lecture>()
            };
            _dbContext.Student.Add(newStudent);
            _dbContext.SaveChanges();
            return student;
        } 
        public List<Department> GetDepartmentsList()
        {
            return _dbContext.Departments.ToList();
        }
        public List<Department> GetDepartmentsListWhithLecture()
        {
            return _dbContext.Departments.Include(lect => lect.ListLectures).ToList();
        }
        public List<Department> GetDepartmentListByLecture(Lecture lecture)
        {
            return _dbContext.Departments.Where(x => x.ListLectures.Contains(lecture)).ToList();
        }
        public List<Student> GetStudentListByDepartment(Department department)
        {
            return _dbContext.Student.Where(x => x.Department == department).ToList();
        }
        public List<Student> GetStudentListWhithLecture()
        {
            return _dbContext.Student.Include(student => student.ListLecture).ToList();
        }
        public bool CheckIfDepartmentExist(string departmentName)
        {
            return _dbContext.Departments.Any(x => x.DepartmentName == departmentName);
        }
        public bool CheckIfStudentExist(string name, string lastName)
        {
            return _dbContext.Student.Any(x => x.Name == name && x.LastName == lastName);
        }
        public bool CheckIfLectureExist(string lectureName)
        {
            return _dbContext.Lectures.Any(x => x.LectureName == lectureName);
        }
        public void AssingDepartmentToLecture(Lecture lecture, Department department)
        {
            var existingLecture = _dbContext.Lectures.Where(x => x.LectureName == lecture.LectureName)
                                                     .Include(lectures => lectures.ListDepartments).SingleOrDefault();
            if (existingLecture != null)
            {
                var existingDepartment = existingLecture.ListDepartments
                    .Where(c => c.Id == department.Id)
                    .SingleOrDefault();
                if (existingDepartment == null)
                {
                    existingLecture.ListDepartments.Add(department);
                    _dbContext.SaveChanges();
                }
            }
        }
        public void AssingLectureToDepartment(Department department, Lecture lecture)
        {
            var existingDepartment = _dbContext.Departments.Where(x => x.DepartmentName == department.DepartmentName).Include(departments => departments.ListLectures).SingleOrDefault();
            if (existingDepartment != null)
            {
                var existingLecture = existingDepartment.ListLectures
                    .Where(c => c.Id == lecture.Id)
                    .SingleOrDefault();

                if (existingLecture == null)
                {
                    existingDepartment.ListLectures.Add(lecture);
                    _dbContext.SaveChanges();
                }
            }
        }
        public void AssingLectureToStudent(Student student, Lecture lecture)
        {
            var existingStudent = _dbContext.Student.Where(x => x.Name == student.Name && x.LastName == student.LastName)
                                                    .Include(students => students.ListLecture).SingleOrDefault();
            if (existingStudent != null)
            {
                var existingLecture = existingStudent.ListLecture
                    .Where(c => c.Id == lecture.Id)
                    .SingleOrDefault();

                if (existingLecture == null)
                {
                    existingStudent.ListLecture.Add(lecture);
                    _dbContext.SaveChanges();
                }
            }
        }
        public List<Lecture> GetAllLectures()
        {
            return _dbContext.Lectures.ToList();
        }
        public List<Lecture> GetAllLecturesByDepartment(Department department)
        {
            return _dbContext.Lectures.Include(lecture => lecture.ListDepartments).Where(x => x.ListDepartments.Contains(department)).ToList();
        }
        public List<Lecture> GetAllLecturesBySudent(Student student)
        {
            return _dbContext.Lectures.Include(lecture => lecture.Student).Where(x => x.Student.Contains(student)).ToList();
        }
        public List<Student> GetAllStudentsOfDepartment(string depertmentName)
        {
            return _dbContext.Student.Include(department => department.Department).Where(x => x.Department.DepartmentName == depertmentName).ToList();
        }
        public void RemoveStudent(Student student)
        {
            var deletestudent = _dbContext.Student.Where(x => x.Equals(student)).Include(students => students.ListLecture).SingleOrDefault();
            _dbContext.Student.Remove(deletestudent);
            _dbContext.SaveChanges();
        }
    }
}
