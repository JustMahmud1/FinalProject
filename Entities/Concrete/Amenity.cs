using Entities.Abstract;

namespace Entities.Concrete
{
    public class Amenity:IEntity
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public bool IsDeleted { get; set; }
        List<PropertyAmenity> propertyAmenities { get; set; }
    }
}
