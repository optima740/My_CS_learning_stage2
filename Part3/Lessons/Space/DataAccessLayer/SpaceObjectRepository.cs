using Space.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<T> GetAllByType<T>() where T : SpaceObject
        {
            return _context.Set<T>();
        }

        public SpaceObject Get(string name)
        {                     
            return _context.Set<SpaceObject>()
            .Where(item => item.Name == name)
            .FirstOrDefault();                 
        }

        public bool IsContains(string name)
        {
            return _context.Set<SpaceObject>().Where(item => item.Name == name).Any();          
        }

        public void Insert(SpaceObject spaceObj)
        {
            _context.SpaceObjects.Add(spaceObj);
        }

        public void Delete(Guid objectId)
        {
            var spaceObj = _context.Set<SpaceObject>().Find(objectId);
            _context.SpaceObjects.Remove(spaceObj);
        }

        public void Save()
        {
            _context.SaveChanges();
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
