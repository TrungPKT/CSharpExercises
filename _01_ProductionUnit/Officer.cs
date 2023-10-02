using System;
using System.Collections.Generic;
namespace _1_ProductionUnit
{
    public abstract class Officer
    {
        // Properties
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        // Methods
        public Officer()
        {
            Name = string.Empty;
            Age = null;
            Gender = string.Empty;
            Address = string.Empty;
        }
        public Officer(string name, int age, string gender, string address)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Address = address;
        }
        public override string ToString()
        {
            string str = $"name: {Name}, age: {Age}, gender: {Gender}, address: {Address}";
            return str;
        }
    }
}
