using FluentValidation;
using SpaceObjects.Api.DTO;

namespace SpaceObjects.Api.Validators
{
    public class StarDtoValidator : AbstractValidator<StarDto>
    {
        public StarDtoValidator()
        {
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
