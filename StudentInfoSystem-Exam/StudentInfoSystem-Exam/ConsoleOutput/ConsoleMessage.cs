using StudentInfoSystem_Exam.Models;
using System;
using System.Collections.Generic;

namespace StudentInfoSystem_Exam
{
    public static class ConsoleMessage
    {
        public static void DiplayMainWindow()
        {
            Console.Clear();
            Console.WriteLine("                Student information system");
            Console.WriteLine("");
            Console.WriteLine("Write a number and press 'Enter' key, which option you want to execute below:");
            Console.WriteLine("");
            Console.WriteLine("  1 - Create department with lectures and students");
            Console.WriteLine("  2 - Create and add students and lectures to existing deparment");
            Console.WriteLine("  3 - Create lecture and add to existing department");
            Console.WriteLine("  4 - Create student in existing departmentand and assign lectures");
            Console.WriteLine("  5 - Transfer the student to another department and assign lectures");
            Console.WriteLine("  6 - Display all students in the department");
            Console.WriteLine("  7 - Display all lectures of the departments");
            Console.WriteLine("  8 - Display all lectures by student");
            Console.WriteLine("");
            Console.WriteLine("  9 - Exit application");
            Console.WriteLine("_____________________________________________________________________________");
        }
        public static void WrongInputMessage()
        {
            Console.WriteLine("");
            Console.WriteLine("! Wrong input. Press any key to continue");
            Console.WriteLine("");
            Console.ReadKey();
        }
        public static void ContinueMessage()
        {
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue");
            Console.WriteLine("");
            Console.ReadKey();
        }
        public static void BackToPreviousWindowMessage(int cmdNumber)
        {
            Console.WriteLine("");
            Console.WriteLine($"{cmdNumber} - Go back to previous window");
            Console.WriteLine("");
        }
        public static void LectureSelectionWindow(List<Lecture> dbListLecture, List<Lecture> listLectures)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Create new lecture or select lectures to bind to the department");
            Console.WriteLine("");
            foreach (var lecture in dbListLecture)
            {
                Console.WriteLine($"{dbListLecture.IndexOf(lecture) + 1} - {lecture}");
            }
            Console.WriteLine("");
            Console.WriteLine($"{dbListLecture.Count + 1} - Add new lecture to database and department");
            Console.WriteLine($"{dbListLecture.Count + 2} - Continue to next step 'Add students To department'");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Existing lecture assigned to department");
            Console.WriteLine("_____________________________________________________________________________");
            foreach (var lecture in listLectures)
            {
                Console.WriteLine($"{lecture}");
            }
            Console.WriteLine("_____________________________________________________________________________");
        }
        public static void DepartmentForLectureSelectionWindow(List<Department> dbListDepartment, List<Department> listDepartments)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Assign existing departments to the lecture");
            Console.WriteLine("");
            foreach (var department in dbListDepartment)
            {
                Console.WriteLine($"{dbListDepartment.IndexOf(department) + 1} - {department}");
            }
            Console.WriteLine("");
            Console.WriteLine($"{dbListDepartment.Count + 1} - Back to main menu");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("To lecture assigned departments");
            Console.WriteLine("");
            foreach (var department in listDepartments)
            {
                Console.WriteLine($"{department}");
            }
            Console.WriteLine("");
        }
        public static void StudentSelectionWindow(List<Student> departmentSudentsList)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Create new student or select student to add lectures");
            Console.WriteLine("");
            foreach (var DepartmentStudent in departmentSudentsList)
            {
                Console.WriteLine($"{departmentSudentsList.IndexOf(DepartmentStudent) + 1} - {DepartmentStudent}");
            }
            Console.WriteLine("");
            Console.WriteLine($"{departmentSudentsList.Count + 1} - Add new student to department");
            Console.WriteLine($"{departmentSudentsList.Count + 2} - Back to main menu");
            Console.WriteLine("");
        }
        public static void StudentLectureSelectionWindow(List<Lecture> departmentListLecture, List<Lecture> studentListLecture)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Add department lecture to student");
            Console.WriteLine("");
            foreach (var lecture in departmentListLecture)
            {
                Console.WriteLine($"{departmentListLecture.IndexOf(lecture) + 1} - {lecture}");
            }
            Console.WriteLine("");
            Console.WriteLine($"{departmentListLecture.Count + 1} - Back to main menu");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Lectures assigned to student");
            Console.WriteLine("_____________________________________________________________________________");
            foreach (var lecture in studentListLecture)
            {
                Console.WriteLine($"{lecture}");
            }
            Console.WriteLine("_____________________________________________________________________________");
        }
        public static void DepartmentSelectionWindow(List<Department> listDepartments)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Select department");
            Console.WriteLine("");
            foreach (var department in listDepartments)
            {
                Console.WriteLine($"{listDepartments.IndexOf(department) + 1} - {department}");
            }
            Console.WriteLine("");
            Console.WriteLine($"{listDepartments.Count + 1} - Back to main menu");
            Console.WriteLine("");
        }
        public static void StudentTransferSelectionWindow(List<Student> listStudents)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Select student from department for trasfer");
            Console.WriteLine("");
            foreach (var student in listStudents)
            {
                Console.WriteLine($"{listStudents.IndexOf(student) + 1} - {student}");
            }
            Console.WriteLine("");
            Console.WriteLine($"{listStudents.Count + 1} - Back to main menu");
            Console.WriteLine("");
        }
    }
}
