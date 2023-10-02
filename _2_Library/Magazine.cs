namespace _2_Library
{
    internal class Magazine : Document
    {
        // Properties
        public int? PublishNumber { get; set; }
        public int? PublishMonth { get; set; }
        // Methods
        public Magazine() : base()
        {
            PublishNumber = null;
            PublishMonth = null;
        }
        public Magazine(string publisher, int? copyNumber, int? publishNumber, int? publishMonth) : base(publisher, copyNumber)
        {
            PublishNumber = publishNumber;
            PublishMonth = publishMonth;
        }
        public override string ToString()
        {
            return $"{DocumentID}, {Publisher}, {CopyNumber}, {PublishNumber}, {PublishMonth}";
        }
    }
}
