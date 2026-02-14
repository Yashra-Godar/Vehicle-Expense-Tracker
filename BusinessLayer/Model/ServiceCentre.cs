using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class ServiceCentre
    {
        public int Id { get; set; }

        public string Name { get; set; }=string.Empty;

        public string? Address { get; set; }

        public  string ContactNo  { get; set; }= string.Empty;

        public string? Email { get; set; }

        public DateTime CreatedAt { get; set; }= DateTime.Now;


    }
}
