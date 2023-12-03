using BusinessLayer.Entities;
using HospitalProject.Models.Responses.DocResponses;

namespace HospitalProject.Models.Requests.DocRequests
{
    public class AddReqM
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Profession { get; set; }
        public string? HospitalAddress { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }


        public async Task<AddResponse> Add()
        {
            Doctor doc = new Doctor
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Profession = this.Profession,
                HospitalAddress = this.HospitalAddress,
                Login = this.Login,
                Password = this.Password
            };

            Doctor addeddoctor = await doc.AddAsync();

            if (addeddoctor.ID != 0 && addeddoctor.Login!= new Doctor().Login)
            {
                return new AddResponse { 
                    ID = addeddoctor.ID ,
                    ErrMsg = "Added successfully"
                };
            }

            return new AddResponse
            {
                ErrMsg = "Psw is already used, try another one"
            };
            

        }
    }
}
