using BusinessLayer.Entities;
using HospitalProject.Models.Responses.DocResponses;

namespace HospitalProject.Models.Requests.DocRequests
{
    public class UpdReqM
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Profession { get; set; }

        public string? HospitalAddress { get; set; }

        public string? Login { get; set; }
        public string? Password { get; set; }

        public async Task<UpdateResponse> Update()
        {
            Doctor doc = new Doctor
            {
                ID = this.ID,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Profession = this.Profession,
                HospitalAddress = this.HospitalAddress,
                Login = this.Login,
                Password = this.Password
            };

            Doctor updtDoc = await doc.UpdateAsync();
            
            if(updtDoc.ID != 0 )
            {
                return new UpdateResponse
                {
                    ID = updtDoc.ID,
                    FirstName = updtDoc.FirstName,
                    LastName = updtDoc.LastName,
                    Profession = updtDoc.Profession,
                    HospitalAddress = updtDoc.HospitalAddress,
                    Login = updtDoc.Login,
                    Password = updtDoc.Password
                };
            }
            return null;
        }
    }
}
