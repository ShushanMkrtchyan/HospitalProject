using BusinessLayer.Entities;
using HospitalProject.Models.Responses.DocResponses;
using Newtonsoft.Json;

namespace HospitalProject.Models.Requests.DocRequests
{
    public class AddMultReqM
    {
        public List<AddReqM> Doctors { get; set; }
        public async Task<AddMultResponse> AddDoctors()

        {
            string json = JsonConvert.SerializeObject(Doctors);

            List<Doctor> res = await new Doctor().AddMultipleAsync(json);

            if (res != null)
            {
                return new AddMultResponse
                {
                    StatusCode = 200
                };
            }
            return null;

        }

    }

 }

