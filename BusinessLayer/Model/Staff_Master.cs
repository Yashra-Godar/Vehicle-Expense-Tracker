using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Model
{
    public class Staff_Master
    {
        public int Id { get; set; }

        public string FullName { get; set; }=string.Empty;

        public string ContactNo { get; set; }= string.Empty;

        public string? Email { get; set; } 

        public string Password { get; set; }=string.Empty ;

        public bool IsActive { get; set; }

        public DateTime Created_At { get; set; }
    }
}
