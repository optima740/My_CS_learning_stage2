using FluentValidation;
using SpaceObjects.Api.DTO;

namespace SpaceObjects.Api.Validators
{
    public class BlackHoleDtoValidator : AbstractValidator<BlackHoleDto>
    {
        public BlackHoleDtoValidator()
        {
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
