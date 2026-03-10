using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface VehicleExpenseReportDTO
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
