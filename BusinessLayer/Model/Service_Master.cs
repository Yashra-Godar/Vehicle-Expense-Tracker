using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Model
{
    public class Service_Master
    {
        public Service_Master()
        {
            service_Parts = new HashSet<Service_Parts>();
        }
        public int Id { get; set; }
        
        public virtual Vehicle_Type? VehicleType { get; set; }

        public int Vehicle_TypeId { get; set; }

        public virtual Staff_Master? Staff_Master { get; set; }

        public int Staff_MasterId { get; set; }


        public DateTime Service_Date { get; set; }= DateTime.Now;

        public string Service_Type { get; set; }= string.Empty;

        public string Performed_By { get; set; }=string.Empty;

        public string? Remark {  get; set; }

        public decimal Cost {  get; set; }

        public DateTime Created_At {  get; set; }= DateTime.Now;

        public DateTime Updated_At { get; set; } = DateTime.Now;

        public ICollection<Service_Parts> service_Parts { get; set; }
    }
}
