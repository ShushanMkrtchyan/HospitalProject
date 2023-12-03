using BusinessLayer.Entities;
using HospitalProject.Models.Responses.DocResponses;

namespace HospitalProject.Models.Requests.DocRequests
{
    public class DeleteReqM
    {
        public int ID { get; set; }


        public async Task<DeleteResponse> Delete()
        {
            Doctor d = new Doctor
            {
                ID = this.ID
            };


            Doctor deldoc = await d.DeleteDoctorAsync();


            if (deldoc.StatusCode != 400)
            {
                return new DeleteResponse { StatusCode = 200, ErrMsg = "Deleted" };
            }

            
            return new DeleteResponse { StatusCode = 400, ErrMsg = "The Doctor is assigned;Can't be deleted" };
            
        }

    }
}
