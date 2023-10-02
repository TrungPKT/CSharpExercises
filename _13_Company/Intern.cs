using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_Company
{
    internal class Intern : Employee
    {
        public string Major { get; set; }
        public string Semester { get; set; }
        public string UniversityName { get; set; }
        public Intern() : base() 
        {
            //EmployeeType = EEmployeeType.Intern;
            Major = string.Empty;
            Semester = string.Empty;
            UniversityName = string.Empty;
        }
        //public Intern(string fullName, DateOnly? birthDay, string phone, string email, string major, string semester, string universityName) : base(fullName, birthDay, phone, email, EEmployeeType.Intern)
        public Intern(string fullName, DateOnly? birthDay, string phone, string email, string major, string semester, string universityName) : base(fullName, birthDay, phone, email)
        {
            Major = major;
            Semester = semester;
            UniversityName = universityName;
        }
        public override void ShowInfo()
        {
            Console.Write("ID: " + ID + ", name: " + FullName + ", birthday: " + BirthDay + ", phone: " + Phone + ", email: " + Email + ", employee type: Intern" + ", major: " + Major + ", semester: " + Semester + ", university name: " + UniversityName);
        }
    }
}
