using Space.DataAccessLayer;
using Space.Initializers;
using System.IO;
using System.Threading.Tasks;

namespace Space.FileConnections
{
    class DataBaseCreator
    {
        protected SpaceObjectContext _context;
        protected string _path;
        public DataBaseCreator(SpaceObjectContext context, string path)
        {
            _context = context;
            _path = path;
        }

        public async Task CreateDbAsync()
        {
            if (!File.Exists(_path))
            {
                await _context.Database.EnsureCreatedAsync();
                var initializer = new SpaceObjectContextInitializer();
                await initializer.initializeContextAsync(_context);              
            }
        }
    }
}
