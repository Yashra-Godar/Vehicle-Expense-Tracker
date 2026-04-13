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
            services.AddDbContext<ApplicationDBContext>(o => o.UseSqlServer("Data Source=expensetracker.cpow42cgcwyt.eu-north-1.rds.amazonaws.com,1433;Initial Catalog=expensetracker;Persist Security Info=True;User ID=admin;Password=Yashra_7048;Trust Server Certificate=True"));
            return services;
        }
    }
}
