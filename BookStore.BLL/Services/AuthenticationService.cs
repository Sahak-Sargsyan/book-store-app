using AuthService.Dtos;
using BookStore.BLL.Interfaces;
using BookStore.Dtos;
using Microsoft.AspNetCore.Http;
using System.Text;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace BookStore.BLL.Services
{
    public class AuthenticationService : IAuthService
    {
        const string url = "https://localhost:7268/auth/";
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthenticationService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequest)
        {
            var content = new StringContent(
                JsonConvert.SerializeObject(new
                {
                    email = loginRequest.Email,
                    password = loginRequest.Password,
                }),
                Encoding.UTF8,
                "application/json-patch+json");

            var httpClient = new HttpClient();
            var result = await httpClient.PostAsync(url + "login", content);
            var res = JsonConvert.DeserializeObject<LoginResponseDto>(await result.Content.ReadAsStringAsync());

            return res;
        }
    }
}
