using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TemplateMvvmLight.Constants;
using TemplateMvvmLight.IServices;
using TemplateMvvmLight.Models;


namespace TemplateMvvmLight.Services
{
    class BodyLogin
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    class AuthenticationServices : IAuthenticationServices
    {
        public async Task<HttpResponse<User>> Login(String username, String password)
        {
            try
            {
                HttpClient client = new HttpClient();
                BodyLogin body = new BodyLogin
                {
                    username = username,
                    password = password
                };
                string content = JsonConvert.SerializeObject(body);
                var response = await client.PostAsync(Urls.LOGIN_URL, new StringContent(content, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    string responseText = await response.Content.ReadAsStringAsync();
                    return new HttpResponse<User>
                    {
                        Result = JsonConvert.DeserializeObject<User>(responseText)
                    };
                }
                // TODO gestire casistiche di autenticazione fallita
                else
                {
                    return new HttpResponse<User>
                    {
                        Error = ErrorResponse.AUTHENTICATION_FAILED
                    };
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
                return new HttpResponse<User>
                {
                    Error = ErrorResponse.GENERIC_ERROR
                };
            }
        }
    }
}
