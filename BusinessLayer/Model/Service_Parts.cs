using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Model
{
    public class Service_Parts
    {
        public int Id { get; set; }

        public virtual Service_Master? Service_Master { get; set; }

        public int Service_MasterId { get; set; }

        public virtual Staff_Master?  Staff_Master { get; set; }

        public int Staff_MasterId { get; set; }

        public string Parts_Name { get; set; } = string.Empty;

        public int Qty { get; set; }

        public decimal Unit_Cost { get; set; }

        public decimal Total_Cost { get; set; }

        public string? Remark { get;set; }

        public DateTime Created_At { get; set; }= DateTime.Now;
        public DateTime Updated_At { get; set;} = DateTime.Now;


    }
}

    

