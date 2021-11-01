using SpaceObjects.Api.DataAccessLayer;
using SpaceObjects.Api.Models;
using System.Threading.Tasks;

namespace SpaceObjects.Api.Initializers
{
    public class SpaceObjectContextInitializer
    {
        public async Task initializeContextAsync(ApplicationSpaceObjectContext context)
        {           
            await context.Stars.AddAsync(SpaceObjectInitializer.Initialize(new Star()));
            await context.Asteroids.AddAsync(SpaceObjectInitializer.Initialize(new Asteroid()));
            await context.Planets.AddAsync(SpaceObjectInitializer.Initialize(new Planet()));
            await context.BlackHoles.AddAsync(SpaceObjectInitializer.Initialize(new BlackHole()));           
        }
    }
}
