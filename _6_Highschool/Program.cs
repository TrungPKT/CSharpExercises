namespace _6_Highschool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hs = new Highschool();

            string state = "0";
            
            while (state != "-1")
            {
                switch (state)
                {
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Student management");
                        Console.WriteLine("Choose an option:");
                        Console.WriteLine("1. Add a new student");
                        Console.WriteLine("2. Display students of the same age");
                        Console.WriteLine("3. Get number of students of the same age from same place");
                        Console.WriteLine("4. Exit application");

                        string input0 = Console.ReadLine();
                        if (input0 != "1" && input0 != "2" && input0 != "3" && input0 != "4")
                            goto case "0";
                        state = input0;

                        break;
                    case "1":
                        hs.AddClass();

                        state = "0";

                        break;
                    case "2":
                        hs.DisplayStudentsOfAge();

                        state = "0";

                        break;
                    case "3":
                        hs.GetNumberOfStudentsOfAgeAndPlace();

                        state = "0";

                        break;
                    case "4":
                        state = "-1";

                        break;
                }
            }
        }
    }
}