using _4_ResidentArea.Source;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace _4_ResidentArea.InputHandlers
{
    internal class Input
    {
        private static void ValidateBlockName(string blockName)
        {
            if (blockName == "")
                throw new InvalidBlockName("No Input");

            foreach (char c in blockName)
            {
                if ((c >= '0' && c <= '9') == false && (c >= 'a' && c <= 'z') == false && (c >= 'A' && c <= 'Z') == false && c != ' ')
                    throw new InvalidBlockName("Input space, alphabet and numeric character only");
            }
        }
        private static void ValidateFullName(string name)
        {
            if (name == "")
                throw new InvalidFullName("No Input");

            foreach (char c in name)
            {
                if ((c >= 'a' && c <= 'z') == false && (c >= 'A' && c <= 'Z') == false && c != ' ')
                    throw new InvalidFullName("Input space and alphabet character only");
            }
        }
        /*private static void ValidateAdmittedYear(int year)
        {
            int currentYear = DateTime.Today.Year;
            const int maxYearRange = 3;
            if (year < currentYear - maxYearRange || year > currentYear)
                throw new InvalidAdmittedYear(year);
        }
        private static void ValidateEntryGrade(double grade)
        {
            const double minGrade = 20;
            const double maxGrade = 30;
            if (grade < minGrade || grade > maxGrade)
                throw new InvalidEntryGrade(grade);
        }
        private static void ValidateNumberOfSemesters(int numberOfSemesters)
        {
            const int maxNumberOfSemesters = 30;
            if (numberOfSemesters <= 0 || numberOfSemesters > maxNumberOfSemesters)
                throw new InvalidNumberOfSemesters(numberOfSemesters);
        }
        private static void ValidateSemester(string semester)
        {
            int currentYear = DateTime.Today.Year;
            const int maxYear = 10;
            List<string> listOfSemester = new List<string>();
            for (int i = 0; i < maxYear; i++)
            {
                int tempYear = currentYear - i;
                string semesterA = new string(tempYear + "A");
                string semesterB = new string(tempYear + "B");
                string semesterC = new string(tempYear + "C");
                listOfSemester.Add(semesterA);
                listOfSemester.Add(semesterB);
                listOfSemester.Add(semesterC);
            }
            if (listOfSemester.Contains(semester) == false)
                throw new InvalidSemester(semester);
        }
        private static void ValidateGradeAverage(double avgGrade)
        {
            const double minGrade = 0.0;
            const double maxGrade = 10.0;
            if (avgGrade < minGrade || avgGrade > maxGrade)
                throw new InvalidEntryGrade(avgGrade);
        }
        private static void ValidateTrainingPlace(string place)
        {
            if (place == null)
                throw new InvalidTrainingPlace("Must not be null");
        }*/
        private static void ValidateNumberOfResident(int numberOfResidents)
        {
            const int minNumberOfResidents = 1;
            const int maxNumberOfResidents = 3;
            if (numberOfResidents < minNumberOfResidents || numberOfResidents > maxNumberOfResidents)
                throw new InvalidNumberOfResidents("Number of residents must be between " + minNumberOfResidents + " and " + maxNumberOfResidents);
        }
        private static void ValidateNumberOfPeople(int numberOfPeople)
        {
            const int minNumberOfPeople = 1;
            const int maxNumberOfPeople = 5;
            if (numberOfPeople < minNumberOfPeople || numberOfPeople > maxNumberOfPeople)
                throw new InvalidNumberOfPeople("Number of people must be between " + minNumberOfPeople + " and " + maxNumberOfPeople);
        }
        private static void ValidateResidentAddress(string residentAddress)
        {
            if (residentAddress == "")
                throw new InvalidResidentAddress("No Input");

            foreach (char c in residentAddress)
            {
                if ((c >= '0' && c <= '9') == false && (c >= 'a' && c <= 'z') == false && (c >= 'A' && c <= 'Z') == false && c != ' ')
                    throw new InvalidResidentAddress("Input space, alphabet and numeric character only");
            }
        }
        private static void ValidateAge(int age)
        {
            const int minAge = 0;
            const int maxAge = 150;
            if (age < minAge || age > maxAge)
                throw new InvalidAge("Age must be between" + minAge + " and " + maxAge);
        }
        private static void ValidateOccupation(string occupation)
        {
            if (occupation == "")
                throw new InvalidOccupation("No Input");

            foreach (char c in occupation)
            {
                if ((c >= 'a' && c <= 'z') == false && (c >= 'A' && c <= 'Z') == false && c != ' ')
                    throw new InvalidOccupation("Input space and alphabet character only");
            }
        }
        private static void ValidateNationalID(ManagementSystem mS, string nationalID)
        {
            if (nationalID == "")
                throw new InvalidNationalID("No Input");

            var query = (from block in mS.Blocks
                        from resident in block.Residents
                        from person in resident.Persons
                        select person).FirstOrDefault(person => person.NationalID == nationalID);

            if (query != null)
                throw new InvalidNationalID("National ID " + nationalID + " has already existed");

            foreach (char c in nationalID)
            {
                if ((c >= '0' && c <= '9') == false)
                    throw new InvalidNationalID("Input numeric character only");
            }

            if (nationalID.Length != 12)
                throw new InvalidNationalID("National ID must has 12 digits");
        }
        public static T GetInput<T>(ManagementSystem mS, string prompt, ExceptionType type = ExceptionType.None, bool clearScreen = true)
        {
            Console.Clear();
            while (true)
            {
                try
                {
                    Console.WriteLine(prompt);
                    dynamic input = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                    if (clearScreen)
                        Console.Clear();
                    switch (type)
                    {
                        case ExceptionType.BlockName:
                            ValidateBlockName(input);
                            break;
                        case ExceptionType.NumberOfResidents:
                            ValidateNumberOfResident(input);
                            break;
                        case ExceptionType.ResidentAddress:
                            ValidateResidentAddress(input);
                            break;
                        case ExceptionType.NumberOfPeople:
                            ValidateNumberOfPeople(input);
                            break;
                        case ExceptionType.FullName:
                            ValidateFullName(input);
                            break;
                        case ExceptionType.Age:
                            ValidateAge(input);
                            break;
                        case ExceptionType.Occupation:
                            ValidateOccupation(input);
                            break;
                        case ExceptionType.NationalID:
                            ValidateNationalID(mS, input);
                            break;
                        case ExceptionType.None:
                            break;
                    }
                    return input;
                }
                catch (Exception ex)
                {
                    if (clearScreen)
                        Console.Clear();
                    Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
                }
            }
        }
        public static string OptionPrompt(string prompt, string[] options)
        {
            Console.Clear();
        InputOption:
            Console.WriteLine(prompt);
            foreach (string option in options)
                Console.WriteLine(option);

            Console.Write("\nInput here: ");
            string? input = Console.ReadLine()?.Trim();
            input = input == "" ? "No input" : input;
            Console.Clear();
            bool flag = false;
            for (int i = 0; i < options.Length; i++)
            {
                int option = i + 1;
                if (input == option.ToString())
                {
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("InvalidOption: " + input);
                goto InputOption;
            }

            return input ?? "-1";
        }
    }
}
