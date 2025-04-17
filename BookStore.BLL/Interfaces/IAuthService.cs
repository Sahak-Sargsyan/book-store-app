using AuthService.Dtos;
using BookStore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BLL.Interfaces
{
    public interface IAuthService
    {
        public Task<LoginResponseDto> Login(LoginRequestDto loginRequest);
        public Task Register(RegisterRequestDto registerRequest);
    }
}
