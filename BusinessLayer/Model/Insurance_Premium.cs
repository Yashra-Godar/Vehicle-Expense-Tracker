using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Model
{
    public class Insurance_Premium
    {
        public int Id { get; set; }

        public virtual Crane_Insurance? Crane_Insurance { get; set; }

        public int Crane_InsuranceId { get; set; }

        public virtual Vehicle_Type? Vehicle_Type { get; set; }

        public int Vehicle_TypeId { get; set; }

        public virtual Staff_Master? Staff_Master { get; set; }

        public int Staff_MasterId { get; set; }

        public DateTime Premium_Month {  get; set; }= DateTime.Now;

        public DateTime Payment_Date { get; set; }= DateTime.Now;

        public DateTime Amount_Date { get; set; }= DateTime.Now;

        public string Payment_Mode { get; set; }= string.Empty;

        public string? Paid_To { get; set;}

        public string? Remarks { get; set; }

        public DateTime Created_At {  get; set; }= DateTime.Now;
    }
}
