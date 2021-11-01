using FluentValidation;
using SpaceObjects.Api.Models;

namespace SpaceObjects.Api.Validators
{
    public class BlackHoleValidator : AbstractValidator<BlackHole>
    {
        public BlackHoleValidator()
        {
            RuleFor(blackHole => blackHole.Id)
                .NotEmpty().GreaterThan(0).LessThan(int.MaxValue);
            RuleFor(blackHole => blackHole.Name)
                .NotEmpty();
            RuleFor(blackHole => blackHole.DistToSun).GreaterThan(0)
               .NotEmpty();
            RuleFor(blackHole => blackHole.Diametr).GreaterThan(0)
               .NotEmpty();
            RuleFor(blackHole => blackHole.Density).GreaterThan(0)
               .NotEmpty();             
            RuleFor(blackHole => blackHole.Weight).GreaterThan(0)
               .NotEmpty();
        }
    }
}
