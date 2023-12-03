using DataAccessLayer.DBTools;
using DataAccessLayer.Interfaces;

namespace HospitalProject.Models.Responses.DocResponses
{
    public class LoginResponse
    {
       

        public string Token {  get; set; }

        public int StatusCode { get; set; }

       

    }

}
