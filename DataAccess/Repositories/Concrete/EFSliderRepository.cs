using Core.DataAccess.Concrete;
using DataAccess.Repositories.Abstract;
using Entities.Concrete;

namespace DataAccess.Repositories.Concrete
{
	public class EFSliderRepository: EntityRepositoryBase<Slider, AppDbContext>, ISliderRepository
	{
		public EFSliderRepository(AppDbContext context):base(context) {}
	}
}
