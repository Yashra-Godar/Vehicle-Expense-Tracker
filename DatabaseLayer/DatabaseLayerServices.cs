using DatabaseLayer.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer
{
    public static class DatabaseLayerServices
    {
        public static IServiceCollection AddDBService(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDBContext>(o => o.UseSqlServer("Data Source=.;Initial Catalog=FinalProject_master;Integrated Security=True;Trust Server Certificate=True"));
            return services;
        }
    }
}
