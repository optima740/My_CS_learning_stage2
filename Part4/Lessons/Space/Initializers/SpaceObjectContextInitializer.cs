using Space.DataAccessLayer;
using Space.Models;
using System.Threading.Tasks;

namespace Space.Initializers
{
    public class SpaceObjectContextInitializer
    {
        public async Task initializeContextAsync(SpaceObjectContext context)
        {           
            await context.Stars.AddAsync(SpaceObjectInitializer.Initialize(new Star()));
            await context.Asteroids.AddAsync(SpaceObjectInitializer.Initialize(new Asteroid()));
            await context.Planets.AddAsync(SpaceObjectInitializer.Initialize(new Planet()));
            await context.BlackHoles.AddAsync(SpaceObjectInitializer.Initialize(new BlackHole()));           
            await context.SaveChangesAsync();
        }
    }
}
