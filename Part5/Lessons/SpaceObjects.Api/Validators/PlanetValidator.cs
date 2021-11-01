using FluentValidation;
using SpaceObjects.Api.Models;

namespace SpaceObjects.Api.Validators
{
    public class PlanetValidator : AbstractValidator<Planet>
    {
        public PlanetValidator()
        {
            RuleFor(planet => planet.Id)
                .NotEmpty().GreaterThan(0).LessThan(int.MaxValue);
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
