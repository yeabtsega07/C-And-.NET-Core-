using System;
using System.Collections.Generic;
using LibraryCatalog.Models;

namespace LibraryCatalog.Services
{
    public class LibraryService
    {
        private Library library;

        public LibraryService(Library library)
        {
            this.library = library;
        }

        public void AddBook(Book book)
        {
            library.Books.Add(book);
        }

        public void AddMediaItem(MediaItem mediaItem)
        {
            library.MediaItems.Add(mediaItem);
        }

        public void RemoveBook(Book book)
        {
            library.Books.Remove(book);
        }

        public void RemoveMediaItem(MediaItem mediaItem)
        {
            library.MediaItems.Remove(mediaItem);
        }

        public void PrintCatalog()
        {
            Console.WriteLine($"Library: {library.Name}");
            Console.WriteLine($"Address: {library.Address}");
            Console.WriteLine("Books:");
            foreach (Book book in library.Books)
            {
                Console.WriteLine($"-> {book.Title} by {book.Author} ({book.PublicationYear})");
            }

            Console.WriteLine("Media Items:");
            foreach (MediaItem mediaItem in library.MediaItems)
            {
                Console.WriteLine($"-> {mediaItem.Title} ({mediaItem.MediaType}, {mediaItem.Duration} minutes)");
            }
        
        }

    }
}
