using Entities.Concrete;
using Entities.DTOs.AppUserDTOs;
using Entities.DTOs.PropertyAmenityDTOs;

namespace Entities.DTOs.PropertyDTOs
{
    public class PropertyGetDto
    {
        public PropertyGetDto()
        {
            propertyAmenities=new List<PropertyAmenityGetDto>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string PropertyType { get; set; }
        public double Price { get; set; }
        public bool IsRentOrSale { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public double Area { get; set; }
        public int Rooms { get; set; }
        public bool HasGarage { get; set; }
        public List<PropertyImage> Images { get; set; }
        public PropertyTypeEnum PropertType { get; set; }
        public string UserId { get; set; }
        public AppUserGetDto User { get; set; }
        public bool IsDeleted { get; set; }
        public List<PropertyAmenityGetDto> propertyAmenities { get; set; }
    }
}
