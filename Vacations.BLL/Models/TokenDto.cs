using System;
using System.Collections.Generic;
using System.Text;

namespace Vacations.BLL.Models
{
    public class TokenDto
    {
        public string Token { get; }
        public string Role { get; }

        public TokenDto(string token, string role)
        {
            Token = token;
            Role = role;
        }
    }
}
