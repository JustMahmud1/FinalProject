using Core.DataAccess.Concrete;
using DataAccess.Repositories.Abstract;
using Entities.Concrete;

namespace DataAccess.Repositories.Concrete
{
	public class EFAboutRepository:EntityRepositoryBase<About,AppDbContext>,IAboutRepository
	{
		public EFAboutRepository(AppDbContext context):base(context) { }
	}
}
