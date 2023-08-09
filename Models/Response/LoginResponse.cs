using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Response
{
    public class LoginResponse
    {
        public LoginResponse(string message, string token)
        {
            Message = message;
            Token = token;
        }

        public string Message { get; set; }

        public string Token { get; set; }
    }
}
