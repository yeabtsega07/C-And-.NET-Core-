using System.Collections.Generic;

namespace LibraryCatalog.Models
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

    }    
}