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
            services.AddDbContext<ApplicationDBContext>(o => o.UseSqlServer("Data Source=amritdb.c7824eucwzsc.ap-south-1.rds.amazonaws.com,1433;Initial Catalog=amritdb;Persist Security Info=True;User ID=Adminuser;Password=yasra7048;Trust Server Certificate=True"));
            return services;
        }
    }
}
