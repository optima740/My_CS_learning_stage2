using Space.DataAccessLayer;
using Space.Initializers;
using System.IO;

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

        public void CreateDb()
        {
            if (!File.Exists(_path))
            {
                _context.Database.EnsureCreated();
                var initializer = new SpaceObjectContextInitializer();
                initializer.initializeContext(_context);              
            }
        }
    }
}
