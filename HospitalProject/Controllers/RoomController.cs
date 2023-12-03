using BusinessLayer.ApiModels;
using BusinessLayer.Entities;
using HospitalProject.Models.Requests.DocRequests;
using HospitalProject.Models.Requests.RoomRequests;
using HospitalProject.Models.Responses.DocResponses;
using HospitalProject.Models.Responses.RoomResponses;
using Microsoft.AspNetCore.Mvc;

namespace HospitalProject.Controllers
{
    [ApiController]
    public class RoomController:Controller
    {
     
        [HttpGet("GetRoomByID")]
        public async Task<ActionResult<RoomApi>> GetRoomByID(int ID)
        {
            RoomApi room = new RoomApi()
            {
                ID = ID
            };

            RoomApi res = await room.GetByID(ID);

            if(res!=null)
            {
                return new RoomApi
                {
                    ID = res.ID,
                    RoomNumber = res.RoomNumber,
                    PatientCount = res.PatientCount,
                    Patients = res.Patients
                };
            }
            return null;


        }

        
        [HttpGet("GetRooms")]
        public async Task<ActionResult<List<RoomApi>>> GetRoomAsync(int startIndex, int viewCount)
        {          
           (List<RoomApi>,uint?) res = await new RoomApi().GetListAsync(startIndex,viewCount);

            if (res != (null,null))
            {
                return Ok(new
                {
                    list = res.Item1,
                    count = res.Item2
                });
                
            }
            return null;


        }

        

        [HttpPost("AddRoom")]

        public async Task<ActionResult<AddRoomResponse>> AddRoom([FromBody]AddRoomReqM model)
        {
            AddRoomResponse res = await model.Add();
            return Ok(res);
        }

        [HttpPost("AddRoomWithPats")]
        public async Task<ActionResult<AddRoomPatResponse>> AddRoomxPats([FromBody] AddRoomPatReqM model)
        {
            AddRoomPatResponse res = await model.AddRoomWithPatients();
            return Ok(res);
        }
        
        [HttpPost("UpdateRoom")]
        public async Task<ActionResult<UpdRoomResponse>> UpdateRoom([FromBody]UpdRoomReqM model)
        {
            var res = await model.UpdRoom();
            return Ok(res);
        }

        [HttpPost("DeleteRoom")]

        public async Task<ActionResult<DeleteRoomResponse>> DeleteRoom([FromBody]DeleteRoomReqM model)
        {           
            var res = await model.Delete();
            return Ok(res);
        }
    }
}
