using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Model
{
    public class Crane_Insurance
    {
        public Crane_Insurance()
        {
            insurance_Premium = new HashSet<Insurance_Premium>();
        }
        public int Id { get; set; }

        public virtual Vehicle_Type? VehicleType { get; set; }

        public int Vehicle_TypeId { get; set; }

        public virtual Staff_Master? Staff_Master { get; set; }

        public int Staff_MasterId { get; set; }

        public string Policy_No { get; set; }=string.Empty;

        public string Insurance_Company { get; set;} = string.Empty;

        public string Policy_Type { get; set;} = string.Empty;

        public DateTime Start_Date { get; set; }=DateTime.Now;

        public DateTime End_Date { get; set;}=DateTime.Now;

        public decimal Premium_Amount { get; set;}

        public decimal Premium_Frequency { get; set;} 
        public string? Agent_Name { get; set;} 

        public string? Agent_ContactNo { get; set;}

        public string? Remarks{ get;set;}

        public DateTime Created_At {  get; set; }=DateTime.Now;

        public ICollection<Insurance_Premium> insurance_Premium { get; set; }
    }
}
