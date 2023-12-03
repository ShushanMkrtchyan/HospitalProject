using BusinessLayer.ApiModels;
using BusinessLayer.Entities;
using HospitalProject.Models.Requests.PatRequests;
using HospitalProject.Models.Responses.PatResponses;
using Microsoft.AspNetCore.Mvc;

namespace HospitalProject.Controllers
{
    [ApiController]
    public class PatientController : Controller
    {

        [HttpGet("GetPatientByID")]
        public async Task<ActionResult<PatientApi>> GetPatByID(int ID)
        {
            PatientApi patient = new PatientApi
            {
                ID = ID
            };

            PatientApi res = await patient.GetAsyncID(ID);

            if (res != null)
            {
                return res;

            }
            return null;

        }

        [HttpGet("GetPatients")]
        public async Task<ActionResult<List<PatientApi>>> GetPatientAsync(int startIndex, int viewCount)
        {
            (List<PatientApi>, uint?) res = await new PatientApi().GetListAsync(startIndex, viewCount);

            if (res != (null, null))
            {
                return Ok(new
                {
                    list = res.Item1,
                    count = res.Item2
                });

            }
            return null;

        }

        [HttpPost("AddPat")]
        public async Task<ActionResult<AddPatResponse>> AddPat([FromBody] AddPatReqM model)
        {
            var res = await model.Add();
            return Ok(res);
        }


        [HttpPost("UpdatePatient")]
        public async Task<ActionResult<UpdPateResponse>> UpdatePatient([FromBody] UpdPatReqM model)
        {
            var res = await model.Update();
            return Ok(res);
        }

        [HttpPost("DeletePatient")]
        public async Task<IActionResult> DeletePatient([FromBody] DeletePatReqM model)
        {
            var res = await model.Delete();
            return Ok(res);
        }
    }
}
