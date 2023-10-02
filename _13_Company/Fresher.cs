using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_Company
{
    internal class Fresher : Employee
    {
        public DateOnly? GraduationDate { get; set; }
        public string GraduationRank { get; set; }
        public string SchoolName { get; set; }
        public Fresher() : base()
        {
            //EmployeeType = EEmployeeType.Fresher;
            GraduationDate = null;
            GraduationRank = null;
            SchoolName = string.Empty;
        }
        //public Fresher(string fullName, DateOnly? birthDay, string phone, string email, DateOnly? graduationDate, string graduationRank, string schoolName) : base(fullName, birthDay, phone, email, EEmployeeType.Fresher)
        public Fresher(string fullName, DateOnly? birthDay, string phone, string email, DateOnly? graduationDate, string graduationRank, string schoolName) : base(fullName, birthDay, phone, email)
        {
            GraduationDate = graduationDate;
            GraduationRank = graduationRank;
            SchoolName = schoolName;
        }
        public override void ShowInfo()
        {
            Console.Write("ID: " + ID + ", name: " + FullName + ", birthday: " + BirthDay + ", phone: " + Phone + ", email: " + Email + ", employee type: Fresher" + ", grad. date: " + GraduationDate + ", grad. rank: " + GraduationRank + ", school name: " + SchoolName);
        }
    }
}
