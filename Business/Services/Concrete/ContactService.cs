using AutoMapper;
using Business.Services.Abstract;
using DataAccess.Repositories.Abstract;
using Entities.Concrete;
using Entities.DTOs.ContactDTOs;

namespace Business.Services.Concrete
{
	public class ContactService : IContactService
	{
		private readonly IContactRepository _repository;
		private readonly IMapper _mapper;

		public ContactService(IContactRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}


		public async Task<List<ContactGetDto>> GetAll()
		{
			return _mapper.Map<List<ContactGetDto>>(await _repository.GetAllAsync());
		}

		public async Task Send(ContactPostDto contactPostDto)
		{
			Contact contact = _mapper.Map<Contact>(contactPostDto);
			await _repository.CreateAsync(contact);
		}
		public async Task Read(int Id)
		{
			Contact contact = await _repository.GetAsync(c => c.Id == Id);
			_repository.DeleteAsync(contact);
		}
	}
}
