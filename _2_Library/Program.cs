using System.Security.Cryptography.X509Certificates;

namespace _2_Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string state = "0";

            while (state != "-1")
            {
                switch (state)
                {
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Document Management System");
                        Console.WriteLine("Choose one option:");
                        Console.WriteLine("1. Add a new document");
                        Console.WriteLine("2. Delete a document by ID");
                        Console.WriteLine("3. Display info of a document");
                        Console.WriteLine("4. Find documents by type");

                        string inputMain = Console.ReadLine();
                        if (inputMain != "1" && inputMain != "2" && inputMain != "3" && inputMain != "4")
                            goto case "0";

                        state = inputMain;

                        break;
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Choose the type of documnent:");
                        Console.WriteLine("1. Book");
                        Console.WriteLine("2. Magazine");
                        Console.WriteLine("3. Newspaper");

                        string inputOne = Console.ReadLine();
                        if (inputOne != "1" && inputOne != "2" && inputOne != "3")
                            goto case "1";

                        if (inputOne != "1")
                        {
                            Book book = new Book();
                            DocumentManagement.AddNewDocument(book);
                        }
                        else if (inputOne != "2")
                        {
                            Magazine magazine = new Magazine();
                            DocumentManagement.AddNewDocument(magazine);
                        }
                        else if (inputOne != "3")
                        {
                            Newspaper newspaper = new Newspaper();
                            DocumentManagement.AddNewDocument(newspaper);
                        }

                        state = "0";

                        break;
                    case "2":
                        Console.Clear();
                        DocumentManagement.DeleteDocumentByID();

                        state = "0";

                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("List of all documents:");
                        DocumentManagement.DisplayAllDocuments();

                        state = "0";

                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Choose the type of documnent:");
                        Console.WriteLine("1. Book");
                        Console.WriteLine("2. Magazine");
                        Console.WriteLine("3. Newspaper");

                        string inputFour = Console.ReadLine();
                        if (inputFour != "1" && inputFour != "2" && inputFour != "3")
                            goto case "4";



                        break;
                }
            }
        }
    }
}