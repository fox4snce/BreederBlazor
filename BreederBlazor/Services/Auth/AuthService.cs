using BreederBlazor.Models;
using BreederBlazor.Models.Auth;
using BreederBlazor.Services.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BreederBlazor.Services.Auth
{
    

    public class AuthService : IAuthService
    {

        private readonly HttpClient httpClient;

        public AuthService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            user = new User();
        }

        public User user { get; set; }
        
        public async Task Login(string login, string password)
        {
            RegistrationInfo reginfo = new RegistrationInfo();
            reginfo.Username = login;
            reginfo.Password = password;

            StringContent content = new StringContent(JsonSerializer.Serialize(reginfo));

            using (var response = await httpClient.PostAsync("https://api.goofyfox.com/auth/login", content))
            {
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    user.Key = JsonSerializer.Deserialize<ServiceResponse<string>>(apiResponse).Data;
                }
            }
        }

        public async Task<string> Register(string login, string password)
        {
            RegistrationInfo reginfo = new RegistrationInfo();
            reginfo.Username = login;
            reginfo.Password = password;

            StringContent content = new StringContent(JsonSerializer.Serialize(reginfo));

            var RegisterInfo = new RegistrationInfo { Username = login, Password = password };

            var response = await httpClient.PostAsync("https://api.goofyfox.com/auth/register", content);
            
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    user.Username = login;
                    Console.WriteLine("Registered");
                    return "You are registered. Please log in.";
                }
                else
                {
                    Console.WriteLine("Error");
                    return "error";
                }
            
        }
    }

    public class RegistrationInfo
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
