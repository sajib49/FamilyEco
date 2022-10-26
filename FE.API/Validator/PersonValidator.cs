using FE.API.Models;
using FluentValidation;

namespace FE.API.Validator
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.GivenName).NotNull().WithMessage("*Required").NotEmpty().WithMessage("*Required");
            RuleFor(x => x.Gender).NotNull().WithMessage("*Required");
        }
    }
}