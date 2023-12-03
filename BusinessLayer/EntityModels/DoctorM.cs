using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.EntityModels
{
    public class DoctorM
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Profession { get; set; }
        public string? HospitalAddress { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}
