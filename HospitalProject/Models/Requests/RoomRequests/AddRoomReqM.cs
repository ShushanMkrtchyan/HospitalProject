using BusinessLayer.Entities;
using HospitalProject.Models.Responses.RoomResponses;

namespace HospitalProject.Models.Requests.RoomRequests
{
    public class AddRoomReqM
    {
        public int? RoomNumber { get; set; }
        public int? PatientCount { get; set; }

        public async Task<AddRoomResponse>Add()
        {
            Room room = new Room
            {
                RoomNumber = this.RoomNumber,
                PatientCount = this.PatientCount
            };

            var res = await room.AddAsync();

            if (res.ID!=0)
            {
                return new AddRoomResponse { ID = res.ID };
            }
            return null;
        }
    }
}
