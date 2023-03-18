using Core.DataAccess.Concrete;
using DataAccess.Repositories.Abstract;
using Entities.Concrete;

namespace DataAccess.Repositories.Concrete
{
	public class EFContactRepository:EntityRepositoryBase<Contact, AppDbContext>,IContactRepository
	{
		public EFContactRepository(AppDbContext context) : base(context) { }
	}
}
