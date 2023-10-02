using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _13_Company
{
    internal class EmployeeManagement
    {
        private List<Employee> _employees;
        public EmployeeManagement()
        {
            _employees = new List<Employee>()
            {
                new Experience("Nguyen Van A", new DateOnly(1990, 1, 1), "0961111111", "anv@fpt.com", 10, "NET"),
                new Experience("Tran Van B", new DateOnly(1993, 1, 1), "0961111112", "btv@fpt.com", 7, "NET"),
                new Experience("Le Thi C", new DateOnly(1995, 1, 1), "0961111113", "clt@fpt.com", 5, "NET"),

                new Fresher("Dang Thi D", new DateOnly(1998, 1, 1), "0961111114", "ddt@fpt.com", new DateOnly(2021, 1, 1), "Good", "Hanoi University"),
                new Fresher("Dinh Van E", new DateOnly(1999, 1, 1), "0961111115", "edv@fpt.com", new DateOnly(2022, 1, 1), "Average", "Danang University"),
                new Fresher("Trinh Thi F", new DateOnly(2000, 1, 1), "0961111116", "ftt@fpt.com", new DateOnly(2023, 1, 1), "Excellent", "Haiphong University"),

                new Intern("Dao Van G", new DateOnly(2002, 1, 1), "0961111117", "gdv@fpt.com", "Infomation Techonology", "2023A", "Hanoi University"),
                new Intern("Giang Thi H", new DateOnly(2003, 1, 1), "0961111118", "hgt@fpt.com", "Infomation Techonology", "2023A", "Danang University"),
                new Intern("Kieu Van I", new DateOnly(2004, 1, 1), "0961111119", "ikv@fpt.com", "Infomation Techonology", "2023A", "Hanoi University")
            };
        }
        public void ValidateBirthday(int day, int month, int year)
        {
            if ((month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) && (day <= 31 && day >= 1))
                return;
            else if ((month == 4 || month == 6 || month == 9 || month == 11) && (day <= 30 && day >= 1))
                return;
            else if ((month == 2) && (year % 4 == 0) && (day <= 29 && day >= 1))
                return;
            else if ((month == 2) && (year % 4 != 0) && (day <= 28 && day >= 1))
                return;

            throw new BirthDayException(day + "/" + month + "/" + year);
        }
        public void ValidatePhone(string phone)
        {
            //Regex regex = new Regex("/((^(\\+84|84|0|0084){1})(3|5|7|8|9))+([0-9]{8})$/");
            //if (regex.IsMatch(phone)) { throw new PhoneException(phone); }
            if (phone.Length != 10) { throw new PhoneException(phone); }
        }
        public void ValidateEmail(string email) { if (!(email.Contains('@') && email.Contains('.'))) { throw new EmailException(email); } }
        public void ValidateFullName(string fullName)
        {
            foreach (char c in fullName)
            {
                if ((c == ' ' || c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z') == false) { throw new FullNameException(fullName); }
            }
        }
        public void AddEmployee()
        {
        ChooseEmployeeType:
            Console.Clear();
            Console.WriteLine("Choose employee type:");
            Console.WriteLine("1. Experience");
            Console.WriteLine("2. Fresher");
            Console.WriteLine("3. Intern");
            string inputType = Console.ReadLine();
            if (inputType != "1" && inputType != "2" && inputType != "3")
                goto ChooseEmployeeType;

            InputFullName:
            Console.Clear();
            Console.WriteLine("Input full name:");
            string fullName = Console.ReadLine();
            try { ValidateFullName(fullName ?? "N/A"); }
            catch (FullNameException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                goto InputFullName;
            }

        InputBirthday:
            Console.Clear();
            Console.WriteLine("Input birthday:");
        InputDay:
            Console.WriteLine("Day:");
            bool isNumDay = int.TryParse(Console.ReadLine(), out int day);
            if (!isNumDay) { goto InputDay; }
        InputMonth:
            Console.WriteLine("Month:");
            bool isNumMonth = int.TryParse(Console.ReadLine(), out int month);
            if (!isNumMonth) { goto InputMonth; }
        InputYear:
            Console.WriteLine("Year:");
            bool isNumYear = int.TryParse(Console.ReadLine(), out int year);
            if (!isNumYear) { goto InputYear; }

            try { ValidateBirthday(day, month, year); }
            catch (BirthDayException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                goto InputBirthday;
            }
            DateOnly birthDay = new DateOnly(year, month, day);

        InputPhone:
            Console.Clear();
            Console.WriteLine("Input phone number:");
            string phone = Console.ReadLine();
            try { ValidatePhone(phone ?? "N/A"); }
            catch (PhoneException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                goto InputPhone;
            }

        InputEmail:
            Console.Clear();
            Console.WriteLine("Input email:");
            string email = Console.ReadLine();
            try { ValidateEmail(email ?? "N/A"); }
            catch (EmailException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                goto InputEmail;
            }

            switch (inputType)
            {
                // EXPERIENCE
                case "1":
                InputYoE:
                    Console.Clear();
                    Console.WriteLine("Input year of experience:");
                    bool isNumYoE = int.TryParse(Console.ReadLine(), out int yoe);
                    if (!isNumYoE) { goto InputYoE; }

                    Console.Clear();
                    Console.WriteLine("Input skill:");
                    string proSkill = Console.ReadLine();

                    _employees.Add(new Experience(fullName, birthDay, phone, email, yoe, proSkill));
                    Console.Write("Added ");
                    _employees.Last().ShowInfo();
                    Console.ReadLine();

                    break;
                // FRESHER
                case "2":
                InputGradDate:
                    Console.Clear();
                    Console.WriteLine("Input graduation date:");
                InputDayGrad:
                    Console.WriteLine("Day:");
                    bool isNumDayGrad = int.TryParse(Console.ReadLine(), out int dayGrad);
                    if (!isNumDayGrad) { goto InputDayGrad; }
                InputMonthGrad:
                    Console.WriteLine("Month:");
                    bool isNumMonthGrad = int.TryParse(Console.ReadLine(), out int monthGrad);
                    if (!isNumMonthGrad) { goto InputMonthGrad; }
                InputYearGrad:
                    Console.WriteLine("Year:");
                    bool isNumYearGrad = int.TryParse(Console.ReadLine(), out int yearGrad);
                    if (!isNumYearGrad) { goto InputYearGrad; }

                    try { ValidateBirthday(dayGrad, monthGrad, yearGrad); }
                    catch (BirthDayException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                        goto InputGradDate;
                    }
                    DateOnly graduationDate = new DateOnly(yearGrad, monthGrad, dayGrad);

                InputGradRank:
                    Console.Clear();
                    Console.WriteLine("Chose graduation rank:");
                    Console.WriteLine("1. Average");
                    Console.WriteLine("2. Good");
                    Console.WriteLine("3. Excellent");
                    string inputGradRank = Console.ReadLine();
                    if (inputGradRank != "1" && inputGradRank != "2" && inputGradRank != "3")
                        goto InputGradRank;

                    Console.Clear();
                    Console.WriteLine("Input school name:");
                    string schoolName = Console.ReadLine();

                    string graduationRank;
                    switch (inputGradRank)
                    {
                        case "1":
                            graduationRank = "Average";
                            _employees.Add(new Fresher(fullName, birthDay, phone, email, graduationDate, graduationRank, schoolName));
                            Console.Write("Added ");
                            _employees.Last().ShowInfo();
                            Console.ReadLine();

                            break;
                        case "2":
                            graduationRank = "Good";
                            _employees.Add(new Fresher(fullName, birthDay, phone, email, graduationDate, graduationRank, schoolName));
                            Console.Write("Added ");
                            _employees.Last().ShowInfo();
                            Console.ReadLine();

                            break;
                        case "3":
                            graduationRank = "Excellent";
                            _employees.Add(new Fresher(fullName, birthDay, phone, email, graduationDate, graduationRank, schoolName));
                            Console.Write("Added ");
                            _employees.Last().ShowInfo();
                            Console.ReadLine();

                            break;
                    }

                    break;
                // INTERN
                case "3":
                    Console.Clear();
                    Console.WriteLine("Input major:");
                    string major = Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine("Input semester:");
                    string semester = Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine("Input university name:");
                    string universityName = Console.ReadLine();

                    _employees.Add(new Intern(fullName, birthDay, phone, email, major, semester, universityName));
                    Console.Write("Added ");
                    _employees.Last().ShowInfo();
                    Console.ReadLine();

                    break;
            }
        }
        public void ModifyEmployee()
        {
        InputEmployeeID:
            Console.Clear();
            Console.WriteLine("Input employee ID:");
            bool isNumEmployeeID = int.TryParse(Console.ReadLine(), out int employeeID);
            if (!isNumEmployeeID) { goto InputEmployeeID; }

            Employee employeeResult = _employees.SingleOrDefault(employee => employee.ID == employeeID);
            if (employeeResult == null)
            {
                Console.WriteLine("Employee ID not found");
                Console.ReadLine();
                return;
            }

        InputModify:
            Console.Clear();
            employeeResult.ShowInfo();
            Console.WriteLine();
            Console.WriteLine("Choose an info to modify:");
            Console.WriteLine("1. Full name");
            Console.WriteLine("2. Birthday");
            Console.WriteLine("3. Phone");
            Console.WriteLine("4. Email");
            //Console.WriteLine("5. Employee type");
            if (employeeResult is Experience)
            {
                Console.WriteLine("5. Year of experience");
                Console.WriteLine("6. Skill");
            }
            else if (employeeResult is Fresher)
            {
                Console.WriteLine("5. Graduation date");
                Console.WriteLine("6. Graduation rank");
                Console.WriteLine("7. University name");
            }
            else if (employeeResult is Intern)
            {
                Console.WriteLine("5. Major");
                Console.WriteLine("6. Semester");
                Console.WriteLine("7. University name");
            }
            string inputModify = Console.ReadLine();
            if (employeeResult is Experience)
            {
                if (inputModify != "1" && inputModify != "2" && inputModify != "3" && inputModify != "4" && inputModify != "5" && inputModify != "6" && inputModify != "7")
                    goto InputModify;
            }
            else if (employeeResult is Fresher || employeeResult is Intern)
            {
                if (inputModify != "1" && inputModify != "2" && inputModify != "3" && inputModify != "4" && inputModify != "5" && inputModify != "6" && inputModify != "7" && inputModify != "8")
                    goto InputModify;
            }

            switch (inputModify)
            {
                case "1":
                InputFullName:
                    Console.Clear();
                    Console.WriteLine("Input full name:");
                    string fullName = Console.ReadLine();
                    try { ValidateFullName(fullName ?? "N/A"); }
                    catch (FullNameException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                        goto InputFullName;
                    }
                    employeeResult.FullName = fullName;

                    break;
                case "2":
                InputBirthday:
                    Console.Clear();
                    Console.WriteLine("Input birthday:");
                InputDay:
                    Console.WriteLine("Day:");
                    bool isNumDay = int.TryParse(Console.ReadLine(), out int day);
                    if (!isNumDay) { goto InputDay; }
                InputMonth:
                    Console.WriteLine("Month:");
                    bool isNumMonth = int.TryParse(Console.ReadLine(), out int month);
                    if (!isNumMonth) { goto InputMonth; }
                InputYear:
                    Console.WriteLine("Year:");
                    bool isNumYear = int.TryParse(Console.ReadLine(), out int year);
                    if (!isNumYear) { goto InputYear; }

                    try { ValidateBirthday(day, month, year); }
                    catch (BirthDayException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                        goto InputBirthday;
                    }
                    DateOnly birthDay = new DateOnly(year, month, day);
                    employeeResult.BirthDay = birthDay;

                    break;
                case "3":
                InputPhone:
                    Console.Clear();
                    Console.WriteLine("Input phone number:");
                    string phone = Console.ReadLine();
                    try { ValidatePhone(phone ?? "N/A"); }
                    catch (PhoneException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                        goto InputPhone;
                    }
                    employeeResult.Phone = phone;

                    break;
                case "4":
                InputEmail:
                    Console.Clear();
                    Console.WriteLine("Input email:");
                    string email = Console.ReadLine();
                    try { ValidateEmail(email ?? "N/A"); }
                    catch (EmailException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                        goto InputEmail;
                    }
                    employeeResult.Email = email;

                    break;
            }
            if (employeeResult is Experience)
            {
                Experience experience = employeeResult as Experience;
                switch (inputModify)
                {
                    case "5":
                    InputYoE:
                        Console.Clear();
                        Console.WriteLine("Input year of experience:");
                        bool isNumYoE = int.TryParse(Console.ReadLine(), out int yoe);
                        if (!isNumYoE) { goto InputYoE; }
                        experience.ExpInYear = yoe;

                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Input skill:");
                        string proSkill = Console.ReadLine() ?? "N/A";
                        experience.ProSkill = proSkill;

                        break;
                }
            }
            else if (employeeResult is Fresher)
            {
                Fresher fresher = employeeResult as Fresher;
                switch (inputModify)
                {
                    case "5":
                    InputGradDate:
                        Console.Clear();
                        Console.WriteLine("Input graduation date:");
                    InputDayGrad:
                        Console.WriteLine("Day:");
                        bool isNumDayGrad = int.TryParse(Console.ReadLine(), out int dayGrad);
                        if (!isNumDayGrad) { goto InputDayGrad; }
                    InputMonthGrad:
                        Console.WriteLine("Month:");
                        bool isNumMonthGrad = int.TryParse(Console.ReadLine(), out int monthGrad);
                        if (!isNumMonthGrad) { goto InputMonthGrad; }
                    InputYearGrad:
                        Console.WriteLine("Year:");
                        bool isNumYearGrad = int.TryParse(Console.ReadLine(), out int yearGrad);
                        if (!isNumYearGrad) { goto InputYearGrad; }

                        try { ValidateBirthday(dayGrad, monthGrad, yearGrad); }
                        catch (BirthDayException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadLine();
                            goto InputGradDate;
                        }
                        fresher.GraduationDate = new DateOnly(yearGrad, monthGrad, dayGrad);

                        break;
                    case "6":
                    InputGradRank:
                        Console.Clear();
                        Console.WriteLine("Chose graduation rank:");
                        Console.WriteLine("1. Average");
                        Console.WriteLine("2. Good");
                        Console.WriteLine("3. Excellent");
                        string inputGradRank = Console.ReadLine();
                        if (inputGradRank != "1" && inputGradRank != "2" && inputGradRank != "3")
                            goto InputGradRank;
                        switch (inputGradRank)
                        {
                            case "1": fresher.GraduationRank = "Average"; break;
                            case "2": fresher.GraduationRank = "Good"; break;
                            case "3": fresher.GraduationRank = "Excellent"; break;
                        }

                        break;
                    case "7":
                        Console.Clear();
                        Console.WriteLine("Input school name:");
                        string schoolName = Console.ReadLine() ?? "N/A";
                        fresher.SchoolName = schoolName;

                        break;
                }
            }
            else if (employeeResult is Intern)
            {
                Intern intern = employeeResult as Intern;
                switch (inputModify)
                {
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Input major:");
                        string major = Console.ReadLine() ?? "N/A";
                        intern.Major = major;

                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Input semester:");
                        string semester = Console.ReadLine() ?? "N/A";
                        intern.Semester = semester;

                        break;
                    case "7":
                        Console.Clear();
                        Console.WriteLine("Input university name:");
                        string universityName = Console.ReadLine() ?? "N/A";
                        intern.UniversityName = universityName;

                        break;
                }
            }
        }
        public void DeleteEmployee()
        {
        InputEmployeeID:
            Console.Clear();
            Console.WriteLine("Input employee ID:");
            bool isNumEmployeeID = int.TryParse(Console.ReadLine(), out int employeeID);
            if (!isNumEmployeeID) { goto InputEmployeeID; }

            Employee employeeResult = _employees.SingleOrDefault(employee => employee.ID == employeeID);
            if (employeeResult == null)
            {
                Console.WriteLine("Employee ID not found");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.Write("Delete ");
                employeeResult.ShowInfo();
                Console.ReadLine();
                _employees.Remove(employeeResult);
            }
        }
        public void FindByType()
        {
        ChooseEmployeeType:
            Console.Clear();
            Console.WriteLine("Choose employee type:");
            Console.WriteLine("1. Experience");
            Console.WriteLine("2. Fresher");
            Console.WriteLine("3. Intern");
            string inputType = Console.ReadLine();
            if (inputType != "1" && inputType != "2" && inputType != "3")
                goto ChooseEmployeeType;

            switch (inputType)
            {
                case "1":
                    IEnumerable<Employee> experiences = _employees.Where(employee => employee is Experience);
                    if (experiences == null)
                    {
                        Console.WriteLine("No employee of type Experience");
                        Console.ReadLine();
                    }
                    else
                    {
                        foreach (Experience employee in experiences)
                        {
                            employee.ShowInfo();
                            Console.WriteLine();
                        }
                        Console.ReadLine();
                    }

                    break;
                case "2":
                    IEnumerable<Employee> freshers = _employees.Where(employee => employee is Fresher);
                    if (freshers == null)
                    {
                        Console.WriteLine("No employee of type Fresher");
                        Console.ReadLine();
                    }
                    else
                    {
                        foreach (Fresher employee in freshers)
                        {
                            employee.ShowInfo();
                            Console.WriteLine();
                        }
                        Console.ReadLine();
                    }

                    break;
                case "3":
                    IEnumerable<Employee> interns = _employees.Where(employee => employee is Intern);
                    if (interns == null)
                    {
                        Console.WriteLine("No employee of type Fresher");
                        Console.ReadLine();
                    }
                    else
                    {
                        foreach (Intern employee in interns)
                        {
                            employee.ShowInfo();
                            Console.WriteLine();
                        }
                        Console.ReadLine();
                    }

                    break;
            }
        }
        public void ShowAll()
        {
            Console.Clear();
            foreach (Employee employee in _employees)
            {
                employee.ShowInfo();
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}