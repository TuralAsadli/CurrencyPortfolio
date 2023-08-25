using DAL.Abstraction;
using DAL.DAL;
using DAL.Entities;
using DAL.Repository;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Utilities.Extentions
{
    public static class BlLayerExtention
    {
        public static IServiceCollection AddBlLayerExtention(this IServiceCollection services)
        {
            services.AddMediatR(typeof(BlLayerExtention).Assembly);
            services.AddAutoMapper(typeof(BlLayerExtention).Assembly);

            return services;
        }
    }
}
