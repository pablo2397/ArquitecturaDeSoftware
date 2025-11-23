using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Concesionario
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IServiceBase<Vehiculo>, ServiceBase<Vehiculo>>();
            builder.Services.AddTransient<IServiceBase<Asesor>, ServiceBase<Asesor>>();
            builder.Services.AddTransient<IServiceBase<TipoVehiculo>, ServiceBase<TipoVehiculo>>();
            builder.Services.AddTransient<IServiceBase<Departamento>, ServiceBase<Departamento>>();
            builder.Services.AddTransient<IServiceBase<Ciudad>, ServiceBase<Ciudad>>();
            builder.Services.AddTransient<IServiceBase<Cliente>, ServiceBase<Cliente>>();
            builder.Services.AddTransient<IServiceBase<Compra>, ServiceBase<Compra>>();
            builder.Services.AddTransient<IServiceUser, ServiceUser>();

            builder.Services.AddTransient<IRepositoryBase<Vehiculo>, RepositoryBase<Vehiculo>>();
            builder.Services.AddTransient<IRepositoryBase<Asesor>, RepositoryBase<Asesor>>();
            builder.Services.AddTransient<IRepositoryBase<TipoVehiculo>, RepositoryBase<TipoVehiculo>>();
            builder.Services.AddTransient<IRepositoryBase<Departamento>, RepositoryBase<Departamento>>();
            builder.Services.AddTransient<IRepositoryBase<Ciudad>, RepositoryBase<Ciudad>>();
            builder.Services.AddTransient<IRepositoryBase<Cliente>, RepositoryBase<Cliente>>();
            builder.Services.AddTransient<IRepositoryBase<Compra>, RepositoryBase<Compra>>();
            builder.Services.AddTransient<IRepositoryUser, RepositoryUser>();
            builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            string conexionString = builder.Configuration.GetConnectionString("ConcesionarioDb")!;
            builder.Services.AddDbContext<ConcesionarioContext>(Db =>
            {
                Db.UseSqlServer(conexionString);
                Db.UseLazyLoadingProxies();
            });

            builder.Services.AddDataProtection();

            var app = builder.Build();
            app.UseCors(b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
