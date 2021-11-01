using Space.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Space.DataAccessLayer
{
    public interface ISpaceObjectRepository
    {
        IAsyncEnumerable<T> GetAllByTypeAsync<T>() where T : SpaceObject;

        Task<SpaceObject> GetAsync(string name);
       
        Task InsertAsync(SpaceObject spaceObj);

        Task DeleteAsync(Guid objectId);

        Task SaveAsync();
    }
}