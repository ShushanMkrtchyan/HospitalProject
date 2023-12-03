using BusinessLayer.ApiModels;
using BusinessLayer.Entities;
using BusinessLayer.EntityModels;
using HospitalProject.Models.Responses.RoomResponses;

namespace HospitalProject.Models.Requests.RoomRequests
{
    public class AddRoomPatReqM
    {
        public int? RoomNumber { get; set; }
        public int? PatientCount { get; set; }

        public List<PatientM>Patients { get; set; } 

        public async Task<AddRoomPatResponse>AddRoomWithPatients()
        {
            Room room = new Room
            {
                RoomNumber = RoomNumber,
                PatientCount = PatientCount,
                Patients = Patients
            };

            Room res = await room.AddRoomXpats();

            if(res != null)
            {
                return new AddRoomPatResponse
                {
                    PatientCount = res.PatientCount,
                    RoomNumber = room.RoomNumber,
                    Patients = res.Patients

                };
            }

            return null;

        }
    }
}
