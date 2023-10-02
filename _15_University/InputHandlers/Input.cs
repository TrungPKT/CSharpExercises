using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace _15_University.InputHandlers
{
    internal class Input
    {
        private static void ValidateFullName(string name)
        {
            //Regex regex = new Regex("^[a-zA-Z]+$");

            //if (!regex.IsMatch(name))
            //    throw new InvalidFullName(name);
            if (name == "")
                throw new InvalidFullName("No input");

            foreach (char c in name)
            {
                if ((c >= 'a' && c <= 'z') == false && (c >= 'A' && c <= 'Z') == false && c != ' ')
                    throw new InvalidFullName("Input space and alphabet character only");
            }
        }
        private static void ValidateAdmittedYear(int year)
        {
            int currentYear = DateTime.Today.Year;
            const int maxYearRange = 3;
            int startingYear = currentYear - maxYearRange;
            if (year < startingYear || year > currentYear)
                throw new InvalidAdmittedYear($"Admitted year must be in the range from {startingYear} to {currentYear}");
        }
        private static void ValidateEntryGrade(double grade)
        {
            const double minGrade = 20;
            const double maxGrade = 30;
            if (grade < minGrade || grade > maxGrade)
                throw new InvalidEntryGrade($"Entry grade must be in the range from {minGrade} to {maxGrade}");
        }
        private static void ValidateNumberOfSemesters(int numberOfSemesters)
        {
            const int minNumberOfSemesters = 0;
            const int maxNumberOfSemesters = 30;
            if (numberOfSemesters < minNumberOfSemesters || numberOfSemesters > maxNumberOfSemesters)
                throw new InvalidNumberOfSemesters($"Number of semesters must be in the range from {minNumberOfSemesters} to {maxNumberOfSemesters}");
        }
        /*private static void ValidateSemester(string semester)
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
        }*/
        private static void ValidateGradeAverage(double avgGrade)
        {
            const double minGrade = 0.0;
            const double maxGrade = 10.0;
            if (avgGrade < minGrade || avgGrade > maxGrade)
                throw new InvalidEntryGrade($"Number of semesters must be in the range from {minGrade} to {maxGrade}");
        }
        private static void ValidateTrainingPlace(string place)
        {
            if (place == "")
                throw new InvalidTrainingPlace("No input");
        }
        public static T GetInput<T>(string prompt, ExceptionType type = ExceptionType.None, bool clearScreen = true)
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
                        case ExceptionType.FullName:
                            ValidateFullName(input);
                            break;
                        case ExceptionType.AdmittedYear:
                            ValidateAdmittedYear(input);
                            break;
                        case ExceptionType.EntryGrade:
                            ValidateEntryGrade(input);
                            break;
                        case ExceptionType.NumberOfSemesters:
                            ValidateNumberOfSemesters(input);
                            break;
                        /*case ExceptionType.Semester:
                            ValidateSemester(input);
                            break;*/
                        case ExceptionType.GradeAverage:
                            ValidateGradeAverage(input);
                            break;
                        case ExceptionType.TrainingPlace:
                            ValidateTrainingPlace(input);
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
