using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.AboutDTOs;
using Entities.DTOs.AmenityDTOs;
using Entities.DTOs.AppUserDTOs;
using Entities.DTOs.ContactDTOs;
using Entities.DTOs.PropertyAmenityDTOs;
using Entities.DTOs.PropertyDTOs;
using Entities.DTOs.SettingDTOs;
using Entities.DTOs.SliderDTOs;

namespace Business.Utilities.Profiles
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Property, PropertyGetDto>();
            CreateMap<PropertyPostDto, Property>();
            CreateMap<SettingPostDto, Setting>();
            CreateMap<Setting, SettingGetDto>().ReverseMap();
            CreateMap<SettingPostDto, Setting>();
            CreateMap<AmenityPostDto, Amenity>();
            CreateMap<Amenity, AmenityGetDto>();
            CreateMap<AmenityGetDto, Amenity>();
            CreateMap<About, AboutGetDto>();
            CreateMap<AboutPostDto, About>();
            CreateMap<PropertyAmenity, PropertyAmenityGetDto>();
            CreateMap<AppUser, AppUserGetDto>().ReverseMap();
            CreateMap<SliderGetDto, Property>().ReverseMap();
            CreateMap<Contact, ContactGetDto>();
            CreateMap<ContactPostDto, Contact>();
        }
    }
}
