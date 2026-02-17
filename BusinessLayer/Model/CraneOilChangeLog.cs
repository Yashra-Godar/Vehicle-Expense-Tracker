using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Model
{
    public class CraneOilChangeLog
    {
        public int Id { get; set; }

        public virtual Crane_Vehicle? Crane_Vehicle { get; set; }

        public int Crane_VehicleId { get; set; }

        public virtual Staff_Master? Staff_Master { get; set; }

        public int Staff_MasterId {  get; set; }

        public string Oil_Type { get; set; }=string.Empty;

        public string Oil_Brand { get; set; } = string.Empty;

        public int Oil_Qty { get; set; }

        public decimal Unit { get; set; }

        public decimal Meter_Reading { get; set; }

        public string Changed_By { get; set; }= string.Empty;

        public string Remarks { get; set; } = string.Empty;

        public DateTime Created_At { get;set; } = DateTime.Now;






    }
}
