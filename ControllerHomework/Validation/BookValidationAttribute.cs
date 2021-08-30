using ControllerHomework.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControllerHomework.Validation
{
    [AttributeUsage(AttributeTargets.Class)]
    public class BookValidationAttribute : ValidationAttribute
    {
        private readonly int _maxNameLength;

        public BookValidationAttribute(int maxNameLength)
        {
            _maxNameLength = maxNameLength;
        }

        public override bool IsValid(object? value)
        {
            var book = (dtoBook)value;

            if (book == null)
            {
                return false;
            }

            return book.Name.Length < 48;
        }
    }
}
