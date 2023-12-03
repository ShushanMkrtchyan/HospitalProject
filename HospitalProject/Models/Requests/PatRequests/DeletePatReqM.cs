using BusinessLayer.Entities;
using HospitalProject.Models.Responses.PatResponses;

namespace HospitalProject.Models.Requests.PatRequests
{
    public class DeletePatReqM
    {
        public int ID { get; set; }

        public async Task <DeletePatResponse> Delete()
        {
           Patient p = new Patient
            {
                ID = ID,
            };

            Patient patresp = await p.DeleteAsync();

            if(patresp.StatusCode!=400 )
            {
                return new DeletePatResponse { StatusCode = 200, ErrMsg = "Deleted" };
            }

            return new DeletePatResponse { StatusCode = 400, ErrMsg = "Not deleted" };


        }
    }
}
