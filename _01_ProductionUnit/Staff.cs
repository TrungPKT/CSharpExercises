using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace _1_ProductionUnit
{
    internal class Staff : Officer
    {
        // Properties
        public string Task { get; set; }
        // Methods
        public Staff() : base() { Task = string.Empty; }
        public Staff(string name, int age, string gender, string address, string task) : base(name, age, gender, address)
        {
            Task = task;
        }
        public override string ToString()
        {
            string str = base.ToString() + $", task: {Task}";
            return str;
        }
    }
}
