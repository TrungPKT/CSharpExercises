using _15_University.InputHandlers;
using _15_University.Source;

namespace _15_University
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test Input
            /*int entryGrade = Input.GetInput<int>("Input: ", ExceptionType.EntryGrade);
            Console.WriteLine(entryGrade);*/
            // Test student sorted list to string
            /*Student student = new Student();
            student.AllGrades.Add("2000C", 3.1);
            student.AllGrades.Add("2000A", 3.1);
            student.AllGrades.Add("2000B", 3.1);
            Console.WriteLine(student);*/
            // Test InService tostring, copy ctor
            /*InService inService = new InService();
            inService.AllGrades.Add("2000C", 3.1);
            inService.AllGrades.Add("2000A", 3.1);
            inService.AllGrades.Add("2000B", 3.1);
            inService.TrainingPlace = ETrainingPlace.HaiPhong;
            InService inService1 = new InService(inService);
            Console.WriteLine(inService1);*/
            // Test Department tostring
            /*Student student = new Student();
            student.AllGrades.Add("2000C", 3.1);
            student.AllGrades.Add("2000A", 3.1);
            student.AllGrades.Add("2000B", 3.1);
            Console.WriteLine(student);
            Department department = new Department("Mechanics", new List<Student>() { student });
            Console.WriteLine(department);*/

            // PROGRAM START
            Management m = new Management();

            string state = "0";

            while (state != "-1")
            {
                switch (state)
                {
                    case "0":
                        string input0 = Input.OptionPrompt("University Management System\n\nChoose an option:", new string[] {
                            "1.  Display all",
                            "2.  Add a student",
                            "3.  Check formal student",
                            "4.  Get grade average in a semester",
                            "5.  Get formal student count of a department",
                            "6.  Get student with highest entry grade of each department",
                            "7.  Get in-service students from a training place",
                            "8.  Get students with grade average, in their last semesters, greater than or equal a minimum grade average of each department",
                            "9.  Get student with highest grade average of each department",
                            "10. Order students by type in ascending order and by admitted year in descending order",
                            "11. Get student count of each admitted year",
                            "12. Exit program"
                        });

                        state = input0;

                        break;
                    case "1":
                        m.DisplayAll();
                        state = "0";

                        break;
                    case "2":
                        m.AddStudent();
                        state = "0";

                        break;
                    case "3":
                        m.IsFormalStudent();
                        state = "0";

                        break;
                    case "4":
                        m.GetGradeAverageOfStudent();
                        state = "0";

                        break;
                    case "5":
                        m.GetFormalStudentCountOfADepartment();
                        state = "0";

                        break;
                    case "6":
                        m.GetStudentsWithHighestEntryGrade();
                        state = "0";

                        break;
                    case "7":
                        m.GetInServiceStudentAtATrainingPlace();
                        state = "0";

                        break;
                    case "8":
                        m.GetStudentGradeAveragesInMostRecentSemester();
                        state = "0";

                        break;
                    case "9":
                        m.GetStudentWithHighestGradeAverage();
                        state = "0";

                        break;
                    case "10":
                        m.Ordering();
                        state = "0";

                        break;
                    case "11":
                        m.GetStudentCountOfEachAdmittedYear();
                        state = "0";

                        break;
                    case "12":
                        state = "-1";

                        break;
                }
            }
        }
    }
}