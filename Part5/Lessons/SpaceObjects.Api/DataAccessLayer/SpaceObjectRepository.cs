using SpaceObjects.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceObjects.Api.DataAccessLayer
{
    public class SpaceObjectRepository : ISpaceObjectRepository, IDisposable
    {
        private ApplicationSpaceObjectContext _context;
        private bool _disposed = false;
        
        public SpaceObjectRepository(ApplicationSpaceObjectContext context)
        {
            _context = context;
        }

        public IAsyncEnumerable<T> GetAllByTypeAsync<T>() where T : SpaceObject
        {
            return _context.Set<T>().AsAsyncEnumerable();
        }

        public Task<SpaceObject> GetAsync(int id)
        {
            return _context.Set<SpaceObject>().FindAsync(id).AsTask();
        }

        public Task InsertAsync(SpaceObject spaceObj)
        {
            return _context.Set<SpaceObject>().AddAsync(spaceObj).AsTask();
        }

        public async Task DeleteAsync(int id)
        {
            var spaceObj = await _context.Set<SpaceObject>().FindAsync(id);
            _context.SpaceObjects.Remove(spaceObj);
        }

        public async Task<bool> UpdateAsync(SpaceObject spaceObj)
        {
            var spaceObject = await _context.Set<SpaceObject>().FindAsync(spaceObj.Id);

            if (spaceObject == null)
            {
                return false;
            }

            _context.Entry(spaceObject).CurrentValues.SetValues(spaceObj);           
            
            return true;
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
