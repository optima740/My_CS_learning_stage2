using FluentValidation;
using SpaceObjects.Api.DTO;

namespace SpaceObjects.Api.Validators
{
    public class AsteroidDtoValidator : AbstractValidator<AsteroidDto>
    {
        public AsteroidDtoValidator()
        {               
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
