using Entities.DTOs.PropertyDTOs;
using FluentValidation;

namespace Business.Utilities.Validations.Property
{
	public class PropertyPostDtoValidation:AbstractValidator<PropertyPostDto>
	{
		public PropertyPostDtoValidation()
		{
			RuleFor(p=>p.Title)
				.NotEmpty().WithMessage("Boş ola bilməz")
				.NotNull().WithMessage("Boş ola bilməz")
				.MinimumLength(2).WithMessage("Başlıq ən azı 2 hərf olmalıdır")
				.MaximumLength(50).WithMessage("Başlıq ən çox 50 hərf ola bilər");
			RuleFor(p=>p.Description).NotEmpty()
				.WithMessage("Boş ola bilməz")
				.NotNull().WithMessage("Boş ola bilməz")
				.MinimumLength(10).WithMessage("Minimum 10 hərf olmalıdır")
				.MaximumLength(255).WithMessage("Maksimum 255 hərfdən istifadə oluna bilər");
			RuleFor(p => p.Price)
				.NotEmpty().WithMessage("Boş ola bilməz")
				.NotNull().WithMessage("Boş ola bilməz")
				.LessThan(100000000);
			RuleFor(p => p.Area)
				.NotEmpty().WithMessage("Boş ola bilməz")
				.NotNull().WithMessage("Boş ola bilməz")
				.GreaterThan(10).WithMessage("Evin ərazisi minimum 10 kvadrat metr olmalıdır")
				.LessThan(10000).WithMessage("Evin ərazisi 10000 kvadrat metrdən çox ola bilməz");
			RuleFor(p=>p.Location)
				.NotEmpty().WithMessage("Boş ola bilməz")
				.NotNull().WithMessage("Boş ola bilməz")
				.MinimumLength(10).WithMessage("Adres minimum 10 hərfdən ibarət olmalıdır")
				.MaximumLength(50).WithMessage("Adres 50 hərfdən böyük olmamalıdır");
			RuleFor(p=>p.Rooms)
				.NotEmpty().WithMessage("Boş ola bilməz")
				.NotNull().WithMessage("Boş ola bilməz")
				.GreaterThan(1).WithMessage("Ən az otaq sayı 1 olmalıdır")
				.LessThan(30).WithMessage("Otaq sayınız 30'dan çoxdursa 30 qeyd edib Açıqlama bölməsində gerçək sayını qeyd edə bilərsiniz");
			RuleFor(p => p.FormFiles)
				.NotEmpty().WithMessage("Boş ola bilməz")
				.NotNull().WithMessage("Boş ola bilməz")
				.Must(f=>f.Count>=2 && f.Count<=10).WithMessage("Ən az 2, ən çox 10 şəkil daxil edə bilərsiniz").When(f=>f.FormFiles!=null);
			RuleFor(p => p.AmenitiesIds)
				.Must(f=>f.Count>=1 && f.Count<=20).WithMessage("Evinizə aid ən az 1 özəlliyi seçin").When(f=>f.propertyAmenities!=null);
		}
	}
}
