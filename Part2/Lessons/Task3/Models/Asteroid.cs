using System.Runtime.Serialization;

namespace Space.Models
{
    [DataContract]
    class Asteroid: SpaceObject
    {

        [DataMember]
        public float Speed { get; set; }
    }
}
