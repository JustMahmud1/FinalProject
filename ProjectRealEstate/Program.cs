using Business.Services.Abstract;
using Business.Services.Concrete;
using Core.DataAccess.Abstract;
using DataAccess;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Entities.Concrete;
using Entities.DTOs.SettingDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ProjectRealEstate
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			builder.Services.AddDbContext<AppDbContext>(opt =>
			{
				opt.UseSqlServer(builder.Configuration["ConnectionStrings:Default"]);
			});

            builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            builder.Services.Configure<IdentityOptions>(opt =>
            {
                opt.Password.RequireDigit = true;
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequiredLength = 8;

            });

			builder.Services.AddAutoMapper(Assembly.Load("Business"));


			//builder.Services.AddAutoMapper(config =>
			//{
			//	config.CreateMap<SettingGetDto, Setting>();
			//}, AppDomain.CurrentDomain.GetAssemblies());

			builder.Services.AddScoped<IPropertyService, PropertyService>();
			builder.Services.AddScoped<ISettingService, SettingService>();
			builder.Services.AddScoped<IAmenityService, AmenityService>();
			builder.Services.AddScoped<IAboutService, AboutService>();
			builder.Services.AddScoped(typeof(IPropertyRepository), typeof(EFPropertyRepository));
			builder.Services.AddScoped(typeof(ISettingRepository), typeof(EFSettingRepository));
			builder.Services.AddScoped(typeof(IAmenityRepository), typeof(EFAmenityRepository));
			builder.Services.AddScoped(typeof(IAboutRepository), typeof(EFAboutRepository));

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                );
				endpoints.MapDefaultControllerRoute();
            });

			app.Run();
		}
	}
}