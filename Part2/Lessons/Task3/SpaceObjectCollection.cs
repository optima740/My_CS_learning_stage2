using Space.FileConnections;
using Space.Models;
using System.Collections.Generic;
using System.Linq;

namespace Space
{
    class SpaceObjectCollection
    {        
        private  List<SpaceObject> _spaceObjCollection;

        public SpaceObjectCollection()
        {
            _spaceObjCollection = JsonLoader.LoadFromFile();
        }

        public List<SpaceObject> GetAllObjects()
        {
            return _spaceObjCollection;
        }

        public List<SpaceObject> GetAllObjectsByType<T>()
        {            
            return _spaceObjCollection.Where(item => item is T).ToList();
        }

        public void AddToCollection(SpaceObject spaceObj)
        {
            _spaceObjCollection.Add(spaceObj);           
        }

        public bool IsContains(string name)
        {
            return _spaceObjCollection.Where(item => item.Name == name).Any();             
        }

        public void RemoveFromCollection(string name)
        {
            _spaceObjCollection.RemoveAll(item => item.Name == name);
        }
    }
}
