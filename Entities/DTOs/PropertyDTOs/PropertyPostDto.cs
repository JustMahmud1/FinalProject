using Entities.Concrete;
using Entities.DTOs.AppUserDTOs;
using Entities.DTOs.PropertyAmenityDTOs;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.PropertyDTOs
{
    public class PropertyPostDto
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string PropertyType { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; }
        public double Area { get; set; }
        public bool IsRentOrSale { get; set; }
        public int Rooms { get; set; }
        public bool HasGarage { get; set; }
        public List<IFormFile> FormFiles { get; set; }
        public PropertType PropertType { get; set; }
        public string UserId { get; set; }
        public AppUserGetDto User { get; set; }
        public bool IsDeleted { get; set; }
        public List<PropertyAmenityGetDto> propertyAmenities { get; set; }
        public List<int> AmenitiesIds { get; set; }

        public PropertyPostDto()
        {
            AmenitiesIds= new List<int>();
            propertyAmenities = new List<PropertyAmenityGetDto>();
        }
    }
}
