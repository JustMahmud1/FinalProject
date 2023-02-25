using Entities.Concrete;
using Entities.DTOs.PropertyAmenityDTOs;

namespace Entities.DTOs.AmenityDTOs
{
    public class AmenityGetDto
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public bool IsDeleted { get; set; }
        List<PropertyAmenityGetDto> propertyAmenities { get; set; }
    }
}
