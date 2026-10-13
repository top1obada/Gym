using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientServices.ClientServices.RegistServices;

namespace ClientServices.ClientServices.Tokens
{
    public class NativeTokens : ITokens, IDisposable
    {
        private string? _JWTToken;
        private string? _RefreshToken;
        private IRegistService _RegistService;
        private readonly SemaphoreSlim _manageTokenLocker = new SemaphoreSlim(1, 1);

        public NativeTokens(IRegistService registService)
        {

            _RegistService = registService;

        }

        public async Task<string?> GetJWTToken()
        {
            await _manageTokenLocker.WaitAsync();

            try
            {
                if (string.IsNullOrWhiteSpace(_JWTToken))
                {
                    var Token = _RegistService.GetValue("JWT_Token", null);

                    if (Token == null) return null;

                    _JWTToken = Token.ToString();

                    if (string.IsNullOrWhiteSpace(_JWTToken)) return null;
                }

                return _JWTToken;
            }
            finally
            {
                _manageTokenLocker.Release();
            }
        }

        public async Task<string?> GetRefreshToken()
        {
            await _manageTokenLocker.WaitAsync();

            try
            {
                if (string.IsNullOrWhiteSpace(_RefreshToken))
                {
                    var Token = _RegistService.GetValue("Refresh_Token", null);

                    if (Token == null) return null;

                    _RefreshToken = Token.ToString();

                    if (string.IsNullOrWhiteSpace(_RefreshToken)) return null;
                }

                return _RefreshToken;
            }
            finally
            {
                _manageTokenLocker.Release();
            }
        }

        public async Task SetRefreshToken(string refreshToken)
        {
            await _manageTokenLocker.WaitAsync();

            try
            {
                _RefreshToken = refreshToken;
                _RegistService.SetValue("Refresh_Token", _RefreshToken);
               
            }
            finally
            {
                _manageTokenLocker.Release();
            }
        }

        public async Task SetJWTToken(string token)
        {
            await _manageTokenLocker.WaitAsync();

            try
            {
                _JWTToken = token;
                _RegistService.SetValue("JWT_Token", _JWTToken);
                
            }
            finally
            {
                _manageTokenLocker.Release();
            }
        }

        public async Task<bool> IsJWTTokenExists()
        {
            await _manageTokenLocker.WaitAsync();

            try
            {
                if (!string.IsNullOrWhiteSpace(_JWTToken))
                    return true;

                var Token = _RegistService.GetValue("JWT_Token", null);

                if (Token == null) return false;

                _JWTToken = Token.ToString();

                return !string.IsNullOrWhiteSpace(_JWTToken);
            }
            finally
            {
                _manageTokenLocker.Release();
            }
        }

        public async Task<bool> IsRefreshTokenExists()
        {
            await _manageTokenLocker.WaitAsync();

            try
            {
                if (!string.IsNullOrWhiteSpace(_RefreshToken))
                    return true;

                var Token = _RegistService.GetValue("Refresh_Token", null);

                if (Token == null) return false;

                _RefreshToken = Token.ToString();

                return !string.IsNullOrWhiteSpace(_RefreshToken);
            }
            finally
            {
                _manageTokenLocker.Release();
            }
        }

        public async Task Clear()
        {
            await _manageTokenLocker.WaitAsync();

            _JWTToken = null;
            _RefreshToken = null;

            try
            {
                _RegistService.DeleteValue("Refresh_Token");
                _RegistService.DeleteValue("JWT_Token");
            }
            finally
            {
                _manageTokenLocker.Release();
            }

            
        }

        public void Dispose()
        {
            _manageTokenLocker?.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}