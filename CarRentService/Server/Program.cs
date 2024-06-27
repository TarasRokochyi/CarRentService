using CarRentService.Server.AutomapperProfile;
using CarRentService.BLL.Services;
using CarRentService.BLL.Services.Contracts;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CarRentService.DAL.Models;
using CarRentService.DAL.Repositories.Contracts;
using CarRentService.DAL.Repositories;
using CarRentService.DAL.UOF;

namespace CarRentService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<CarRentServiceContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            // Repositories
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IFineRepository, FineRepository>();
            builder.Services.AddScoped<IRegularClientRepository, RegularClientRepository>();
            builder.Services.AddScoped<IRentedCarRepository, RentedCarRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Services
            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<IFineService, FineService>();
            builder.Services.AddScoped<IRentedCarService, RentedCarService>();

            // Automapper
            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}
