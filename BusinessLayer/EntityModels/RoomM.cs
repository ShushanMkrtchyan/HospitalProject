using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.EntityModels
{
    public class RoomM
    {
        public int ID { get; set; }
        public int? RoomNumber { get; set; }
        public int? PatientCount { get; set; }
    }
}
