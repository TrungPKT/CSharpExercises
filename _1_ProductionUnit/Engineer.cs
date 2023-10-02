using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace _1_ProductionUnit
{
    internal class Engineer : Officer
    {
        // Properties
        public string Major { get; set; }
        // Methods
        public Engineer() : base() { Major = string.Empty; }
        public Engineer(string name, int age, string gender, string address, string major) : base(name, age, gender, address)
        {
            Major = major;
        }
        public override string ToString()
        {
            string str = base.ToString() + $", major: {Major}";
            return str;
        }
    }
}
