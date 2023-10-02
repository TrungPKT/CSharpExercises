using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _15_University.Source
{
    /*public enum ETrainingPlace
    {
        Hanoi, HaiPhong, DaNang
    }
    public static class ETrainingPlaceExtensions
    {
        public static string ToStringCustom(this ETrainingPlace place)
        {
            if (place == ETrainingPlace.Hanoi)
                return "Hanoi Training Center";
            else if (place == ETrainingPlace.HaiPhong)
                return "HaiPhong Training Center";

            return "DaNang Training Center";
        }
    }*/
    internal class InService : Student
    {
        public string TrainingPlace { get; set; }
        public InService() : base()
        {
            TrainingPlace = string.Empty;
        }
        public InService(string fullName, DateTime birthDay, int admittedYear, double entryGrade, SortedList<int, double> allGrades, string trainingPlace)
            : base(fullName, birthDay, admittedYear, entryGrade, allGrades)
        {
            TrainingPlace = trainingPlace;
        }
        public InService(InService other) : base(other)
        {
            TrainingPlace = other.TrainingPlace;
        }
        public override string ToString()
        {
            string result = string.Empty;

            string studentInfo = base.ToString();
            string insertPlace = ", Entry grade: ";
            int startIndex = studentInfo.IndexOf(insertPlace) + insertPlace.Length + 4;
            
            result = studentInfo.Insert(startIndex, $", Training place: {TrainingPlace}");

            return result;
        }
    }
}
