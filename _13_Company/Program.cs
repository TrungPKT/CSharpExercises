namespace _13_Company
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeManagement eM = new EmployeeManagement();

            string state = "0";

            while (state != "-1")
            {
                switch (state)
                {
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Employee Management System");
                        Console.WriteLine("Choose an option:");
                        Console.WriteLine("1. Add a new employee");
                        Console.WriteLine("2. Modify employee info");
                        Console.WriteLine("3. Delete an employee");
                        Console.WriteLine("4. Find all employees by type");
                        Console.WriteLine("5. Show all employees");
                        Console.WriteLine("6. Exit program");

                        string input0 = Console.ReadLine();
                        if (input0 != "1" && input0 != "2" && input0 != "3" && input0 != "4" && input0 != "5" && input0 != "6")
                            goto case "0";

                        state = input0;

                        break;
                    case "1":
                        eM.AddEmployee();

                        state = "0";

                        break;
                    case "2":
                        eM.ModifyEmployee();

                        state = "0";

                        break;
                    case "3":
                        eM.DeleteEmployee();

                        state = "0";

                        break;
                    case "4":
                        eM.FindByType();

                        state = "0";

                        break;
                    case "5":
                        eM.ShowAll();

                        state = "0";

                        break;
                    case "6":
                        state = "-1";

                        break;
                }
            }
        }
    }
}