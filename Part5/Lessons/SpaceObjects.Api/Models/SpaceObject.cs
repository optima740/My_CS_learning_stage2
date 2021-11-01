using System.ComponentModel.DataAnnotations;

namespace SpaceObjects.Api.Models
{
    public abstract class SpaceObject
    {       
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float DistToSun { get; set; }
        public float Weight { get; set; }
        public float Diametr { get; set; }
    }
}
