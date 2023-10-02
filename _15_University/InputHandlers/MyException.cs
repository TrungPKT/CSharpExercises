using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_University.InputHandlers
{
    enum ExceptionType
    {
        FullName, AdmittedYear, EntryGrade, NumberOfSemesters, GradeAverage, TrainingPlace, None
    }
    internal class InvalidFullName : Exception
    {
        public InvalidFullName(string name) : base(name)
        {
        }
    }
    internal class InvalidAdmittedYear : Exception
    {
        public InvalidAdmittedYear(string year) : base(year)
        {
        }
    }
    internal class InvalidEntryGrade : Exception
    {
        public InvalidEntryGrade(string grade) : base(grade)
        {
        }
    }
    internal class InvalidNumberOfSemesters : Exception
    {
        public InvalidNumberOfSemesters(string numberOfSemester) : base(numberOfSemester)
        {
        }
    }
    /*internal class InvalidSemester : Exception
    {
        public InvalidSemester(string semester) : base(semester)
        {
        }
    }*/
    internal class InvalidGradeAverage : Exception
    {
        public InvalidGradeAverage(string grade) : base(grade)
        {
        }
    }
    internal class InvalidTrainingPlace : Exception
    {
        public InvalidTrainingPlace(string place) : base(place)
        {
        }
    }
}
