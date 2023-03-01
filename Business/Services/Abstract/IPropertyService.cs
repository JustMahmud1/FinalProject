using Entities.Concrete;
using Entities.DTOs.PropertyDTOs;
using System.Linq.Expressions;

namespace Business.Services.Abstract
{
    public interface IPropertyService
    {
        //Task<List<PropertyGetDto>> GetAllAsync(Expression<Func<Property,bool>> expression=null, params string[] includes );
        Task<List<PropertyGetDto>> GetAllAsync();
        Task<List<PropertyGetDto>> GetAllPaginated(int number , int size);
        Task<PropertyGetDto> GetByIdAsync(int Id);
        Task<PropertyGetDto> GetByNameAsync(string name);
        Task<List<PropertyGetDto>> GetByStatus(string status);
        Task<List<PropertyGetDto>> GetAllAsync(Expression<Func<Property, bool>> expression = null);
        Task Approve(int Id);
        Task Reject(int Id);
        Task CreateAsync(PropertyPostDto propertyPostDto);
        Task UpdateAsync(PropertyUpdateDto propertyUpdateDto);
        Task DeleteByIdAsync(int Id);
        Task<List<PropertyGetDto>> GetByUser(string name);
        Task<bool> UpdatePropetyIsFeatured(int propertyId, bool isFeatured);
		



	}
}
