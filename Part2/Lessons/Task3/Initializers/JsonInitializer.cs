using Space.Models;
using System.Collections.Generic;
using Space.FileConnections;
using Space.Initializers;

namespace Space.Initializers
{ 
    static class JsonInitializer
    {
        public static void DoInitFile()
        {

            var list = new List<SpaceObject>
            {
                SpaceObjectInitializer.Initialize(new Star()),
                SpaceObjectInitializer.Initialize(new Asteroid()),
                SpaceObjectInitializer.Initialize(new Planet()),
                SpaceObjectInitializer.Initialize(new BlackHole()),
            };
          
            JsonSaver.SaveToFile(list);
        }
    }
}
