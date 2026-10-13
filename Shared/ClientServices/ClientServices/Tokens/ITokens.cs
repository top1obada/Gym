using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServices.ClientServices.Tokens
{
    public interface ITokens
    {

        public Task<string?> GetJWTToken();

        public Task<string?> GetRefreshToken();

        public Task SetRefreshToken(string refreshToken);


        public Task SetJWTToken(string token);
        public Task Clear();
    }
}
