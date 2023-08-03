using System;
using System.Collections.Generic;
using LibraryCatalog.Items;
using LibraryCatalog;

namespace LibraryCatalog.Program
{
    public class Program
    {
        public static void Main()
        {

            Library myLibrary = new Library("My Library", "4 kilo Addis Ababa");


            myLibrary.AddBook(new Book("The Alchemist", "Paulo Coelho", "978-0062315007", 2014));
            myLibrary.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "978-0061120084", 1960));
            myLibrary.AddBook(new Book("Moby-Dick", "Herman Melville", "978-0451524935", 1851));
            myLibrary.AddBook(new Book("The Lord of the Rings", "J.R.R. Tolkien", "978-0544003415", 1954));
            myLibrary.AddBook(new Book("Pride and Prejudice", "Jane Austen", "978-0141439518", 1813));

            myLibrary.AddMediaItem(new MediaItem("Rush Hour", "Movie", 142));
            myLibrary.AddMediaItem(new MediaItem("The Godfather", "Movie", 175));
            myLibrary.AddMediaItem(new MediaItem("Transformers : Age of Extinction", "Movie", 152));
            myLibrary.AddMediaItem(new MediaItem("Spider-Man : Far From Home", "Movie", 202));
            myLibrary.AddMediaItem(new MediaItem("The Lord of the Rings: The Return of the King", "Movie", 201));

            while (true)
            {
                Console.WriteLine($"Welcome to {myLibrary.Name}'s catalog We are located at {myLibrary.Address} come and visit us");
                Console.WriteLine("\nWhat do you want to do? Please select an option:");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. Add Media Item");
                Console.WriteLine("4. Remove Media Item");
                Console.WriteLine("5. View All Items");
                Console.WriteLine("6. Search Items");
                Console.WriteLine("7. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Add a book
                        Console.WriteLine("Enter the book title:");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter the author:");
                        string author = Console.ReadLine();
                        Console.WriteLine("Enter the ISBN:");
                        string isbn = Console.ReadLine();
                        Console.WriteLine("Enter the publication year:");
                        int publicationYear = int.Parse(Console.ReadLine());

                        Book bookToAdd = new Book(title, author, isbn, publicationYear);
                        myLibrary.AddBook(bookToAdd);
                        break;

                    case "2":
                        // Remove a book
                        Console.WriteLine("Enter the ISBN of the book to remove:");
                        isbn = Console.ReadLine();
                        Book bookToRemove = myLibrary.Books.Find(book => book.ISBN == isbn);
                        if (bookToRemove != null)
                        {
                            myLibrary.RemoveBook(bookToRemove);
                            Console.WriteLine("Book removed successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Book not found!");
                        }
                        break;

                    case "3":
                        // Add a media item
                        Console.WriteLine("Enter the media item title:");
                        title = Console.ReadLine();
                        Console.WriteLine("Enter the media type (DVD/CD):");
                        string mediaType = Console.ReadLine();
                        Console.WriteLine("Enter the duration in minutes:");
                        int duration = int.Parse(Console.ReadLine());

                        MediaItem mediaItemToAdd = new MediaItem(title, mediaType, duration);
                        myLibrary.AddMediaItem(mediaItemToAdd);
                        break;

                    case "4":
                        // Remove a media item
                        Console.WriteLine("Enter the title of the media item to remove:");
                        title = Console.ReadLine();
                        MediaItem mediaItemToRemove = myLibrary.MediaItems.Find(item => item.Title == title);
                        if (mediaItemToRemove != null)
                        {
                            myLibrary.RemoveMediaItem(mediaItemToRemove);
                            Console.WriteLine("Media item removed successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Media item not found!");
                        }
                        break;

                    case "5":
                        // View all items
                        Console.WriteLine("Library Catalog:");
                        myLibrary.PrintCatalog();
                        break;

                    case "6":
                        // Search items
                        Console.WriteLine("Enter the search query:");
                        string searchQuery = Console.ReadLine();
                        myLibrary.SearchItems(searchQuery);
                        break;
    

                    case "7":
                        // Exit the program
                        Console.WriteLine("Thanks for visiting! Goodbye.");
                        Environment.Exit(0);
                        break;

                    default:
                        // Invalid choice   
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }
    }
}
