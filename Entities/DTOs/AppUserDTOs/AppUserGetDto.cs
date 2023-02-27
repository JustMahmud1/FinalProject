using Entities.DTOs.PropertyDTOs;

namespace Entities.DTOs.AppUserDTOs
{
    public class AppUserGetDto
    {
        public List<PropertyGetDto> Properties { get; set; }
        public bool IsAgent { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public string InstagramUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
    }
}
