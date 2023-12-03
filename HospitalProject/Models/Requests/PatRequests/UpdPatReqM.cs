using BusinessLayer.Entities;
using HospitalProject.Models.Responses.PatResponses;

namespace HospitalProject.Models.Requests.PatRequests
{
    public class UpdPatReqM
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int? RoomID { get; set; }

        public int DoctorID { get; set; }
       

        public DateTime? TreatStartDate { get; set; }

        public DateTime? TreatEndDate { get; set; }

        public async Task<UpdPateResponse> Update()
        {
            Patient pat = new Patient
            {
                ID = this.ID,
                FirstName = this.FirstName,
                LastName = this.LastName,
                RoomID = this.RoomID,
                DoctorID = this.DoctorID,
                TreatStartDate = this.TreatStartDate,
                TreatEndDate = this.TreatEndDate,
            };

            Patient updpat = await pat.UpdateAsync();

            if(updpat.ID!=0)
            {
                return new UpdPateResponse
                {
                    ID = updpat.ID,
                    FirstName = updpat.FirstName,
                    LastName = updpat.LastName,
                    RoomID = updpat.RoomID,
                    DoctorID = updpat.DoctorID,
                    TreatStartDate = updpat.TreatStartDate,
                    TreatEndDate = updpat.TreatEndDate,
                    ErrMsg = updpat.ErrMsg
                };
            }
            return null;
        }
    }
}
