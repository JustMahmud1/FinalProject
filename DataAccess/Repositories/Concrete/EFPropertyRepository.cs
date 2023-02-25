using Core.DataAccess.Concrete;
using DataAccess.Repositories.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Concrete
{
    public class EFPropertyRepository : EntityRepositoryBase<Property, AppDbContext>, IPropertyRepository
    {
        public EFPropertyRepository(AppDbContext context) : base(context)
        {
        }
    }
}
