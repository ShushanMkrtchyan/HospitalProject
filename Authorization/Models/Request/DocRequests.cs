using BusinessLayer.Entities;
using BusinessLayer.Utilities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Authorization.Models
{
    public class DocRequests
    {
        public string Login { get; set; }
        public string Password { get; set; }


        public async Task<Response> Log()
        {
            Doctor user = new Doctor
            {
                Login = Login,
                Password = Password

            };

            Doctor req = await user.GetLoginAsync();

            if (req.ID != 0) 
            {
                return new Response
                {
                    ID = req.ID,
                    FirstName = req.FirstName,
                    LastName = req.LastName,
                    Profession = req.Profession,
                    HospitalAddress = req.HospitalAddress,

                };
                           
          
            }
            return null;
        }
    }
    }
