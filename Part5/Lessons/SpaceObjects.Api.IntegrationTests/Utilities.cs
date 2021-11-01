using SpaceObjects.Api.DataAccessLayer;
using SpaceObjects.Api.Initializers;

namespace SpaceObjects.Api.IntegrationTests
{
    class Utilities
    {
        public static void InitializeDbTest(ApplicationSpaceObjectContext context)
        {
            var modelInitializer = new SpaceObjectContextInitializer();
            modelInitializer.initializeContextAsync(context).GetAwaiter().GetResult();
            context.Database.EnsureCreated();
            context.SaveChanges();
        }

        public static void ReinitializeDbTest(ApplicationSpaceObjectContext context)
        {
            context.SpaceObjects.RemoveRange(context.SpaceObjects);
            context.SaveChanges();
        }
    }
}
