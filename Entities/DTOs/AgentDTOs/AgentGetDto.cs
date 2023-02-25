using Entities.Concrete;

namespace Entities.DTOs.AgentDTOs
{
    public class AgentGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Property> Properties { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string InstagramUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
