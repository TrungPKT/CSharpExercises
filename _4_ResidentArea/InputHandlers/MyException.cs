using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_ResidentArea.InputHandlers
{
    public enum ExceptionType
    {
        BlockName, NumberOfResidents, NumberOfPeople, ResidentAddress, FullName, Age, Occupation, NationalID, None
    }
    internal class InvalidFullName : Exception
    {
        public InvalidFullName(string? name) : base(name)
        {
        }
    }
    internal class InvalidAge : Exception
    {
        public InvalidAge(string age) : base(age)
        {
        }
    }
    /*internal class InvalidAdmittedYear : Exception
    {
        public InvalidAdmittedYear(int year) : base(year.ToString())
        {
        }
    }
    internal class InvalidEntryGrade : Exception
    {
        public InvalidEntryGrade(double grade) : base(grade.ToString())
        {
        }
    }
    internal class InvalidNumberOfSemesters : Exception
    {
        public InvalidNumberOfSemesters(int numberOfSemester) : base(numberOfSemester.ToString())
        {
        }
    }
    internal class InvalidSemester : Exception
    {
        public InvalidSemester(string semester) : base(semester)
        {
        }
    }
    internal class InvalidGradeAverage : Exception
    {
        public InvalidGradeAverage(int grade) : base(grade.ToString())
        {
        }
    }
    internal class InvalidTrainingPlace : Exception
    {
        public InvalidTrainingPlace(string place) : base(place)
        {
        }
    }*/
    internal class InvalidNumberOfResidents : Exception
    {
        public InvalidNumberOfResidents(string numberOfResidents) : base(numberOfResidents)
        {
        }
    }
    internal class InvalidNumberOfPeople : Exception
    {
        public InvalidNumberOfPeople(string numberOfPeople) : base(numberOfPeople)
        {
        }
    }
    internal class InvalidBlockName : Exception
    {
        public InvalidBlockName(string blockName) : base(blockName)
        {
        }
    }
    internal class InvalidResidentAddress : Exception
    {
        public InvalidResidentAddress(string residentAdress) : base(residentAdress)
        {
        }
    }
    internal class InvalidOccupation : Exception
    {
        public InvalidOccupation(string occupation) : base(occupation)
        {
        }
    }
    internal class InvalidNationalID : Exception
    {
        public InvalidNationalID(string nationalID) : base(nationalID)
        {
        }
    }
}
