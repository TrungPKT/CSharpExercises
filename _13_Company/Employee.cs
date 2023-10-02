using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _13_Company
{
    enum EEmployeeType
    {
        Experience, Fresher, Intern
    }
    //static class EEmployeeTypeExtensions
    //{
    //    public static string ToString(this EEmployeeType eemployeeType)
    //    {
    //        switch (eemployeeType)
    //        {
    //            case EEmployeeType.Experience: return "Experiencesd";
    //            case EEmployeeType.Fresher: return "Fresher";
    //        }
    //        return "Intern";
    //    }
    //}
    abstract class Employee
    {
        public static int EmployeeCount = 0;
        public int ID { get; set; }
        public string FullName { get; set; }
        public DateOnly? BirthDay { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        //public EEmployeeType? EmployeeType { get; set; }
        public Certificate? Certificate { get; set; }
        public Employee()
        {
            ID = ++EmployeeCount;
            FullName = string.Empty;
            BirthDay = null;
            Phone = string.Empty;
            Email = string.Empty;
            //EmployeeType = null;
            Certificate = null;
        }
        //public Employee(string fullName, DateOnly? birthDay, string phone, string email, EEmployeeType? employeeType)
        public Employee(string fullName, DateOnly? birthDay, string phone, string email)
        {
            ID = ++EmployeeCount;
            FullName = fullName;
            BirthDay = birthDay;
            Phone = phone;
            Email = email;
            //EmployeeType = employeeType;
        }
        public abstract void ShowInfo();
    }
}
