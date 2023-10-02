namespace _4_ResidentArea.Source
{
    internal class ManagementSystem
    {
        public List<Block> Blocks { get; set; }
        public ManagementSystem()
        {
            Blocks = new List<Block>();
        }
        public void DisplayAll()
        {
            foreach (var block in Blocks)
            {
                Console.WriteLine(block);
            }
        }
    }
}
