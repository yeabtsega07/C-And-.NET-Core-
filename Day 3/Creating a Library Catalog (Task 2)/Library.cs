using System;
using System.Collections.Generic;
using LibraryCatalog.Items;

namespace LibraryCatalog
{
    public class Library 
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Book> Books { get; set; }
        public List<MediaItem> MediaItems { get; set; }

        public Library(string name, string address)
        {
            Name = name;
            Address = address;
            Books = new List<Book>();
            MediaItems = new List<MediaItem>();
        }
        

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void AddMediaItem(MediaItem mediaItem)
        {
            MediaItems.Add(mediaItem);
        }

        public void RemoveBook(Book book)
        {
            Books.Remove(book);
        }

        public void RemoveMediaItem(MediaItem mediaItem)
        {
            MediaItems.Remove(mediaItem);
        }

        public void PrintCatalog()
        {
            Console.WriteLine($"Library: {Name}");
            Console.WriteLine($"Address: {Address}");
            Console.WriteLine("Books:");
            foreach (Book book in Books)
            {
                Console.WriteLine($"-> {book.Title} by {book.Author} ({book.PublicationYear})");
            }

            Console.WriteLine("Media Items:");
            foreach (MediaItem mediaItem in MediaItems)
            {
                Console.WriteLine($"-> {mediaItem.Title} ({mediaItem.MediaType}, {mediaItem.Duration} minutes)");
            }
        
        }

    }
}
