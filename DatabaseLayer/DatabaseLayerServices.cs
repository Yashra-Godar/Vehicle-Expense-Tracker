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
            services.AddDbContext<ApplicationDBContext>(o => o.UseSqlServer("Data Source=yashra.cni28g2s273v.ap-south-1.rds.amazonaws.com,1433;Initial Catalog=AmritCraneDB;Persist Security Info=True;User ID=admin;Password=AmritCrane_2026;Trust Server Certificate=True"));
            return services;
        }
    }
}
