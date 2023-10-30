
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SiparisYonetim.Application;
using SiparisYonetim.Domain.Entities.Concrete;
using SiparisYonetim.Infrastructure.DataAccess;

namespace SiparisYonetim.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<SiparisYonetimDBContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));
            builder.Services.AddControllers();


            builder.Services.AddApplicationServices();





            builder.Services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "qwertyuopasdfghjklizxcvbnm1234567890!@#$%&*()_-+=<>?QWERTYUOPASDFGHJKLIZXCVBNM";

                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                options.Lockout.MaxFailedAccessAttempts = 3;

            }).AddDefaultTokenProviders()
  .AddEntityFrameworkStores<SiparisYonetimDBContext>();




            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}