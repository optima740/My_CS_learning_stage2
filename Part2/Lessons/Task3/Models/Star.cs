using System.Runtime.Serialization;

namespace Space.Models
{
    [DataContract]
    class Star : SpaceObject
    {
        [DataMember]
        public float DegOfIllumination { get; set; }        
    }
}
