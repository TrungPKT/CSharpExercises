using _4_ResidentArea.InputHandlers;
using _4_ResidentArea.Source;

namespace _4_ResidentArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*var peopleInResident0 = new List<Person>
            {
                new Person("Nguyen Van A", 30, "Doctor", "01"),
                new Person("Tran thi B", 26, "Accountant", "02"),
                new Person("Nguyen Van C", 4, "None", "03")
            };
            var peopleInResident1 = new List<Person>
            {
                new Person("Tran Van A", 43, "Worker", "04"),
                new Person("Le thi B", 38, "Teller", "05"),
                new Person("Tran Van C", 22, "Teacher", "06"),
                new Person("Tran Van D", 16, "None", "07")
            };
            var peopleInResident2 = new List<Person>
            {
                new Person("Trinh Van A", 68, "None", "08"),
                new Person("Hoang thi B", 62, "None", "09")
            };
            var peopleInResident3 = new List<Person>
            {
                new Person("Le Van A", 80, "None", "10")
            };

            var residentsInBlock0 = new List<Resident>
            {
                new Resident(peopleInResident0, "01 Tran Dai Nghia street"),
                new Resident(peopleInResident1, "02 Tran Dai Nghia street")
            };
            var residentsInBlock1 = new List<Resident>
            {
                new Resident(peopleInResident2, "01 Le Thanh Nghi street"),
                new Resident(peopleInResident3, "02 Le Thanh Nghi street")
            };

            var blocks = new List<Block>
            {
                new Block(residentsInBlock0, "Block A"),
                new Block(residentsInBlock1, "Block B")
            };

            foreach (var block in blocks) { Console.WriteLine(block.ToString()); }

            Console.WriteLine();*/
            ManagementSystem mS = new ManagementSystem();

            string blockName = Input.GetInput<string>(mS, "Input block name:", ExceptionType.BlockName);

            int numberOfResidents = Input.GetInput<int>(mS, "Input number of residents:", ExceptionType.NumberOfResidents);
            for (int i = 0; i < numberOfResidents; i++)
            {
                string residentAddress = Input.GetInput<string>(mS, "Input resident address:", ExceptionType.ResidentAddress);

                int residentNumber = i + 1;
                int numberOfPeople = Input.GetInput<int>(mS, "Input number of people in resident " + residentNumber + ":", ExceptionType.NumberOfPeople);
                for (int j = 0; j < numberOfPeople; j++)
                {
                    int personNumber = j + 1;
                    string name = Input.GetInput<string>(mS, "Input person " + personNumber + " name:", ExceptionType.FullName);
                    int age = Input.GetInput<int>(mS, "Input person " + personNumber + " age:", ExceptionType.Age);
                    string occupation = Input.GetInput<string>(mS, "Input person " + personNumber + " occupation:", ExceptionType.Occupation);
                    string nationalID = Input.GetInput<string>(mS, "Input person " + personNumber + " national ID:", ExceptionType.NationalID);

                    Person person = new Person(name, age, occupation, nationalID);

                    Block block = null;
                    if (mS.Blocks.Find(block => block.Name == blockName) == null)
                    {
                        mS.Blocks.Add(new Block(blockName));
                        block = mS.Blocks.Last();
                    }
                    else
                    {
                        block = mS.Blocks.FirstOrDefault(block => block.Name == blockName);
                    }

                    Resident resident = null;
                    if (block.Residents.Find(resident => resident.Address == residentAddress) == null)
                    {
                        block.Residents.Add(new Resident(residentAddress));
                        resident = block.Residents.Last();
                    }
                    else
                    {
                        resident = block.Residents.FirstOrDefault(resident => resident.Address == residentAddress);
                    }
                    resident.Persons.Add(person);

                    Console.WriteLine("Added " + person + " to resident at " + resident.Address + ", " + block.Name);
                    Console.ReadLine();
                }
            }

            Console.Clear();
            mS.DisplayAll();
            Console.ReadLine();
        }
    }
}