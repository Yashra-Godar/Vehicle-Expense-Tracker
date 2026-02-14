using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class ServiceCentre
    {
        public ServiceCentre()
        {
            service_Masters = new HashSet<Service_Master>();
        }
        public int Id { get; set; }

        public string Name { get; set; }=string.Empty;

        public string? Address { get; set; }

        public  string ContactNo  { get; set; }= string.Empty;

        public string? Email { get; set; }

        public DateTime CreatedAt { get; set; }= DateTime.Now;

        public ICollection<Service_Master> service_Masters { get; set; }    


    }
}
