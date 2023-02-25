using Entities.DTOs.PropertyDTOs;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.AgentDTOs
{
    public class AgentPostDto
    {
        public string Name { get; set; }
        public List<PropertyGetDto> Properties { get; set; }
        public string Description { get; set; }
        public IFormFile FormFile { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string InstagramUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
