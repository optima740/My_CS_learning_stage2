using SpaceObjects.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceObjects.Api.DataAccessLayer
{
    public interface ISpaceObjectRepository
    {
        IAsyncEnumerable<T> GetAllByTypeAsync<T>() where T : SpaceObject;

        Task<SpaceObject> GetAsync(int id);
       
        Task InsertAsync(SpaceObject spaceObj);

        Task DeleteAsync(int id);

        Task<bool> UpdateAsync(SpaceObject spaceObj);

        Task SaveAsync();
    }
}