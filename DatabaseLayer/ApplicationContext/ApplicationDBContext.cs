using BusinessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.ApplicationContext
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options)
        {
            
        }
        public DbSet<Vehicle_Type> tbl_Vehicles { get; set; }

        public DbSet<Crane_Vehicle> tbl_CraneVehicle {  get; set; }

        public DbSet<Service_Master> tbl_ServiceMaster {  get; set; }

       public DbSet<Vehicle_Loan> tbl_VehicleLoan {  get; set; }

        public DbSet<Loan_Installment> tbl_LoanInstallment { get; set; }

        public DbSet<Service_Parts> tbl_ServiceParts { get; set; }

        public DbSet<CraneOilChangeLog>craneOilChangeLogs { get; set; }
    }
}
