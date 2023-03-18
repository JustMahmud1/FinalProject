using Entities.DTOs.ContactDTOs;
using Entities.DTOs.PropertyDTOs;

namespace Business.Services.Abstract
{
	public interface IContactService
	{
		Task<List<ContactGetDto>> GetAll();
		Task Send(ContactPostDto contactPostDto);
		Task Read(int Id);
	}
}
