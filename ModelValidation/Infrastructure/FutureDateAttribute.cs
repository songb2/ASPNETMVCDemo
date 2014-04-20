using System;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Infrastructure
{
    /// <summary>
    /// Derive from the built-in validation attributes
    /// </summary>
    public class FutureDateAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            return base.IsValid(value) && (DateTime)value > DateTime.Now;
        }
    }
}