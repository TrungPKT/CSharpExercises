using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _15_University.Source
{
    internal class Department
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public Department()
        {
            Name = string.Empty;
            Students = new List<Student>();
        }
        public Department(string name, List<Student> students) : base()
        {
            Name = name;
            Students = students;
        }
        public Department(Department other)
        {
            Name = other.Name;
            Students = other.Students;
        }
        public override string ToString()
        {
            string department = $"----{Name}----\n\n";
            foreach (Student student in Students)
            {
                department += student.ToString() + "\n\n";
            }

            return department;
        }
    }
}
