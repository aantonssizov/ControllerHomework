using System;
using System.ComponentModel.DataAnnotations;

namespace ControllerHomework.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IsFloatInRangeValidationAttribute : ValidationAttribute
    {
        private readonly float _min;
        private readonly float _max;

        public IsFloatInRangeValidationAttribute(float min, float max)
            : base(GetErrorMessage(min, max))
        {
            _min = min;
            _max = max;
        }

        public override bool IsValid(object? value)
        {
            if (value != null)
            {
                return (float)value >= _min && (float)value <= _max;
            }

            return true;
        }

        private static Func<string> GetErrorMessage(float min, float max)
        {
            return () => "The {0} field should be between " + min + " and " + max + ".";
        }
    }
}
