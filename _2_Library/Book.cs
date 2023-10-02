using System;
using System.Collections.Generic;
using System.Linq;
namespace _2_Library
{
    internal class Book : Document
    {
        // Properties
        public string Author { get; set; }
        public int? Pages { get; set; }
        // Methods
        public Book() : base()
        {
            Author = string.Empty;
            Pages = null;
        }
        public Book(string publisher, int? copyNumber, string author, int? pages) : base(publisher, copyNumber)
        {
            Author = author;
            Pages = pages;
        }
        public override string ToString()
        {
            return $"{DocumentID}, {Publisher}, {CopyNumber}, {Author}, {Pages}";
        }
    }
}
