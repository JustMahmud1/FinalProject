using Entities.Concrete;
using Entities.DTOs.PropertyDTOs;
using System.Linq.Expressions;

namespace Business.Services.Abstract
{
    public interface IPropertyService
    {
        //Task<List<PropertyGetDto>> GetAllAsync(Expression<Func<Property,bool>> expression=null, params string[] includes );
        Task<List<PropertyGetDto>> GetAllAsync();
        Task<PropertyGetDto> GetByIdAsync(int Id);
        Task<PropertyGetDto> GetByNameAsync(string name);
        Task CreateAsync(PropertyPostDto propertyPostDto);
        Task UpdateAsync(PropertyUpdateDto propertyUpdateDto);
        Task DeleteByIdAsync(int Id);



    }
}
