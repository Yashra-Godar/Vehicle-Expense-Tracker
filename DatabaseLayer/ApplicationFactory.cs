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
            var options = new DbContextOptionsBuilder<ApplicationDBContext>().UseSqlServer("Data Source=yashra.cni28g2s273v.ap-south-1.rds.amazonaws.com,1433;Initial Catalog=AmritCraneDB;Persist Security Info=True;User ID=admin;Password=AmritCrane_2026;Trust Server Certificate=True").Options;
            return new ApplicationDBContext(options);
        }
    }
}
