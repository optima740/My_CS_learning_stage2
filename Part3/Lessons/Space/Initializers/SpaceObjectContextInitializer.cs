using Space.DataAccessLayer;
using Space.Models;

namespace Space.Initializers
{
    public class SpaceObjectContextInitializer
    {
        public void initializeContext(SpaceObjectContext context)
        {           
            context.Stars.Add(SpaceObjectInitializer.Initialize(new Star()));
            context.Asteroids.Add(SpaceObjectInitializer.Initialize(new Asteroid()));
            context.Planets.Add(SpaceObjectInitializer.Initialize(new Planet()));
            context.BlackHoles.Add(SpaceObjectInitializer.Initialize(new BlackHole()));           
            context.SaveChanges();
        }
    }
}
