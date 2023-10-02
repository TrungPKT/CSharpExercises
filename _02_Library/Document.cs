namespace _2_Library
{
    abstract class Document
    {
        private static int idGeneration = 0;
        // Properties
        public int DocumentID { get; set; }
        public string Publisher { get; set; }
        public int? CopyNumber { get; set; }
        // Method
        public Document()
        {
            DocumentID = ++idGeneration;
            Publisher = string.Empty;
            CopyNumber = null;
        }
        public Document(string publisher, int? numberOfCopies)
        {
            DocumentID = ++idGeneration;
            Publisher = publisher;
            CopyNumber = numberOfCopies;
        }
    }
}
