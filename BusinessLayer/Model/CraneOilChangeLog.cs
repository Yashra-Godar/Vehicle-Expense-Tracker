using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Model
{
    public class CraneOilChangeLog
    {
        public int Id { get; set; }

        public virtual Vehicle_Type? Vehicle_Type { get; set; }

        public int Vehicle_TypeId { get; set; }

        public virtual Staff_Master? Staff_Master { get; set; }

        public int Staff_MasterId {  get; set; }

        public string Oil_Type { get; set; }=string.Empty;

        public string Oil_Brand { get; set; } = string.Empty;

        public int Oil_Qty { get; set; }

        public decimal Unit { get; set; }

        public decimal Meter_Reading { get; set; }

        public DateTime Change_Date { get; set; } = DateTime.Now;
        public DateTime NextDue_Date { get; set; } = DateTime.Now;

        public string Changed_By { get; set; }= string.Empty;

        public string Remarks { get; set; } = string.Empty;

        public DateTime Created_At { get;set; } = DateTime.Now;






    }
}
