namespace _4_ResidentArea.Source
{
    internal class Resident
    {
        public List<Person> Persons;
        public string Address { get; set; }
        public Resident()
        {
            Persons = new List<Person>();
            Address = string.Empty;
        }
        public Resident(string address)
        {
            Persons = new List<Person>();
            Address = address;
        }
        public Resident(List<Person> persons, string address)
        {
            Persons = persons;
            Address = address;
        }
        public override string ToString()
        {
            string peopleInfo = string.Empty;
            foreach (Person person in Persons) { peopleInfo += "\n" + person; }
            peopleInfo += "\n";
            return "Resident at " + Address + " has " + Persons.Count + " people:\n" + peopleInfo;
        }
    }
}
