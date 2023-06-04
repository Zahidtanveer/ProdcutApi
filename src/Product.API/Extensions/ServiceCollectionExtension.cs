using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Product.Application.Services.Product.CommandHandler;
using Product.Application.Services.Product.QueryHandler;
using Product.Domain.Commands.Product;
using Product.Domain.Commands.Product.Validators;
using Product.Domain.Entities;
using Product.Domain.Interfaces;
using Product.Infrastructure;
using Product.Infrastructure.Data;
using Product.Infrastructure.Data.Seeder;
using Product.Infrastructure.Repositories;

namespace Product.API.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // Add Repos
            services.AddScoped<IProductRepository, ProductRepository>();

            // Add Validators
            services.AddScoped<IValidator<SellProductCommand>, SellProductCommandValidator>();
            services.AddScoped<IValidator<UpdateProductStatusCommand>, UpdateProductStatusCommandValidator>();

            // Add Command & Query Handlers
            services.AddScoped<ICommandHandler<SellProductCommand>, SellProductCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateProductStatusCommand>, UpdateProductStatusCommandHandler>();
            services.AddScoped<IProductQuery, GetProductCountStatusWiseQueryHandler>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
