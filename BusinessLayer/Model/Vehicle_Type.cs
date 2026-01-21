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
            Vehicle_Loans = new HashSet<Vehicle_Loan>();
            CraneOilChangesLog=new HashSet<CraneOilChangeLog>();

      
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

        public ICollection<Vehicle_Loan> Vehicle_Loans { get; set; }

        public ICollection<CraneOilChangeLog> CraneOilChangesLog { get; set; }

        

    }
}
