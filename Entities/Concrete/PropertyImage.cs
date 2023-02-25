namespace Entities.Concrete
{
    public class PropertyImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
