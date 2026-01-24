using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Model
{
    public class Fuel_Expenses
    {
        public int Id { get; set; }

        public virtual Vehicle_Type? Vehicle_Type { get; set; }

        public int Vehicle_TypeId { get; set; }

        public virtual Staff_Master? Staff_Master { get; set; }

        public int Staff_MasterId { get; set; }

        public DateTime Fuel_Date { get; set; }= DateTime.Now;

        public string Fuel_Source { get; set; } = string.Empty;

        public string Fuel_Station { get; set; } = string.Empty;

        public decimal Fuel_Qty { get; set; }

        public decimal Rate { get; set; }

        public decimal Odometer_Reading { get; set; }

        public string Payment_Method { get; set; }= string.Empty;

        public string Receipt_No {  get; set; } = string.Empty;

        public string Remarks { get; set; } = string.Empty;

        public DateTime Created_At {  get; set; } = DateTime.Now;

        public DateTime Updated_At { get;set; } = DateTime.Now;
    }
}
