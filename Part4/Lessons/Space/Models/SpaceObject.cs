using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Space.Models
{
    [KnownType(typeof(Star))]
    [KnownType(typeof(Planet))]
    [KnownType(typeof(Asteroid))]
    [KnownType(typeof(BlackHole))]
 
    public abstract class SpaceObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public string TypeObj { get; set; }
        public string Name { get; set; }
        public float DistToSun { get; set; }
        public float Weight { get; set; }
        public float Diametr { get; set; }
    }
}
