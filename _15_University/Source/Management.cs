#define DEBUG

using _15_University.InputHandlers;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Channels;

namespace _15_University.Source
{
    internal class Management
    {
        public List<Department> Departments { get; set; }
        private readonly string[] departmentNames = new string[]
            {
                "Department of Mechanical Engineering",
                "Department of Electrical Engineering",
                "Department of Infomation Technology"
            };
        public Management()
        {
            Departments = new List<Department>();
            foreach (string departmentName in departmentNames)
            {
                Departments.Add(new Department(departmentName, new List<Student>()));
            }
#if DEBUG
            List<Student> mS = new List<Student>()
            {
                new Student("Nguyen Van A", new DateTime(1/1/1), 2022, 24.5, new SortedList<int, double>()
                {
                    {1, 8.5}, {2, 9.1}, {3, 9.1}
                }),
                new Student("Pham Van A", new DateTime(1/1/1), 2021, 27.5, new SortedList<int, double>()
                {
                    {1, 7.4}, {2, 6.1}, {3, 8.0}, {4, 7.0}, {5, 8.5}
                }),
                new InService("Tran Van A", new DateTime(1/1/1), 2023, 21.5, new SortedList<int, double>()
                {
                    {1, 5.2}
                }, "HaiPhong Training Center"),
                new Student("Hoang Van A", new DateTime(1/1/1), 2023, 26.5, new SortedList<int, double>()
                {
                    {1, 8.4}
                })
            };
            List<Student> eS = new List<Student>()
            {
                new InService("Kieu Thi A", new DateTime(1/1/1), 2021, 29.5, new SortedList<int, double>()
                {
                    {1, 8.4}, {2, 7.1}, {3, 8.0}, {4, 9.0}, {5, 8.5}
                }, "DaNang Training Center"),
                new Student("Trinh Van A", new DateTime(1/1/1), 2022, 29.5, new SortedList<int, double>()
                {
                    {1, 7.5}, {2, 7.1}, {3, 8.6}
                }),
                new InService("Le Thi A", new DateTime(1/1/1), 2023, 20.5, new SortedList<int, double>()
                {
                    {1, 8.4}
                }, "Hanoi Training Center")
            };
            List<Student> iS = new List<Student>()
            {
                new InService("Hoang Thi A", new DateTime(1/1/1), 2021, 24.5, new SortedList<int, double>()
                {
                    {1, 8.4}, {2, 9.4}, {3, 9.0}, {4, 9.4}, {5, 7.4}
                }, "DaNang Training Center"),
                new InService("Leu Thi A", new DateTime(1/1/1), 2022, 21.5, new SortedList<int, double>()
                {
                    {1, 6.2}, {2, 6.4}, {3, 6.6}
                }, "Hanoi Training Center"),
                new Student("Dang Van A", new DateTime(1/1/1), 2022, 23.5, new SortedList<int, double>()
                {
                    {1, 7.4}, {2, 6.4}, {3, 7.6}
                }),
                new InService("Ha Van A", new DateTime(1/1/1), 2023, 28.5, new SortedList<int, double>()
                {
                    {1, 6.2}
                }, "HaiPhong Training Center")
            };

            Departments[0].Students = mS;
            Departments[1].Students = eS;
            Departments[2].Students = iS;
#endif
        }
        public void DisplayAll()
        {
            foreach (Department department in Departments)
            {
                Console.WriteLine(department);
            }
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }
        public void AddStudent()
        {
            Console.Clear();
            string inputDeparmentName = Input.OptionPrompt("Choose a department:", new string[] {
                "1. Department of Mechanical Engineering",
                "2. Department of Electrical Engineering",
                "3. Department of Infomation Technology"
            });
            int departmentIndex = inputDeparmentName switch
            {
                "1" => 0,
                "2" => 1,
                "3" => 2
            };

            string fullName = Input.GetInput<string>("Input full name:", ExceptionType.FullName);
            DateTime birthday = Input.GetInput<DateTime>("Input birthday(dd/mm/yyyy):");
            int admittedYear = Input.GetInput<int>("Input admitted year:", ExceptionType.AdmittedYear);
            double entryGrade = Input.GetInput<double>("Input entry grade:", ExceptionType.EntryGrade);
            int numberOfSemesters = Input.GetInput<int>("Input all grades:\nInput number of semesters:", ExceptionType.NumberOfSemesters);
            SortedList<int, double> allGrades = new SortedList<int, double>();
            for (int i = 0; i < numberOfSemesters; i++)
            {
                int semester = i + 1;
                double gradeAverage = Input.GetInput<double>("Input grade average for semester " + semester + ":", ExceptionType.GradeAverage);
                allGrades[semester] = gradeAverage;
            }

            string inputTypeOfStudent = Input.OptionPrompt("Is this student an in-service student?", new string[]
            {
                "1. Yes",
                "2. No"
            });

            var student = new Student(fullName, birthday, admittedYear, entryGrade, allGrades);

            if (inputTypeOfStudent == "1")
            {
                string inputTrainingPlace = Input.OptionPrompt("Choose a in-service training place:", new string[]
                {
                    "1. Hanoi Training Center",
                    "2. HaiPhong Training Center",
                    "3. DaNang Training Center"
                });
                string trainingPlace = inputTrainingPlace switch
                {
                    "1" => "Hanoi Training Center",
                    "2" => "HaiPhong Training Center",
                    "3" => "DaNang Training Center"
                };

                student = new InService(fullName, birthday, admittedYear, entryGrade, allGrades, trainingPlace);
            }


            Departments[departmentIndex].Students.Add(student);

            string departmentName = Departments[departmentIndex].Name;
            Student addedStudent = Departments[departmentIndex].Students.Last();

            Console.WriteLine(departmentName);
            Console.WriteLine(addedStudent);

            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }
        public bool IsValidStudentID(out Student student, out int studentID)
        {
            Student? studentResult = null;
            int studentIDInput = Input.GetInput<int>("Input a student ID:");

            foreach (Department department in Departments)
            {
                studentResult = department.Students.Find(student => student.StudentID == studentIDInput);
                if (studentResult != null)
                    break;
            }

            student = studentResult;
            studentID = studentIDInput;

            if (studentResult == null)
            {
                Console.WriteLine("No student with ID: " + studentIDInput);
                Console.ReadLine();
                return false;
            }

            return true;
        }
        public void IsFormalStudent()
        {
            Console.Clear();
            if (IsValidStudentID(out Student student, out int studentID) == false)
                return;

            if (student is InService)
            {
                Console.WriteLine("Student with ID " + studentID + " is NOT a formal student");
            }
            else
            {
                Console.WriteLine("Student with ID " + studentID + " is a formal student");
            }

            Console.Write("Press any key to continue...");
            Console.ReadLine();
            return;
        }
        public void GetGradeAverageOfStudent()
        {
            if (IsValidStudentID(out Student student, out int studentID) == false)
            {
                return;
            }

            int semester = Input.GetInput<int>("Input semester:");

            if (student.AllGrades.ContainsKey(semester) == false)
            {
                Console.WriteLine("Student " + student.FullName + " does not have grade average for semester " + semester);
                Console.Write("Press any key to continue...");
                Console.ReadLine();
                return;
            }

            double gradeAverage = student.AllGrades[semester];
            Console.WriteLine("Student " + student.FullName + ", in semester " + semester + ", have a grade average of " + gradeAverage);
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }
        public void GetFormalStudentCountOfADepartment()
        {
            /*List<Student> res = (from department in Departments
                                from student in department.Students
                                where student is InService
                                select student).ToList();

            res.ToList().ForEach(student => Console.WriteLine(student.FullName));
            Console.ReadLine();*/
            /*var formalStudentCounts = from department in Departments
                                      select new
                                      {
                                          DepartmentName = department.Name,
                                          StudentCount = department.Students.Count(student => (student is InService) == false)
                                      };
            foreach (var anonType in formalStudentCounts)
            {
                Console.WriteLine(anonType.DepartmentName + " has " + anonType.StudentCount + " formal student");
            }
            Console.ReadLine();*/
            string department = Input.OptionPrompt("Choose a department:", new string[]
            {
                "1. Department of Mechanical Engineering",
                "2. Department of Electrical Engineering",
                "3. Department of Infomation Technology"
            });
            int departmentIndex = int.Parse(department) - 1;
            int formalStudentCount = Departments[departmentIndex].Students.Count(student => (student is InService) == false);

            Console.WriteLine(Departments[departmentIndex].Name + " has " + formalStudentCount + " formal student");
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }
        public void GetStudentsWithHighestEntryGrade()
        {
            var highestEntryGradeStudents = from department in Departments
                                            from student in department.Students
                                            let highestEntryGrade = department.Students.Max(student => student.EntryGrade)
                                            where student.EntryGrade == highestEntryGrade
                                            select new
                                            {
                                                DeparmentName = department.Name,
                                                HighestEntryGradeStudent = student.FullName,
                                                Grade = highestEntryGrade
                                            };
            foreach (var anonType in highestEntryGradeStudents)
            {
                Console.WriteLine(anonType.HighestEntryGradeStudent + " is the student with the highest entry grade (" + anonType.Grade + ") of " + anonType.DeparmentName);
            }
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }
        public void GetInServiceStudentAtATrainingPlace()
        {
            string inputTrainingPlace = Input.OptionPrompt("Choose a in-service training place:", new string[]
            {
                "1. Hanoi Training Center",
                "2. HaiPhong Training Center",
                "3. DaNang Training Center"
            });
            string trainingPlace = inputTrainingPlace switch
            {
                "1" => "Hanoi Training Center",
                "2" => "HaiPhong Training Center",
                "3" => "DaNang Training Center"
            };

            IEnumerable<Student> inServiceStudents = from department in Departments
                                                     from student in department.Students
                                                     where student is InService
                                                     select student;
            Console.WriteLine("----" + trainingPlace + "----\n");
            foreach (InService inService in inServiceStudents)
            {
                if (inService.TrainingPlace == trainingPlace)
                {
                    Console.WriteLine(inService);
                }
            }

            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }
        public void GetStudentGradeAveragesInMostRecentSemester()
        {
            double minGradeAverage = Input.GetInput<double>("Input minimum grade average:", ExceptionType.GradeAverage);
            var students = from department in Departments
                           from student in department.Students
                           where student.AllGrades.Last().Value >= minGradeAverage
                           select new
                           {
                               DepartmentName = department.Name,
                               StudentName = student.FullName,
                               LastSemester = student.AllGrades.Last().Key,
                               GradeAverage = student.AllGrades.Last().Value
                           } into PickedStudent
                           group PickedStudent by PickedStudent.DepartmentName;

            Console.WriteLine("Students with grade average greater than or equal " + minGradeAverage + " in their last semester...\n");
            foreach (var item in students)
            {
                Console.WriteLine("...from " + item.Key + ":\n");
                foreach (var student in item)
                {
                    Console.WriteLine(student.StudentName + " has a grade average of " + student.GradeAverage + " in semester " + student.LastSemester);
                }
                Console.WriteLine();
            }

            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }
        public void GetStudentWithHighestGradeAverage()
        {
            /*var query00 = from department in Departments
                          from student in department.Students
                          group student by department.Name;
            //foreach (var item in query00)
            //{
            //    Console.WriteLine(item.Key);
            //    foreach (var student in item)
            //    {
            //        Console.WriteLine(student);
            //    }
            //}

            var query01 = from grp in query00
                          let HighestGA = grp.Max(student => student.AllGrades.Values.Max())
                          from student in grp
                          let HighestSemester = student.AllGrades.FirstOrDefault(grade => grade.Value == HighestGA).Key
                          where student.AllGrades.ContainsKey(HighestSemester) && student.AllGrades.ContainsValue(HighestGA)
                          select new
                          {
                              DepartmentName = grp.Key,
                              StudentName = student.FullName,
                              HighestSemester,
                              HighestGA
                          } into result
                          group result by result.DepartmentName;

            foreach (var item in query01)
            {
                Console.WriteLine("----" + item.Key + "----\n");
                foreach (var student in item)
                {
                    Console.WriteLine(student.StudentName + " in semester " + student.HighestSemester + " has the grade average of " + student.HighestGA);
                }
                Console.WriteLine();
            }*/
            var query00 = from department in Departments
                          let HighestGA = department.Students.Max(student => student.AllGrades.Values.Max())
                          from student in department.Students
                          let HighestSemester = student.AllGrades.FirstOrDefault(grade => grade.Value == HighestGA).Key
                          where student.AllGrades.ContainsKey(HighestSemester) && student.AllGrades.ContainsValue(HighestGA)
                          select new
                          {
                              DepartmentName = department.Name,
                              StudentName = student.FullName,
                              HighestSemester,
                              HighestGA
                          } into result
                          group result by result.DepartmentName;

            foreach (var item in query00)
            {
                Console.WriteLine("----" + item.Key + "----\n");
                foreach (var student in item)
                {
                    Console.WriteLine(student.StudentName + " in semester " + student.HighestSemester + " has the grade average of " + student.HighestGA);
                }
                Console.WriteLine();
            }

            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }
        public void Ordering()
        {
            // WORK
            /*var query00 = (from department in Departments
                           from student in department.Students
                           select student)
                           .OrderBy(student => student.StudentType, new StudentTypeComparer()).ThenByDescending(student => student.AdmittedYear);*/
            for (int i = 0; i < Departments.Count; i++)
            {
                var query = Departments[i].Students.OrderBy(student => student.StudentType, new StudentTypeComparer()).ThenByDescending(student => student.AdmittedYear);
                Console.WriteLine("Student will be ordered before InService\n");
                Console.WriteLine("----" + Departments[i].Name + "----\n");
                foreach (var student in query)
                {
                    Console.WriteLine(student.FullName + " has type " + student.StudentType.Name + " and admitted year " + student.AdmittedYear);
                }
                Console.WriteLine();
            }

            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }
        public void GetStudentCountOfEachAdmittedYear()
        {
            var studentCountOfEachDepartment = from department in Departments
                                               from student in department.Students
                                               group student by student.AdmittedYear into groupOfAdmittedYear
                                               let StudentCount = groupOfAdmittedYear.Count()
                                               select new
                                               {
                                                   Group = groupOfAdmittedYear,
                                                   StudentCount
                                               };
            studentCountOfEachDepartment.ToList().ForEach(item =>
            {
                Console.WriteLine("The admitted year " + item.Group.Key + " has " + item.StudentCount + " students");
            });

            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }
    }
    public class StudentTypeComparer : IComparer<Type>
    {
        /*int IComparer<Student>.Compare(Student? x, Student? y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;
            if (x is Student && y is InService)
                return -1;
            if (x is InService && y is Student)
                return 1;
            return 0;
        }*/
        int IComparer<Type>.Compare(Type? x, Type? y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;
            if (x == typeof(Student) && y == typeof(InService))
                return -1;
            if (x == typeof(InService) && y == typeof(Student))
                return 1;
            return 0;
        }
    }
}
