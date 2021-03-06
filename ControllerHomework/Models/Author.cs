using System.Collections.Generic;

namespace ControllerHomework.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public AuthorDetails AuthorDetails { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
