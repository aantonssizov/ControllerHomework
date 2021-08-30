using System.Collections.Generic;

namespace ControllerHomework.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float? Rating { get; set; }
        public float Price { get; set; }
        public int Pages { get; set; }
        public int? GenreId { get; set; }
        public Genre Genre { get; set; }

        public List<Author> Authors { get; set; } = new List<Author>();
    }
}
