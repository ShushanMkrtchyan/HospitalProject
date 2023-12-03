using BusinessLayer.Entities;
using HospitalProject.Models.Responses.RoomResponses;

namespace HospitalProject.Models.Requests.RoomRequests
{
    public class UpdRoomReqM
    {
        public int ID { get; set; }
        public int? RoomNumber { get; set; }
        public int? PatientCount { get; set; }

        public async Task<UpdRoomResponse> UpdRoom()
        {
            Room r = new Room
            {
                ID = this.ID,
                RoomNumber = this.RoomNumber,
                PatientCount = this.PatientCount
            };

            Room resp = await r.UpdateAsync();

            if(resp.ID!=0)
            {
                return new UpdRoomResponse
                {
                    ID = resp.ID,
                    RoomNumber = resp.RoomNumber,
                    PatientCount = resp.PatientCount
                };
            }

            return null;

        }
    }
}
