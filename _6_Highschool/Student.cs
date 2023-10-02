using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Highschool
{
    internal class Student
    {
        public string FullName { get; set; }
        public int? Age { get; set; }
        public string Origin { get; set; }
        public Student()
        {
            FullName = string.Empty;
            Age = null;
            Origin = string.Empty;
        }
        public Student(string fullName, int? age, string origin)
        {
            FullName = fullName;
            Age = age;
            Origin = origin;
        }
        public override string ToString()
        {
            return "Full name: " + FullName + ", Age: " + Age + ", Origin: " + Origin;
        }
    }
}
