using Microsoft.EntityFrameworkCore;
using Space.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Space.DataAccessLayer
{
    public class SpaceObjectRepository : ISpaceObjectRepository, IDisposable
    {
        private SpaceObjectContext _context;
        private bool _disposed = false;
        
        public SpaceObjectRepository(SpaceObjectContext context)
        {
            _context = context;
        }

        public IAsyncEnumerable<T> GetAllByTypeAsync<T>() where T : SpaceObject
        {
            return _context.Set<T>().AsAsyncEnumerable();
        }

        public Task<SpaceObject> GetAsync(string name)
        {           
            return _context.Set<SpaceObject>().Where(item => item.Name == name)
            .FirstOrDefaultAsync();
        }

        public Task InsertAsync(SpaceObject spaceObj)
        {
            return _context.Set<SpaceObject>().AddAsync(spaceObj).AsTask();
        }

        public async Task DeleteAsync(Guid objectId)
        {
            var spaceObj = await _context.Set<SpaceObject>().FindAsync(objectId);
            _context.SpaceObjects.Remove(spaceObj);
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
       
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
