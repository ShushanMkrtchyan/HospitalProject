using BusinessLayer;
using BusinessLayer.ApiModels;
using BusinessLayer.Entities;
using BusinessLayer.Utilities;
using HospitalProject.Models.Requests.DocRequests;
using HospitalProject.Models.Responses.DocResponses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HospitalProject.Controllers
{

    [ApiController]
    public class DocController : Controller 
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DocController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Authorize]
        [HttpGet("GetDoctorByID")] 
        public async Task<ActionResult<DoctorApi>> GetDocByID(int ID)
        {
            DoctorApi doc = new DoctorApi
            {
                ID = ID,

            };

            var res = await doc.GetByID(ID);

            if (res != null)
            {
                return res;
            }
            return null;

        }


        [Authorize]
        [HttpGet("GetDoctors")]
        public async Task<ActionResult<List<DoctorApi>>> GetDoctorAsync(int startIndex, int viewCount)
        {
            DoctorApi doc = new DoctorApi();

            List<DoctorApi> res = await doc.GetListAsync(startIndex, viewCount);

            if (res is not null)
            {

                return Ok(new
                {
                    list = res,
                    count = doc.RowCount
                });
            }
            return null;

        }
      

        [AllowAnonymous] 
        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginReqM model)
        {
            LoginResponse res = await model.LoginDoc(_httpClientFactory);

            if (res!= null && res.StatusCode == 200)
            {
                return Ok(res);
            }
            return Unauthorized();
         
        }

        [Authorize]
        [HttpPost("AddDoc")]
        public async Task<ActionResult<AddResponse>> AddDoc([FromBody] AddReqM model)
        {
            var newdoc = await model.Add();
            return Ok(newdoc);
        }

        [Authorize]
        [HttpPost("AddMultiple")]
        public async Task<ActionResult<AddMultResponse>> AddDoctors([FromBody] AddMultReqM model)
        {
            var newdocs = await model.AddDoctors();
            return Ok(newdocs);
        }

        [Authorize]
        [HttpPost("AddDocswithPats")]
        public async Task<ActionResult<AddDocPatResponse>> AddDocsxPats([FromBody] AddDocPatReqM model)
        {
            var newdocs = await model.AddDocsWithPats();
            return Ok(newdocs);
        }


        [Authorize]
        [HttpPost("UpdateDoctor")]

        public async Task<ActionResult<UpdateResponse>> UpdateDoctor([FromBody] UpdReqM model)
        {
            var upd = await model.Update();
            return Ok(upd);

        }


        [Authorize]
        [HttpPost("DeleteDoctor")]
        public async Task<ActionResult<DeleteResponse>> DeleteDoctor([FromBody] DeleteReqM model)
        {
            var res = await model.Delete();
            return Ok(res);
        }

    }

}
