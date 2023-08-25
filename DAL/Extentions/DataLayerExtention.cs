using DAL.Abstraction;
using DAL.DAL;
using DAL.Entities;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Extentions
{
    public static class DataLayerExtention
    {
        public static IServiceCollection AddDataLayerExtention(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IWalletItemRepository, WalletItemRepository>();
            services.AddScoped<IBaseRepository<Currency>, BaseRepository<Currency>>();
            services.AddScoped<IBaseRepository<Transaction>, BaseRepository<Transaction>>();

            return services;
        }
    }
}
