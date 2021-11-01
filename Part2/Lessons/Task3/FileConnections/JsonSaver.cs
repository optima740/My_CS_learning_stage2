using Space.Models;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Space.FileConnections
{
    static class JsonSaver
    {
        private static string _filePath = "Data.json";

        public static void SaveToFile(List<SpaceObject> list)
        {
            var json = new DataContractJsonSerializer(typeof(List<SpaceObject>));
            
            using (FileStream fs = new FileStream(_filePath, FileMode.Create))
            {
                json.WriteObject(fs, list);
            }
        }
    }
}
