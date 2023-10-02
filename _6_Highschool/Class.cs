using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _6_Highschool
{
    internal class Class
    {
        public string ClassName { get; set; }
        private List<Student> _students;
        public List<Student> GetStudents() { return _students; }
        public Class()
        {
            ClassName = string.Empty;
            _students = new List<Student>();
        }
        public Class(string className)
        {
            ClassName = className;
            _students = new List<Student>();
        }
        public void AddStudent()
        {
            if (_students.Count > 40)
            {
                Console.WriteLine("Class is full!");
                Console.ReadLine();
                return;
            }

            Console.Clear();
            Console.WriteLine("Input student name:");
            string? studentName = Console.ReadLine();

        InputStudentAge:
            Console.WriteLine("Input student age:");
            bool isNumAge = Int32.TryParse(Console.ReadLine(), out int studentAge);
            if (!isNumAge) { goto InputStudentAge; }

            Console.WriteLine("Input student origin:");
            string? studentOrigin = Console.ReadLine();

            _students.Add(new Student(studentName ?? "N/A", studentAge, studentOrigin ?? "N/A"));
            Console.WriteLine("Student added: " + _students.Last().ToString());
            Console.ReadLine();
        }
        public List<Student> GetStudentsOfAge(int studentAge)
        {
            List<Student> students = _students.Where(student => student.Age == studentAge).ToList();
            return students;
        }
        public List<Student> GetStudentsOfAgeAndFrom(int studentAge, string studentOrigin)
        {
            List<Student> students = _students.Where(student => student.Age == studentAge && student.Origin == studentOrigin).ToList();
            return students;
        }
    }
}
