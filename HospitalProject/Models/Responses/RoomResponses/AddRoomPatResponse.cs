using BusinessLayer.ApiModels;
using BusinessLayer.Entities;
using BusinessLayer.EntityModels;
using DataAccessLayer.DBTools;

namespace HospitalProject.Models.Responses.RoomResponses
{
    public class AddRoomPatResponse
    {
        public int? RoomNumber { get; set; }
        public int? PatientCount { get; set; }
        public List<PatientM> Patients { get; set; }

       
    }
}
