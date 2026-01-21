using DatabaseLayer.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer
{
    public class ApplicationFactory : IDesignTimeDbContextFactory<ApplicationDBContext>
    {
        public ApplicationDBContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>().UseSqlServer("Data Source=.;Initial Catalog=FinalProject_master;Integrated Security=True;Trust Server Certificate=True").Options;
            return new ApplicationDBContext(options);
        }
    }
}
