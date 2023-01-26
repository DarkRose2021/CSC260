using Movies.Models;
using System.ComponentModel.DataAnnotations;

namespace Movies.Validators
{
    //Custom Validator
    //must have "Attribute" at the end
    public class NinetysMoviesRatingAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            if (movie.year >= 1990 && movie.year < 2000 && movie.rating < 2.5f)
            {
                return new ValidationResult("Movies cannot be rated below 2.5 in the 1990s");
            }
            //return base.IsValid(value, validationContext);
            return ValidationResult.Success;
        }
    }
}
