using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
        public class VehicleSummaryDTO
        {
            public string VehicleNo { get; set; }
            public string VehicleName { get; set; }
            public string VehicleType { get; set; }
            public string MakeBy { get; set; }
            public string Model { get; set; }
            public string ManufactureYear { get; set; }

            public string StaffName { get; set; }

            public decimal CapacityTons { get; set; }
            

            public string PurchaseType { get; set; }

            
            public string Note { get; set; }

            // Expense
            public decimal TotalFuelExpense { get; set; }
            public decimal TotalServiceExpense { get; set; }
            public decimal TotalOtherExpense { get; set; }
            public decimal TotalInsuranceAmount { get; set; }
            public decimal TotalLoanPaid { get; set; }

            // Activity
            public DateTime? LastFuelDate { get; set; }
            public DateTime? LastServiceDate { get; set; }
            public DateTime? LastOilChangeDate { get; set; }

            public int TotalFuelEntries { get; set; }
            public int TotalServices { get; set; }
            public int TotalOilChanges { get; set; }
        }
    }

