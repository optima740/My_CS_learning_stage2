using FluentValidation;
using SpaceObjects.Api.DTO;

namespace SpaceObjects.Api.Validators
{
    public class PlanetDtoValidator : AbstractValidator<PlanetDto>
    {
        public PlanetDtoValidator()
        {
            RuleFor(planet => planet.Name)
                .NotEmpty();
            RuleFor(planet => planet.DistToSun).GreaterThan(0)
               .NotEmpty();
            RuleFor(planet => planet.Diametr).GreaterThan(0)
               .NotEmpty();
            RuleFor(planet => planet.TiltAngle).GreaterThan(0)
               .NotEmpty();             
            RuleFor(planet => planet.Weight).GreaterThan(0)
               .NotEmpty();
        }
    }
}
