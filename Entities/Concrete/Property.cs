using Entities;

using Entities.Abstract;

namespace Entities.Concrete
{
    public class Property:IEntity
    {
        public Property()
        {
            Images= new List<PropertyImage>();
            propertyAmenities = new List<PropertyAmenity>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string PropertyType { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsRentOrSale { get; set; }
        public double Area { get; set; }
        public int Rooms { get; set; }
        public bool HasGarage { get; set; }
        public bool IsFeatured { get; set; }
        public List<PropertyImage> Images { get; set; }
        public string UserId { get; set; }
        public AppUser User {get; set; }
        public bool IsDeleted { get; set; }
        public List<PropertyAmenity> propertyAmenities { get; set; }


    }

    public enum PropertyTypeEnum { 
        Həyət,
        Bina
    }

}
