namespace _1_ProductionUnit
{
    public class Worker : Officer
    {
        // Fields
        private int? _level;
        // Properties
        public int? Level
        {
            get { return _level; }
            set { _level = (value >= 0 && value <= 10) ? value : 1; }
        }
        // Method
        public Worker() : base() { Level = null; }
        public Worker(string name, int age, string gender, string address, int level) : base(name, age, gender, address)
        {
            Level = level;
        }
        public override string ToString()
        {
            string str = base.ToString() + $", level: {_level}";
            return str;
        }
    }
}
