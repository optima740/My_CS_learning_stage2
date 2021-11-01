using Microsoft.EntityFrameworkCore;
using SpaceObjects.Api.DataAccessLayer;

namespace SpaceObjects.Api.IntegrationTests
{
    public class TestingDataBase
    {
        public ApplicationSpaceObjectContext Context { get; }

        public TestingDataBase()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationSpaceObjectContext>();
            var options = optionsBuilder.UseSqlite(@"Data Source=SpaceTest1.db").Options;
            Context = new ApplicationSpaceObjectContext(options);
        }
    }
}
