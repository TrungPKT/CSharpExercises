namespace _2_Library
{
    internal class Newspaper : Document
    {
        // Properties
        public int? PublishDate { get; set; }
        // Methods
        public Newspaper() : base()
        {
            PublishDate = null;
        }
        public Newspaper(string publisher, int? copyNumber, int? publishDate) : base(publisher, copyNumber)
        {
            PublishDate = publishDate;
        }
        public override string ToString()
        {
            return $"{DocumentID}, {Publisher}, {CopyNumber}, {PublishDate}";
        }
    }
}
