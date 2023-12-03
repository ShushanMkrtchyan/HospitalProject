using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.EntityModels
{
    public class PatientM
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int? RoomID { get; set; }

        public int DoctorID { get; set; }

        public DateTime? TreatStartDate { get; set; }

        public DateTime? TreatEndDate { get; set; }
    }
}
