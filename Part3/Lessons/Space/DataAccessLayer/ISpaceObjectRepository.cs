using Space.Models;
using System;
using System.Collections.Generic;

namespace Space.DataAccessLayer
{
    public interface ISpaceObjectRepository
    {
        IEnumerable<T> GetAllByType<T>() where T : SpaceObject;

        SpaceObject Get(string name);

        bool IsContains(string name);
       
        void Insert(SpaceObject spaceObj);

        void Delete(Guid objectId);

        void Save();
    }
}