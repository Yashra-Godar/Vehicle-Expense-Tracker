using BusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace BusinessLayer.Model
{
    public class Crane_Vehicle
    {
        public Crane_Vehicle()
        {
            Loan = new HashSet<Vehicle_Loan>();
            service_Masters=new HashSet<Service_Master>();
            insurance_Premium=new HashSet<Insurance_Premium>();
            craneOilChangeLogs = new HashSet<CraneOilChangeLog>();
            fuel_Expenses=new HashSet<Fuel_Expenses>();
            craneOtherExpenses=new HashSet<CraneOtherExpenses>();
            crane_Insurances=new HashSet<Crane_Insurance>();




        }

        public int Id { get; set; }
        public virtual Vehicle_Type? Vehicle_Type { get; set; }
        public int Vehicle_TypeId { get; set; }

        public virtual Staff_Master? Staff_Master { get; set; }

        public int Staff_MasterId { get; set; }

        public string Vehicle_No { get; set; } = string.Empty;

        public string Vehicle_Name { get; set; } = string.Empty;

        public string Make_by { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public string? Manufacture_Year { get; set; }

        public decimal Capacity_Tons { get; set; }

        public decimal Max_Lifting_Height { get; set; }

        public string? Import_From { get; set; }

        public string? Note { get; set; }

        public DateTime Import_Date { get; set; } = DateTime.Now;

        public string Purchase_Type { get; set; } = string.Empty;
        public DateTime Created_At { get; set; } = DateTime.Now;

        public DateTime Updated_At { get; set; } = DateTime.Now;

        public string? Remarks { get; set; }

        public string Status {  get; set; } = string.Empty;

        public ICollection<Vehicle_Loan> Loan { get; set; }

        public ICollection<Service_Master> service_Masters { get; set; }    

        public ICollection<Insurance_Premium> insurance_Premium { get;  set; }

        public ICollection<CraneOilChangeLog> craneOilChangeLogs { get; set; }  

        public ICollection<Fuel_Expenses> fuel_Expenses { get;  set; }

        public ICollection<CraneOtherExpenses> craneOtherExpenses { get; set; }

        public ICollection<Crane_Insurance> crane_Insurances { get; set; }

        

        

        



    
    }
}
