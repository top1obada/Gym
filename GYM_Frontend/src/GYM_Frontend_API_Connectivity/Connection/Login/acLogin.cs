using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Gym_Backend_DTO.Login;
using GYM_DTO.Login;

namespace GYM_Frontend_API_Connectivity.Connection.Login
{
    public class acLogin : acConnect
    {

        public acLogin(HttpClient client) : base(client) { }


        public async Task<(string? Token,string? ErrorMessage)> Login
            (clsSystemUserLoginRequirementsDTO systemUserLoginRequirementsDTO)
        {

            var requirementsJsonString = JsonSerializer.Serialize(systemUserLoginRequirementsDTO);

            var jsonContent = JsonSerializer.Serialize(systemUserLoginRequirementsDTO);

            var Request = new HttpRequestMessage(HttpMethod.Post, "Login/SystemUser")
            {
                Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
            };


            Request.Options.Set(new HttpRequestOptionsKey<bool>("IsLoginRequest"), true);

            
            var Response = await _Client.SendAsync(Request);

            if (Response.IsSuccessStatusCode)
            {
                return (await Response.Content.ReadAsStringAsync(), null);
            }

            return (null, await Response.Content.ReadAsStringAsync());

        }

        public async Task<(string?,string ? ErrorMessage)> LoginByRefreshToken()
        {

            var Request = new HttpRequestMessage();

            Request.Options.Set(new HttpRequestOptionsKey<bool>("IsLoginRefreshTokenRequest"), true);

            var Response = await _Client.SendAsync(Request);

            if (Response.IsSuccessStatusCode) return (await Response.Content.ReadAsStringAsync(), null);

            return (null, await Response.Content.ReadAsStringAsync());

        }

    }
}
