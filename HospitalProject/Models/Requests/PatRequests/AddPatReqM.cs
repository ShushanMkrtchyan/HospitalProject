using BusinessLayer.Entities;
using HospitalProject.Models.Responses.PatResponses;

namespace HospitalProject.Models.Requests.PatRequests
{
    public class AddPatReqM
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? RoomID { get; set; }
        public int DoctorID { get; set; }
        public DateTime? TreatStartDate { get; set; }
        public DateTime? TreatEndDate { get; set; }


        public async Task<AddPatResponse> Add()
        {
            Patient patient = new Patient
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                RoomID = this.RoomID,
                DoctorID = this.DoctorID,
                TreatStartDate = this.TreatStartDate,
                TreatEndDate = this.TreatEndDate
            };

            var res = await patient.AddAsync();

            if(res.ID !=0)
            {
                return new AddPatResponse { ID = res.ID };
            }
            return null;

        }
    }
}
