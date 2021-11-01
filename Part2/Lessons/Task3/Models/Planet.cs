using System.Runtime.Serialization;

namespace Space.Models
{
    [DataContract]
    class Planet : SpaceObject
    {
        [DataMember]
        public float TiltAngle { get; set; }       
    }
}
