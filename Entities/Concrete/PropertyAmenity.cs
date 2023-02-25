using Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class PropertyAmenity:IEntity
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        [ForeignKey(nameof(Amenity))]
        public int AmenityId { get; set; }
        public Amenity Amenity { get; set; }
    }
}
