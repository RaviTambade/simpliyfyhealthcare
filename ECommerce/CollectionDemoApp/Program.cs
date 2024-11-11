using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionDemoApp
{

    //content class
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }

    //container class
    public class Library
    {
        private List<Book> books = null;
        private string location;
        public Library(string location)
        {
            books = new List<Book>();
            books.Add(new Book { Id = 1, Title = "Inside C#", Description = "best seller", Author = "Steve Jobs" });
            books.Add(new Book { Id = 2, Title = "Inside Java", Description = "Classic Book", Author = "Yashwant Kantekar" }); ;
            books.Add(new Book { Id = 3, Title = "Inside Python", Description = "best  AI Starter", Author = "Graddy Booch" }); ;
            this.location = location;
        }

        //Property
        public string Location
        {
            get { return this.location; }
            set { this.location = value; }
        }

        //Indexer
        public Book this[int index]
        {
            get {
                return books[index];
            }
            set { 
                books[index] = value;
            }
        } 

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = {"Sachin", "Rahul", "Sourav", "VV Laxman" };
            string player = names[0];
            string player2 = names[3];
            /*Book[] books = { new Book { Id = 1, Title = "Inside C#", Description = "best seller", Author = "Steve Jobs" },
                            new Book {  Id=1, Title="Inside C#", Description="best seller", Author="Steve Jobs"}
            };
            */

            Library pccoeLib = new Library("Akurdi");
           
            Console.WriteLine(pccoeLib.Location);
            Book theBook = pccoeLib[2];
            Console.WriteLine(theBook.Title + " "+ theBook.Description+  " "+theBook.Author );
           
            pccoeLib[2] = new Book { Id = 1, Title = "Sapians", Description = "best  human hitory", Author = "Harrari" };

            theBook = pccoeLib[2];
            Console.WriteLine(theBook.Title + " " + theBook.Description + " " + theBook.Author);

            Console.ReadLine();
  
        }
    }
}
