using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Model
{
    public class Loan_Installment
    {
        public int Id { get; set; }

        public virtual Vehicle_Loan? Vehicle_Loan {  get; set; }

        public int Vehicle_LoanId { get; set; }

        public virtual Staff_Master? Staff_Master { get; set; }

        public int Staff_MasterId { get; set; }

        public DateTime Installment_Date { get; set; }= DateTime.Now;

        public decimal Amount_Paid { get; set; }

        public string Payment_Method { get; set; }= string.Empty;

        public string? Receipt_No {  get; set; }

        public DateTime Paid_On {  get; set; }= DateTime.Now;

        public string Status { get; set; }=string.Empty;

        public string Note {  get; set; }=string.Empty;

        public DateTime Created_At {  get; set; }= DateTime.Now;

        public DateTime Updated_At { get; set; } = DateTime.Now;

    }
}
