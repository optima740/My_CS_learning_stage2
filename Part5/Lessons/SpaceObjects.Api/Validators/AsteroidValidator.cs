using FluentValidation;
using SpaceObjects.Api.Models;

namespace SpaceObjects.Api.Validators
{
    public class AsteroidValidator : AbstractValidator<Asteroid>
    {
        public AsteroidValidator()
        {
            RuleFor(asteroid => asteroid.Id)
                .NotEmpty().GreaterThan(0).LessThan(int.MaxValue);
            RuleFor(asteroid => asteroid.Name)
                .NotEmpty();
            RuleFor(asteroid => asteroid.DistToSun).GreaterThan(0)
               .NotEmpty();
            RuleFor(asteroid => asteroid.Diametr).GreaterThan(0)
               .NotEmpty();
            RuleFor(asteroid => asteroid.Speed).GreaterThan(0)
               .NotEmpty();
            RuleFor(asteroid => asteroid.Weight).GreaterThan(0)
               .NotEmpty();
        }
    }
}
