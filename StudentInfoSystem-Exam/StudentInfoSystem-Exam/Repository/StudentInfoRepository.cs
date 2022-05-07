using StudentInfoSystem_Exam.Contexts;
using StudentInfoSystem_Exam.Models;
using System;
using System.Linq;

namespace StudentInfoSystem_Exam
{
    public class StudentInfoRepository
    {
        public readonly static DatabaseService _DatabaseService = new();
        public bool MainWindow()
        {
            ConsoleMessage.DisplayMainWindow();
            var userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    CreateDepartment();
                    return false;
                case "2":
                    AddLectureAndStudentToDepartment();
                    return false;
                case "3":
                    AddLectureToDepartment();
                    return false;
                case "4":
                    CreateSudentAndAddToDepartment();
                    return false;
                case "5":
                    TransferStudentToOtherDepartment();
                    return false;
                case "6":
                    DisplayDepartmentStudents();
                    return false;
                case "7":
                    DisplayDepartmentLectures();
                    return false;
                case "8":
                    DisplayStudentLectures();
                    return false;
                case "9":
                    return true;
                default:
                    ConsoleMessage.WrongInputMessage();
                    return false;
            }
        }
        public void CreateDepartment()
        {
            var exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("Enter a new department name: ");
                Console.WriteLine("-----------------------------------");
                var departmentName = Console.ReadLine();
                if (_DatabaseService.CheckIfDepartmentExist(departmentName))
                {
                    Console.WriteLine("");
                    Console.WriteLine($"! Department with this name: '{departmentName}' already exists");
                    Console.WriteLine("");
                    ConsoleMessage.ContinueMessage();
                    continue;
                }
                var department = _DatabaseService.GetOrCreateDepartment(departmentName);
                AddLecturesToDepartment(department);
                AddStudentToDepartment(department);

                Console.WriteLine("");
                Console.WriteLine("Process of creating Department with lectures and students is done.");
                Console.WriteLine("");
                ConsoleMessage.ContinueMessage();
                exit = true;
            }
        }
        public void AddLectureAndStudentToDepartment()
        {
            var exit = false;
            while (!exit)
            {
                var listDepartments = _DatabaseService.GetDepartmentsList();
                ConsoleMessage.DepartmentSelectionWindow(listDepartments);
                if (Int32.TryParse(Console.ReadLine(), out int command))
                {
                    if ((command > 0) && (command <= listDepartments.Count))
                    {
                        var department = listDepartments.ElementAt(command - 1);
                        AddLecturesToDepartment(department);
                        AddStudentToDepartment(department);
                        continue;
                    }
                    else if (command == listDepartments.Count + 1) exit = true;
                    else ConsoleMessage.WrongInputMessage();
                }
                else ConsoleMessage.WrongInputMessage();
            }
        }
        public void CreateSudentAndAddToDepartment()
        {
            var exit = false;
            while (!exit)
            {
                var listDepartments = _DatabaseService.GetDepartmentsList();
                ConsoleMessage.DepartmentSelectionWindow(listDepartments);
                if (Int32.TryParse(Console.ReadLine(), out int command))
                {
                    if ((command > 0) && (command <= listDepartments.Count))
                    {
                        var department = listDepartments.ElementAt(command - 1);
                        CreateStudent(department);
                        exit = true;
                    }
                    else if (command == listDepartments.Count + 1) exit = true;
                    else ConsoleMessage.WrongInputMessage();
                }
                else ConsoleMessage.WrongInputMessage();
            }
        }
        public void AddLecturesToDepartment(Department department)
        {
            var exit = false;
            while (!exit)
            {
                var listLectures = _DatabaseService.GetAllLecturesByDepartment(department);
                var dbListLecture = _DatabaseService.GetAllLectures();
                ConsoleMessage.LectureSelectionWindow(dbListLecture, listLectures);
                if (Int32.TryParse(Console.ReadLine(), out int command))
                {
                    if ((command > 0) && (command <= dbListLecture.Count))
                    {
                        var lecture = dbListLecture.ElementAt(command - 1);
                        _DatabaseService.AssingLectureToDepartment(department, lecture);
                        continue;
                    }
                    else if (command == dbListLecture.Count + 1)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Enter a new lecture name: ");
                        Console.WriteLine("");

                        var lecture = _DatabaseService.GetOrCreateLecture(Console.ReadLine());
                        _DatabaseService.AssingLectureToDepartment(department, lecture);
                    }
                    else if (command == dbListLecture.Count + 2) exit = true;
                    else ConsoleMessage.WrongInputMessage();
                }
                else ConsoleMessage.WrongInputMessage();
            }
        }
        public void AddLectureToDepartment()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Enter a new lecture name: ");
            Console.WriteLine("--------------------------");
            var LectureName = Console.ReadLine();
            if (_DatabaseService.CheckIfLectureExist(LectureName))
            {
                Console.WriteLine("");
                Console.WriteLine($"! Lecture whith this name: '{LectureName}' already exists");
                Console.WriteLine("");
                ConsoleMessage.ContinueMessage();
                AddLectureToDepartment();
            }
            var exit = false;
            while (!exit)
            {
                var dbListDepartment = _DatabaseService.GetDepartmentsList();
                var lecture = _DatabaseService.GetOrCreateLecture(LectureName);
                var listDepartments = _DatabaseService.GetDepartmentListByLecture(lecture);
                ConsoleMessage.LectureToDepartmentsSelectionWindow(dbListDepartment, listDepartments); 
                if (Int32.TryParse(Console.ReadLine(), out int command))
                {
                    if ((command > 0) && (command <= dbListDepartment.Count))
                    {
                        var department = dbListDepartment.ElementAt(command - 1);
                        _DatabaseService.AssingDepartmentToLecture(lecture, department);
                        continue;
                    }
                    else if (command == dbListDepartment.Count + 1) exit = true;
                    else ConsoleMessage.WrongInputMessage();
                }
                else ConsoleMessage.WrongInputMessage();
            }
        }
        public void CreateStudent(Department department)
        {
            var skip = false;
            Console.WriteLine("");
            Console.WriteLine("Enter a new Student Name: ");
            Console.WriteLine("");
            var studentName = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Enter a new Student Last Name: ");
            Console.WriteLine("");
            var studentLastName = Console.ReadLine();
            if (_DatabaseService.CheckIfStudentExist(studentName, studentLastName))
            {
                Console.WriteLine("");
                Console.WriteLine($"! Student {studentName} {studentLastName} already exist");
                Console.WriteLine("");
                ConsoleMessage.ContinueMessage();
                CreateStudent(department);
                skip = true;
            }
            if (!skip)
            {
                var newStudent = _DatabaseService.GetOrCreateSudent(studentName, studentLastName, department);
                AddLectureToStudent(department, newStudent);
            }
        }
        public void AddStudentToDepartment(Department department)
        {
            var exit = false;
            while (!exit)
            {
                var departmentSudentsList = _DatabaseService.GetAllStudentsOfDepartment(department.DepartmentName);
                ConsoleMessage.StudentSelectionWindow(departmentSudentsList);
                if (Int32.TryParse(Console.ReadLine(), out int command))
                {
                    if ((command > 0) && (command <= departmentSudentsList.Count))
                    {
                        var student = departmentSudentsList.ElementAt(command - 1);
                        AddLectureToStudent(department, student);
                        continue;
                    }
                    else if (command == departmentSudentsList.Count + 1)
                    {
                        CreateStudent(department);
                    }
                    else if (command == departmentSudentsList.Count + 2) exit = true;
                    else ConsoleMessage.WrongInputMessage();
                }
                else ConsoleMessage.WrongInputMessage();
            }
        }
        public void TransferStudent(Department department, Student student)
        {
            var newStudent = _DatabaseService.GetOrCreateSudent(student, department);
            AddLectureToStudent(department, newStudent);
        }
        public void AddLectureToStudent(Department department, Student student)
        {
            var exit = false;
            while (!exit)
            {
                var departmentListLecture = _DatabaseService.GetAllLecturesByDepartment(department);
                var studentListLecture = _DatabaseService.GetAllLecturesBySudent(student);
                ConsoleMessage.StudentLectureSelectionWindow(departmentListLecture, studentListLecture);
                if (Int32.TryParse(Console.ReadLine(), out int command))
                {
                    if ((command > 0) && (command <= departmentListLecture.Count))
                    {
                        var lecture = departmentListLecture.ElementAt(command - 1);
                        _DatabaseService.AssingLectureToStudent(student, lecture);
                        continue;
                    }
                    else if (command == departmentListLecture.Count + 1) break;
                    else ConsoleMessage.WrongInputMessage();
                }
                else ConsoleMessage.WrongInputMessage();
            }
        }
        public void TransferStudentToOtherDepartment()
        {
            var exit = false;
            var transferStudent = new Student();
            while (!exit)
            {
                var listDepartments = _DatabaseService.GetDepartmentsList();
                ConsoleMessage.DepartmentSelectionWindow(listDepartments);
                if (Int32.TryParse(Console.ReadLine(), out int command))
                {
                    if ((command > 0) && (command <= listDepartments.Count))
                    {
                        while (!exit)
                        {
                            var department = listDepartments.ElementAt(command - 1);
                            var listStudents = _DatabaseService.GetAllStudentsOfDepartment(department.DepartmentName);
                            ConsoleMessage.StudentTransferSelectionWindow(listStudents);
                            if (Int32.TryParse(Console.ReadLine(), out int secondCommand))
                            {
                                if ((secondCommand > 0) && (secondCommand <= listStudents.Count))
                                {
                                    var student = listStudents.ElementAt(secondCommand - 1);
                                    transferStudent.Name = student.Name;
                                    transferStudent.LastName = student.LastName;
                                    transferStudent.Id = student.Id;
                                    _DatabaseService.RemoveStudent(student);
                                    while (!exit)
                                    {
                                        var listDepartment = _DatabaseService.GetDepartmentsList();
                                        ConsoleMessage.DepartmentSelectionWindow(listDepartment);
                                        if (Int32.TryParse(Console.ReadLine(), out int ThirdCommand))
                                        {
                                            if ((ThirdCommand > 0) && (ThirdCommand <= listDepartment.Count))
                                            {
                                                var newDepartment = listDepartment.ElementAt(ThirdCommand - 1);
                                                TransferStudent(newDepartment, transferStudent);
                                                exit = true;
                                            }
                                            else if (ThirdCommand == listDepartment.Count + 1) exit = true;
                                            else ConsoleMessage.WrongInputMessage();
                                        }
                                        else ConsoleMessage.WrongInputMessage();
                                    }
                                }
                                else if (secondCommand == listStudents.Count + 1) exit = true;
                                else ConsoleMessage.WrongInputMessage();
                            }
                            else ConsoleMessage.WrongInputMessage();
                        }
                    }
                    else if (command == listDepartments.Count + 1) exit = true;
                    else ConsoleMessage.WrongInputMessage();
                }
                else ConsoleMessage.WrongInputMessage();
            }
        }
        public void DisplayDepartmentStudents()
        {
            var exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("Select a department to view it's students");
                Console.WriteLine("-----------------------------------------");
                var listDepatments = _DatabaseService.GetDepartmentsList();
                foreach (var department in listDepatments)
                {
                    Console.WriteLine($"{listDepatments.IndexOf(department) + 1} - {department}");
                }
                ConsoleMessage.BackToPreviousWindowMessage(listDepatments.Count + 1);
                if (Int32.TryParse(Console.ReadLine(), out int command))
                {
                    if ((command > 0) && (command <= listDepatments.Count))
                    {
                        var department = listDepatments.ElementAt(command - 1);
                        Console.Clear();
                        Console.WriteLine("");
                        Console.WriteLine($"List of students in {department} department: ");
                        Console.WriteLine("");
                        var listStudents = _DatabaseService.GetStudentListByDepartment(department);
                        foreach (var student in listStudents)
                        {
                            Console.WriteLine($"{listStudents.IndexOf(student) + 1} - {student}");
                        }
                        ConsoleMessage.ContinueMessage();
                    }
                    else if (command == listDepatments.Count + 1) exit = true;
                    else ConsoleMessage.WrongInputMessage();
                }
                else ConsoleMessage.WrongInputMessage();
            }
        }
        public void DisplayDepartmentLectures()
        {
            var exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("Select a department to view it's lectures: ");
                Console.WriteLine("-------------------------------------------");
                var listDepatments = _DatabaseService.GetDepartmentsListWhithLecture();
                foreach (var department in listDepatments)
                {
                    Console.WriteLine($"{listDepatments.IndexOf(department) + 1} - {department}");
                }
                ConsoleMessage.BackToPreviousWindowMessage(listDepatments.Count + 1);
                if (Int32.TryParse(Console.ReadLine(), out int command))
                {
                    if ((command > 0) && (command <= listDepatments.Count))
                    {
                        var department = listDepatments.ElementAt(command - 1);
                        Console.Clear();
                        Console.WriteLine($"List of lectures in {department} department: ");
                        foreach (var lecture in department.ListLectures)
                        {
                            Console.WriteLine($"{department.ListLectures.IndexOf(lecture) + 1} - {lecture}");
                        }
                        ConsoleMessage.ContinueMessage();
                    }
                    else if (command == listDepatments.Count + 1) exit = true;
                    else ConsoleMessage.WrongInputMessage();
                }
                else ConsoleMessage.WrongInputMessage();
            }
        }
        public void DisplayStudentLectures()
        {
            var exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("Select a Student to view it's lectures: ");
                Console.WriteLine("----------------------------------------");
                var listStudents = _DatabaseService.GetStudentListWhithLecture();
                foreach (var student in listStudents)
                {
                    Console.WriteLine($"{listStudents.IndexOf(student) + 1} - {student}");
                }
                ConsoleMessage.BackToPreviousWindowMessage(listStudents.Count + 1);
                if (Int32.TryParse(Console.ReadLine(), out int command))
                {
                    if ((command > 0) && (command <= listStudents.Count))
                    {
                        var student = listStudents.ElementAt(command - 1);
                        Console.Clear();
                        Console.WriteLine("");
                        Console.WriteLine($"List of lectures of {student}: ");
                        Console.WriteLine("");
                        foreach (var lecture in student.ListLecture)
                        {
                            Console.WriteLine($"{student.ListLecture.IndexOf(lecture) + 1} - {lecture}");
                        }
                        ConsoleMessage.ContinueMessage();
                    }
                    else if (command == listStudents.Count + 1) exit = true;
                    else ConsoleMessage.WrongInputMessage();
                }
                else ConsoleMessage.WrongInputMessage();
            }
        }

    }
}
