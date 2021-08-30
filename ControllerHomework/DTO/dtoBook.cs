using ControllerHomework.Models;
using ControllerHomework.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControllerHomework.DTO
{
    [BookValidation(48, ErrorMessage = "Book name should be less than 48 characters")]
    public class dtoBook : IValidatableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [IsFloatInRangeValidation(0, 10)]
        public float? Rating { get; set; }
        public float Price { get; set; }
        public int Pages { get; set; }
        public int? GenereId { get; set; }

        public void Map(Book entity)
        {
            entity.Id = Id;
            entity.Name = Name;
            entity.Rating = Rating;
            entity.Price = Price;
            entity.Pages = Pages;
            entity.GenreId = GenereId;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            if (Price < 0)
            {
                result.Add(new ValidationResult($"Value {Price} can't be less than 0", new[] { "Price" }));
            }

            return result;
        }
    }
}
