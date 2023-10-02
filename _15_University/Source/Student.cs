using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _15_University.Source
{
    /*internal struct Grades
    {
        public string Semester { get; set; }
        public double GradeAverage { get; set; }
        public override string ToString()
        {
            return $"{Semester,10} {GradeAverage,5}";
        }
    }*/
    public static class SortedListExtensions
    {
        public static string ToStringCustom(this SortedList<int, double> allGrades)
        {
            string kvps = string.Empty;
            foreach (var key in allGrades.Keys)
            {
                kvps += "Semester " + key + ": " + allGrades[key] + ", ";
            }
            return kvps;
        }
    }
    //class DescendingComparer : IComparer<string>
    //{
    //    public int Compare(string x, string y)
    //    {
    //        return y.CompareTo(x);
    //    }
    //}
    internal class Student
    {
        private static int IDGenerator = 0;
        public int StudentID { get; private set; }
        public string FullName { get; set; }
        public DateTime BirthDay { get; set; }
        public int AdmittedYear { get; set; }
        public double EntryGrade { get; set; }
        public SortedList<int, double> AllGrades { get; set; }
        public Type StudentType { get; set; }
        public Student()
        {
            StudentID = ++IDGenerator;
            FullName = string.Empty;
            BirthDay = new DateTime();
            AdmittedYear = -1;
            EntryGrade = -1;
            AllGrades = new SortedList<int, double>();
            StudentType = GetType();
        }
        public Student(string fullName, DateTime birthDay, int admittedYear, double entryGrade, SortedList<int, double> allGrades)
        {
            StudentID = ++IDGenerator;
            FullName = fullName;
            BirthDay = birthDay;
            AdmittedYear = admittedYear;
            EntryGrade = entryGrade;
            AllGrades = allGrades;
            StudentType = GetType();
        }
        public Student(Student other)
        {
            StudentID = other.StudentID;
            FullName = other.FullName;
            BirthDay = other.BirthDay;
            AdmittedYear = other.AdmittedYear;
            EntryGrade = other.EntryGrade;
            AllGrades = other.AllGrades;
            StudentType = GetType();
        }
        public override string ToString()
        {
            return $"ID: {StudentID}, Student type: {StudentType.Name}, Full name: {FullName}, Birthday: {BirthDay.ToShortDateString()}, Admitted year: {AdmittedYear}, Entry grade: {EntryGrade, 4}\nGrades: {AllGrades.ToStringCustom()}";
        }
    }
}
