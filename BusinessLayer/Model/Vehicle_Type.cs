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
           

            
                          
        }
        public int Id { get; set; }

        private string _typeName = string.Empty;

        public string TypeName 
        {
            get => _typeName;
            set => _typeName = value.ToUpper();

        }
        public ICollection<Crane_Vehicle> Crane_Vehicles { get; set; }

        
        

        

    }
}
