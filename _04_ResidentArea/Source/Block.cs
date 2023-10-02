using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_ResidentArea.Source
{
    internal class Block
    {
        public List<Resident> Residents;
        public string Name { get; set; }
        public Block()
        {
            Residents = new List<Resident>();
            Name = string.Empty;
        }
        public Block(string blockName)
        {
            Residents = new List<Resident>();
            Name = blockName;
        }
        public Block(List<Resident> residents, string blockName)
        {
            Residents = residents;
            Name = blockName;
        }
        public override string ToString()
        {
            string residentsInfo = string.Empty;
            foreach (Resident resident in Residents) { residentsInfo += "\n" + resident; }
            residentsInfo += "\n";
            return Name + " has " + Residents.Count + " residents:\n" + residentsInfo;
        }
    }
}
