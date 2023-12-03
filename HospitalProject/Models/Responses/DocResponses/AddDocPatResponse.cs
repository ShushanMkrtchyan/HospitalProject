using BusinessLayer.ApiModels;
using BusinessLayer.Entities;
using BusinessLayer.EntityModels;
using HospitalProject.Models.Requests.PatRequests;

namespace HospitalProject.Models.Responses.DocResponses
{
    public class AddDocPatResponse
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Profession { get; set; }
        public string? HospitalAddress { get; set; }
        public List<PatientM> Patients { get; set; } 

    }
}
