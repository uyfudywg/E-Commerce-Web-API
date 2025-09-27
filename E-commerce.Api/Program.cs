
using Microsoft.EntityFrameworkCore;
using E_commerce.Infrastructure.dbContext;
using E_commerce.Infrastructure.DataSeed;
using System.Data;
using E_commerce.Domain.Contracts;
using E_commerce.Infrastructure.Repository;
using E_commerce.Api.Profiles;
namespace E_commerce.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        // Register the DbContext with the dependency injection container
        builder.Services.AddDbContext<E_commerceContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



        // Register Generic Repository
        builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        // Register Unit of Work
        builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

        // AutoMapper
        // builder.Services.AddAutoMapper(typeof(MappingProfiles));
        builder.Services.AddAutoMapper(typeof(MappingProfiles));
        var app = builder.Build();

        // Apply pending migrations at startup
        // Create a scope to get the DbContext instance
        using var scope = app.Services.CreateScope();
        // Get the DbContext instance
        // Ensure the database is created and apply migrations
        var dbContext = scope.ServiceProvider.GetRequiredService<E_commerceContext>();

        var looggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
        try
        {
            // Apply any pending migrations
            dbContext.Database.Migrate();
            // Seed initial data if necessary

            DataSeed.AddData(dbContext);



        }
        catch (Exception ex)
        {
            var logger = looggerFactory.CreateLogger<Program>();
            logger.LogError(ex, "An error occurred while migrating the database.");

        }

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
