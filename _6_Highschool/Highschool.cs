using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace _6_Highschool
{
    class Highschool
    {
        public List<Class> _classes { get; set; }
        public List<List<Student>> _classes2 { get; set; }


        public Highschool()
        {
            _classes = new List<Class>()
            {
                new Class("Class A"),
                new Class("Class B")
            };
            _classes2 = new List<List<Student>>()
            {
                new Class("Class A").GetStudents(),
                new Class("Class B").GetStudents()
            }; 
        }
        public void AddClass()
        {
        InputClassName:
            Console.Clear();
            Console.WriteLine("Choose a class:");
            Console.WriteLine("1. Class A");
            Console.WriteLine("2. Class B");
            string? inputClass = Console.ReadLine();
            if (inputClass != "1" && inputClass != "2") { goto InputClassName; }

            if (inputClass == "1") { _classes[0].AddStudent(); }
            else if (inputClass == "2") { _classes[1].AddStudent(); }
        }
        public void DisplayStudentsOfAge()
        {
        InputAge:
            Console.Clear();
            Console.WriteLine("Input age to find:");
            bool isNumAge = Int32.TryParse(Console.ReadLine(), out int studentAge);
            if (!isNumAge) { goto InputAge; }

            Console.Clear();
            foreach (Class class_ in _classes)
            {
                List<Student> students = class_.GetStudentsOfAge(studentAge);
                if (students.Count != 0)
                {
                    Console.WriteLine(class_.ClassName);
                    foreach (var student in students) { Console.WriteLine(student.ToString()); }
                }
            }
            Console.ReadLine();
        }
        public void DisplayStudentsOfAge2()
        {
        InputAge:
            Console.Clear();
            Console.WriteLine("Input age to find:");
            bool isNumAge = Int32.TryParse(Console.ReadLine(), out int studentAge);
            if (!isNumAge) { goto InputAge; }

            var studentsOfAge = _classes2.SelectMany(class_ => class_).Where(student => student.Age == studentAge);
        }
        public void GetNumberOfStudentsOfAgeAndPlace()
        {
        InputAge:
            Console.Clear();
            Console.WriteLine("Input student age:");
            bool isNumAge = Int32.TryParse(Console.ReadLine(), out int studentAge);
            if (!isNumAge) { goto InputAge; }

            Console.WriteLine("Input student origin:");
            string studentOrigin = Console.ReadLine();

            Console.Clear();
            foreach (Class class_ in _classes)
            {
                List<Student> students = class_.GetStudentsOfAgeAndFrom(studentAge, studentOrigin ?? "N/A");
                if (students.Count != 0)
                {
                    Console.WriteLine(class_.ClassName);
                    foreach (var student in students) { Console.WriteLine(student.ToString()); }
                }
            }
            Console.ReadLine();
        }
    }
}
