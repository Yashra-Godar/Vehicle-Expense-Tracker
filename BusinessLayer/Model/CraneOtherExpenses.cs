using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BusinessLayer.Model
{
    public class CraneOtherExpenses
    {
        public int Id { get; set; }

        public virtual Vehicle_Type? Vehicle_Type { get; set; }

        public int Vehicle_TypeId { get; set; }

        public string Expense_Type{ get; set; }=string.Empty;

        public decimal Amount { get; set; }

        public DateTime Expense_Date { get; set; }=DateTime.Now;

        public string? Paid_To {  get; set; }

        public string? Reference_No { get; set; }

        public string? Description { get;set; }

        public string Payment_Mode { get;set; }=string.Empty;

        public DateTime Created_At {  get; set; }=DateTime.Now;


    }
}
