namespace ControllerHomework.Models
{
    public class AuthorDetails
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }

    public enum Sex
    {
        Male,
        Female,
        Unknown
    }
}
