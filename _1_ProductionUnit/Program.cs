namespace _1_ProductionUnit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string state = "0";

            while (state != "-1")
            {
                switch (state)
                {
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Officer Management System");
                        Console.WriteLine("Choose one option:");
                        Console.WriteLine("1. Add a new officer.");
                        Console.WriteLine("2. Find officer by name.");
                        Console.WriteLine("3. Display all officers' infomation.");
                        Console.WriteLine("4. Exit program.");
                        Console.Write("Your input: ");

                        string input = Console.ReadLine() ?? "-1";
                        if (input == "1" || input == "2" || input == "3" || input == "4")
                            state = input;
                        else
                            state = "0";

                        break;

                    case "1":
                        Console.Clear();
                        Console.WriteLine("What type of Officer?");
                        Console.WriteLine("1. Worker");
                        Console.WriteLine("2. Engineer");
                        Console.WriteLine("3. Staff");
                        Console.Write("Your input: ");

                        string type = Console.ReadLine() ?? "-1";
                        if (type != "1" && type != "2" && type != "3")
                        {
                            state = "1";
                            break;
                        }

                        switch (type)
                        {
                            case "1":
                                Worker addedWorker = new Worker();
                                OfficerManagement.AddCommonInfo(addedWorker);
                            InputLevel:
                                Console.Clear();
                                Console.WriteLine("Input level (from 1 to 10):");
                                bool isNum = Int32.TryParse(Console.ReadLine(), out int level);
                                if (!isNum) { goto InputLevel; }
                                addedWorker.Level = level;
                                OfficerManagement.AddOfficer(addedWorker);

                                break;
                            case "2":
                                Engineer addedEngineer = new Engineer();
                                OfficerManagement.AddCommonInfo(addedEngineer);
                                Console.Clear();
                                Console.WriteLine("Input major:");
                                addedEngineer.Major = Console.ReadLine();
                                OfficerManagement.AddOfficer(addedEngineer);

                                break;
                            case "3":
                                Staff addedStaff = new Staff();
                                OfficerManagement.AddCommonInfo(addedStaff);
                                Console.Clear();
                                Console.WriteLine("Input task:");
                                addedStaff.Task = Console.ReadLine();
                                OfficerManagement.AddOfficer(addedStaff);

                                break;
                        }
                        
                        // Back to state 0
                        state = "0";

                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Input name of officer:");
                        OfficerManagement.GetOfficerByName(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();

                        state = "0";

                        break;
                    case "3":
                        Console.Clear();
                        OfficerManagement.GetAllOfficers();
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();

                        state = "0";

                        break;
                    case "4":
                        // Exit application
                        state = "-1";

                        break;
                }
            }

        }
    }
}