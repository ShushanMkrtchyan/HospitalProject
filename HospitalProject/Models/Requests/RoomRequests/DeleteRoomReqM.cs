using BusinessLayer.Entities;
using HospitalProject.Models.Responses.RoomResponses;

namespace HospitalProject.Models.Requests.RoomRequests
{
    public class DeleteRoomReqM
    {
        public int ID { get; set; }

        public async Task<DeleteRoomResponse> Delete()
        {
            Room r = new Room
            {
                ID = ID
            };

            Room roomrep = await r.DeleteAsync();

            if(roomrep.StatusCode!=400)
            {
                return new DeleteRoomResponse { StatusCode = 200, ErrMsg = "Deleted" };
            }
            return new DeleteRoomResponse { StatusCode = 400, ErrMsg = "Room is reserved, cant be deleted" };
        }
    }
}
