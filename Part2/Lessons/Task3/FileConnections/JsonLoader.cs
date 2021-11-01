using Space.Models;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using Space.Initializers;

namespace Space.FileConnections
{
    class JsonLoader
    {
        private static string _filePath = "Data.json";
        public static List<SpaceObject> LoadFromFile()
        {
            var json = new DataContractJsonSerializer(typeof(List<SpaceObject>));
            List<SpaceObject> restoredList = new List<SpaceObject>();

            if (!File.Exists(_filePath))
            {
                JsonInitializer.DoInitFile();
            }

            using (FileStream fs = new FileStream(_filePath, FileMode.OpenOrCreate))
            {
                try
                {
                    restoredList = json.ReadObject(fs) as List<SpaceObject>;
                }
                catch
                {
                    return restoredList;
                }
            }
            
            return restoredList;
        }
    }
}
