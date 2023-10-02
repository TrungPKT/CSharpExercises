namespace _4_ResidentArea.Source
{
    internal class Person
    {
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Occupation { get; set; }
        public string NationalID { get; set; }
        public Person()
        {
            Name = string.Empty;
            Age = null;
            Occupation = string.Empty;
            NationalID = string.Empty;
        }
        public Person(string name, int? age, string occupation, string nationalID)
        {
            Name = name;
            Age = age;
            Occupation = occupation;
            NationalID = nationalID;
        }
        public override string ToString() { return "name: " + Name + ", age: " + Age + ", occupation: " + Occupation + ", national ID: " + NationalID; }
    }
}
