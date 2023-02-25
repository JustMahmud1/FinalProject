using Core.DataAccess.Concrete;
using DataAccess.Repositories.Abstract;
using Entities.Concrete;

namespace DataAccess.Repositories.Concrete
{
	public class EFAmenityRepository:EntityRepositoryBase<Amenity,AppDbContext>,IAmenityRepository
	{
		public EFAmenityRepository(AppDbContext context) : base(context) { }
	}
}
