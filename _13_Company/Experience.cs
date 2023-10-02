using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_Company
{
    internal class Experience : Employee
    {
        public int? ExpInYear { get; set; }
        public string ProSkill {  get; set; }
        public Experience() : base()
        {
            //EmployeeType = EEmployeeType.Experience;
            ExpInYear = null;
            ProSkill = string.Empty;
        }
        //public Experience(string fullName, DateOnly? birthDay, string phone, string email, int? expInYear, string proSkill) : base(fullName, birthDay, phone, email, EEmployeeType.Experience)
        public Experience(string fullName, DateOnly? birthDay, string phone, string email, int? expInYear, string proSkill) : base(fullName, birthDay, phone, email)
        {
            ExpInYear = expInYear;
            ProSkill = proSkill;
        }
        public override void ShowInfo()
        {
            //Console.WriteLine("name: " + FullName + ", birthday: " + BirthDay + ", phone: " + Phone + ", email: " + Email + ", employee type:" + EmployeeType + ", YoE: " + ExpInYear + ", Skill: " + ProSkill);
            Console.Write("ID: " + ID + ", name: " + FullName + ", birthday: " + BirthDay + ", phone: " + Phone + ", email: " + Email + ", employee type: Experience" + ", YoE: " + ExpInYear + ", Skill: " + ProSkill);
        }
    }
}
