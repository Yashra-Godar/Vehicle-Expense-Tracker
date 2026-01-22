using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace BusinessLayer.Model
{
    public class Vehicle_Type
    {
        
        public Vehicle_Type()
        {
            Crane_Vehicles = new HashSet<Crane_Vehicle>();
            Service_Masters=new HashSet<Service_Master>();
            craneOtherExpenses=new HashSet<CraneOtherExpenses>();
            Fuel_Expenses=new HashSet<Fuel_Expenses>();
            vehicle_Loans=new HashSet<Vehicle_Loan>();
            CraneOilChangeLogs=new HashSet<CraneOilChangeLog>();
            crane_Insurances=new HashSet<Crane_Insurance>();
            insurance_premiums=new HashSet<Insurance_Premium>();

            
                          
        }
        public int Id { get; set; }

        private string _typeName = string.Empty;

        public string TypeName 
        {
            get => _typeName;
            set => _typeName = value.ToUpper();

        }
        public ICollection<Crane_Vehicle> Crane_Vehicles { get; set; }

        public ICollection<Service_Master> Service_Masters { get; set; }

        public ICollection<CraneOtherExpenses> craneOtherExpenses {  get; set; }

        public ICollection<Fuel_Expenses> Fuel_Expenses { get; set; }

        public ICollection<Vehicle_Loan> vehicle_Loans { get; set; }

        public ICollection<CraneOilChangeLog> CraneOilChangeLogs { get; set; }

        public ICollection<Crane_Insurance>crane_Insurances { get; set; }

        public ICollection<Insurance_Premium>insurance_premiums {  get; set; }
       


        

        

        

    }
}
