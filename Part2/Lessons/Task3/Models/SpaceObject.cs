using System.Runtime.Serialization;

namespace Space.Models
{
    [KnownType(typeof(Star))]
    [KnownType(typeof(Planet))]
    [KnownType(typeof(Asteroid))]
    [KnownType(typeof(BlackHole))]
    [DataContract]
    abstract class SpaceObject
    {
        [DataMember]
        public string TypeObj { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public float DistToSun { get; set; }
        [DataMember]
        public float Weight { get; set; }
        [DataMember]
        public float Diametr { get; set; }
    }
}
