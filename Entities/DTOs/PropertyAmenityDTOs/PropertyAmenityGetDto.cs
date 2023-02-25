using Entities.Concrete;
using Entities.DTOs.PropertyDTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DTOs.PropertyAmenityDTOs
{
    public class PropertyAmenityGetDto
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public PropertyGetDto Property { get; set; }
        public int AmenityId { get; set; }
        public Amenity Amenity { get; set; }
    }
}
