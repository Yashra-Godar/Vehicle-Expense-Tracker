using DatabaseLayer.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DatabaseLayer
{
    public class ApplicationFactory : IDesignTimeDbContextFactory<ApplicationDBContext>
    {
        public ApplicationDBContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>().UseSqlServer("Data Source=expensetracker.cpow42cgcwyt.eu-north-1.rds.amazonaws.com,1433;Initial Catalog=expensetracker;Persist Security Info=True;User ID=admin;Password=Yashra_7048;Trust Server Certificate=True").Options;
            return new ApplicationDBContext(options);
        }
    }
}
