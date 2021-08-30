using ControllerHomework.DTO;
using ControllerHomework.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerHomework.Validation
{
    public class BookValidator : AbstractValidator<dtoBook>
    {
        public BookValidator()
        {
            RuleFor(b => b.Pages).GreaterThan(0);
        }
    }
}
