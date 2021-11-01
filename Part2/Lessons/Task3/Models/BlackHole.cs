using System.Runtime.Serialization;

namespace Space.Models
{
    [DataContract]
    class BlackHole : SpaceObject
    {
        [DataMember]
        public float Density { get; set; }
    }
}
