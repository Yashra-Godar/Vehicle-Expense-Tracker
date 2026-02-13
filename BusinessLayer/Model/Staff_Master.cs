using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Model
{
    public class Staff_Master
    {
        public Staff_Master()
        {
            crane_Vehicles=new HashSet<Crane_Vehicle>();
            service_masters=new HashSet<Service_Master>();
            service_Parts=new HashSet<Service_Parts>();
            vehicle_loans=new HashSet<Vehicle_Loan>();
            Loan_Installments=new HashSet<Loan_Installment>();
            CraneOilChangeLogs=new HashSet<CraneOilChangeLog>();
            fuel_Expenses = new HashSet<Fuel_Expenses>();
            craneOtherExpenses=new HashSet<CraneOtherExpenses>();
            CraneInsurances = new HashSet<Crane_Insurance>();
            insurances = new HashSet<Insurance_Premium>();

        }
        public int Id { get; set; }

        public string FullName { get; set; }=string.Empty;

        public string ContactNo { get; set; }= string.Empty;

        public string? Email { get; set; } 

        public string Password { get; set; }=string.Empty ;

        public bool IsActive { get; set; }

        public DateTime Created_At { get; set; } = DateTime.Now;

        public ICollection<Crane_Vehicle> crane_Vehicles { get; set; }

        public ICollection<Service_Master> service_masters { get; set; }

        public ICollection<Service_Parts> service_Parts { get; set; }

        public ICollection<Vehicle_Loan> vehicle_loans { get; set; }

        public ICollection<Loan_Installment> Loan_Installments { get; set; }

        public ICollection<CraneOilChangeLog> CraneOilChangeLogs { get; set; }

        public ICollection<Fuel_Expenses> fuel_Expenses { get; set; }

        public ICollection<CraneOtherExpenses> craneOtherExpenses { get; set; }

        public ICollection<Crane_Insurance> CraneInsurances { get; set; }

        public ICollection<Insurance_Premium> insurances { get; set; }
    }
}
