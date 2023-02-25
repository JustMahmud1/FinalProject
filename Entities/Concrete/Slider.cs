using Entities.Abstract;

namespace Entities.Concrete
{
    public class Slider:IEntity
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
    }
}
