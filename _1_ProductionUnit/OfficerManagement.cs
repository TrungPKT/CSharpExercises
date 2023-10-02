using System.Threading.Channels;

namespace _1_ProductionUnit
{
    static class OfficerManagement
    {
        // Fields
        private static List<Officer> _officerList;
        // Methods
        static OfficerManagement() { _officerList = new List<Officer>(); }
        public static void AddOfficer(Officer officer)
        {
            _officerList.Add(officer);

            Console.Clear();
            Console.WriteLine(officer.GetType().Name + ": " + officer.ToString() + " Added!");
            Console.ReadLine();
        }
        public static void GetOfficerByName(string name)
        {
            IEnumerable<Officer> officerResult = _officerList.Where(officer => officer.Name.Contains(name));
            
            if (officerResult == null)
            {
                Console.WriteLine("Officer's name is not found.");
                return;           
            }

            Console.WriteLine($"List of all officer whose name contain \"{name}\":");
            foreach (var officer in officerResult) { Console.WriteLine(officer.ToString()); }
        }
        public static void GetAllOfficers()
        {
            _officerList.ForEach(officer => Console.WriteLine(officer.GetType().Name + "'s " + officer));
        }
        public static void AddCommonInfo(Officer officer)
        {
            Console.Clear();
            Console.WriteLine("Input name:");
            officer.Name = Console.ReadLine();

        InputAge:
            Console.Clear();
            Console.WriteLine("Input age:");
            bool isNum = Int32.TryParse(Console.ReadLine(), out int ageInput);
            if (!isNum) { goto InputAge; }
            officer.Age = ageInput;

        InputGender:
            Console.Clear();
            Console.WriteLine("Input gender:");
            Console.WriteLine("1. Male");
            Console.WriteLine("2. Female");
            Console.WriteLine("3. Other");
            string genderInput = Console.ReadLine();
            if (genderInput != "1" && genderInput != "2" && genderInput != "3") { goto InputGender; }
            switch (genderInput)
            {
                case "1":
                    officer.Gender = "Male";
                    break;
                case "2":
                    officer.Gender = "Female";
                    break;
                case "3":
                    officer.Gender = "Other";
                    break;
            }

            Console.Clear();
            Console.WriteLine("Input address:");
            officer.Address = Console.ReadLine();
        }
    }
}
