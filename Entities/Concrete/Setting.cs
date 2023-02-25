using Entities.Abstract;

namespace Entities.Concrete
{
    public class Setting:IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
    }
}
