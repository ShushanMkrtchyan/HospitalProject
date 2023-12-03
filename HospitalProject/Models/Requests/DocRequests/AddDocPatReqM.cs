using BusinessLayer.ApiModels;
using BusinessLayer.Entities;
using BusinessLayer.EntityModels;
using HospitalProject.Models.Requests.PatRequests;
using HospitalProject.Models.Responses.DocResponses;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;

namespace HospitalProject.Models.Requests.DocRequests
{
    public class AddDocPatReqM
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Profession { get; set; }
        public string? HospitalAddress { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }

        public List<PatientM>? Patients { get; set; }

        public async Task<AddDocPatResponse> AddDocsWithPats()
        {
            Doctor doctor = new Doctor
            {
                FirstName = FirstName,
                LastName = LastName,
                Profession = Profession,
                HospitalAddress = HospitalAddress,
                Login = Login,
                Password = Password,
                Patients = Patients
            };
                    

            Doctor res = await doctor.AddDocsXpats();

            if(res != null)
            {
                return new AddDocPatResponse
                {
                    FirstName = res.FirstName,
                    LastName = res.LastName,
                    Profession = res.Profession,
                    HospitalAddress = HospitalAddress,
                    Patients = res.Patients
                };
            }
            return null;

        }
    }
}
