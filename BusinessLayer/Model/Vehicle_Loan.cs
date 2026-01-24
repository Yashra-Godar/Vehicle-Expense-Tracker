using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Model
{
    public class Vehicle_Loan
    {
        public Vehicle_Loan()
        {
            loan_Installments=new HashSet<Loan_Installment>();
        }
        public int Id { get; set; }

        public virtual Vehicle_Type? Vehicle_Type { get; set; }

        public int Vehicle_TypeId { get; set; }

        public virtual Staff_Master? Staff_Master { get; set; }

        public int Staff_MasterId { get; set; }

        public string Loan_Provider { get; set; }=string.Empty;

        public decimal Loan_Amount { get; set; }

        public decimal Interest_Rate { get; set; }

        public decimal Term_Month { get; set; }

        public DateTime Start_Date { get; set; } = DateTime.Now;

        public decimal Monthly_Installment {  get; set; }

        public string? Status { get; set; }

        public string Contact_Detail { get; set; }= string.Empty;

        public DateTime Created_At { get; set; } = DateTime.Now;

        public DateTime Updated_At { get; set; } = DateTime.Now;

        public ICollection<Loan_Installment> loan_Installments { get; set; }


    }
}
