using Core.DataAccess.Concrete;
using DataAccess.Repositories.Abstract;
using Entities.Concrete;

namespace DataAccess.Repositories.Concrete
{
	public class EFSettingRepository:EntityRepositoryBase<Setting,AppDbContext>,ISettingRepository
	{
		public EFSettingRepository(AppDbContext context):base(context){}
	}
}
