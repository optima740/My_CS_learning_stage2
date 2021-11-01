using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpaceObjects.Api.DataAccessLayer;
using SpaceObjects.Api.Initializers;
using System;
using System.Linq;

namespace Space.Api.Initializers
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationSpaceObjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationSpaceObjectContext>>()))
            {
                
                if (!context.SpaceObjects.Any())
                {
                    var modelInitializer = new SpaceObjectContextInitializer();
                    modelInitializer.initializeContextAsync(context).GetAwaiter().GetResult();
                    context.SaveChangesAsync();
                    context.SaveChanges();
                }

                return;                
            }
        }
    }
}
