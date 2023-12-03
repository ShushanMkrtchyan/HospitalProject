using BusinessLayer.Entities;
using BusinessLayer.Utilities;
using DataAccessLayer.DBTools;
using DataAccessLayer.Interfaces;
using HospitalProject.Models.Responses.DocResponses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using static HospitalProject.Controllers.DocController;

namespace HospitalProject.Models.Requests.DocRequests
{
    
    public class LoginReqM
    {
        public string Login { get; set; }
        public string Password { get; set; }
      

        public async Task<LoginResponse> LoginDoc(IHttpClientFactory httpClientFactory)
        {

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:3001/LoginAPI");

            request.Content = JsonContent.Create(this);
            var httpClient = httpClientFactory.CreateClient();
            
            HttpResponseMessage response = await httpClient.SendAsync(request);

            LoginResponse res = null!;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                res = JsonConvert.DeserializeObject<LoginResponse>(responseBody);
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, this.Login),
                    new Claim(ClaimTypes.Name,this.Password),

                };

            
            var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.Now.AddMinutes(5),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
        );

            string token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new LoginResponse
            {
                Token = token,
                StatusCode = 200

            };
        }

    }
}

