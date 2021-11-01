using FluentValidation;
using SpaceObjects.Api.Models;

namespace SpaceObjects.Api.Validators
{
    public class StarValidator : AbstractValidator<Star>
    {
        public StarValidator()
        {
            RuleFor(star => star.Id)
                .NotEmpty().GreaterThan(0).LessThan(int.MaxValue);
            RuleFor(star => star.Name)
                .NotEmpty();
            RuleFor(star => star.DistToSun).GreaterThan(0)
               .NotEmpty();
            RuleFor(star => star.Diametr).GreaterThan(0)
               .NotEmpty();
            RuleFor(star => star.DegOfIllumination).GreaterThan(0)
               .NotEmpty();             
            RuleFor(star => star.Weight).GreaterThan(0)
               .NotEmpty();
        }
    }
}
