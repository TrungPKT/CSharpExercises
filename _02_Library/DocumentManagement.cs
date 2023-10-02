using System;
using System.Collections.Generic;
using System.Threading.Channels;
using static System.Reflection.Metadata.BlobBuilder;

namespace _2_Library
{
    static class DocumentManagement
    {
        private static List<Document> _documents = new List<Document>();
        public static void AddNewDocument(Document document)
        {
            if (document is Book)
            {
                Book book = document as Book;
                Console.WriteLine("Input publisher:");
                book.Publisher = Console.ReadLine();
            InputCopyNumber:
                Console.WriteLine("Input copy number:");
                if (Int32.TryParse(Console.ReadLine(), out int copyNumber) == false)
                    goto InputCopyNumber;
                book.CopyNumber = copyNumber;
                Console.WriteLine("Input author's name:");
                book.Author = Console.ReadLine();
            InputPages:
                Console.WriteLine("Input number of pages:");
                if (Int32.TryParse(Console.ReadLine(), out int pages) == false)
                    goto InputPages;
                book.Pages = pages;

                _documents.Add(book);
                Console.WriteLine("Added document: " + book.ToString());
                Console.ReadLine();
            }
            else if (document is Magazine)
            {
                Magazine magazine = document as Magazine;
                Console.WriteLine("Input publisher:");
                magazine.Publisher = Console.ReadLine();
            InputCopyNumber:
                Console.WriteLine("Input copy number:");
                if (Int32.TryParse(Console.ReadLine(), out int copyNumber) == false)
                    goto InputCopyNumber;
                magazine.CopyNumber = copyNumber;
            InputPublishNumber:
                Console.WriteLine("Input publish number:");
                if (Int32.TryParse(Console.ReadLine(), out int publishNumber) == false)
                    goto InputPublishNumber;
                magazine.PublishNumber = publishNumber;
            InputPublishMonth:
                Console.WriteLine("Input month:");
                if (Int32.TryParse(Console.ReadLine(), out int publishMonth) == false)
                    goto InputPublishMonth;
                magazine.PublishMonth = publishMonth;

                _documents.Add(magazine);
                Console.WriteLine("Added document: " + magazine.ToString());
                Console.ReadLine();
            }
            else if (document is Newspaper)
            {
                Newspaper newspaper = document as Newspaper;
                Console.WriteLine("Input publisher:");
                newspaper.Publisher = Console.ReadLine();
            InputCopyNumber:
                Console.WriteLine("Input copy number:");
                if (Int32.TryParse(Console.ReadLine(), out int copyNumber) == false)
                    goto InputCopyNumber;
                newspaper.CopyNumber = copyNumber;
            InputPublishDate:
                Console.WriteLine("Input publish date:");
                if (Int32.TryParse(Console.ReadLine(), out int publishDate) == false)
                    goto InputPublishDate;
                newspaper.PublishDate = publishDate;

                _documents.Add(newspaper);
                Console.WriteLine("Added document: " + newspaper.ToString());
                Console.ReadLine();
            }
        }
        public static void DisplayAllDocuments()
        {
            foreach (var document in _documents)
                Console.WriteLine(document.ToString());
            Console.ReadLine();
        }
        public static void DeleteDocumentByID()
        {
        InputDocumentID:
            Console.WriteLine("Input document ID:");
            bool isNum = Int32.TryParse(Console.ReadLine(), out int documentID);
            if (isNum == false)
                goto InputDocumentID;

            Document? documentResult = _documents.FirstOrDefault(document => document.DocumentID == documentID);

            if (documentResult == null)
            {
                Console.WriteLine("Document ID not found");
                Console.ReadLine();
                return;
            }

            _documents.Remove(documentResult);
            Console.WriteLine("Document deleted: " + documentResult.ToString());
            Console.ReadLine();
        }
        public static void FindDocumentsByType(string type)
        {
            if (type == "1")
            {
                IEnumerable<Document> books = _documents.Where(document => document is Book);
                Console.WriteLine("List of books:");
                FindDocumentsByTypeHelper(books);
                Console.ReadLine();
            }
            else if (type == "2")
            {
                IEnumerable<Document> magazine = _documents.Where(document => document is Magazine);
                Console.WriteLine("List of books:");
                FindDocumentsByTypeHelper(books);
                Console.ReadLine();
            }
            else if (type == "3")
            {
                IEnumerable < Document >  = _documents.Where(document => document is Newspaper);
            }


        }
        private static void FindDocumentsByTypeHelper(IEnumerable<Document> documents)
        {
            if (documents == null)
            {
                Console.WriteLine("Program failed");
                return;
            }

            foreach (var document in documents)
                Console.WriteLine(document.ToString());
        }
    }
}
