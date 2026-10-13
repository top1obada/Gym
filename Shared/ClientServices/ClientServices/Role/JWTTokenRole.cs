using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ClientServices.ClientServices.RegistServices;

namespace ClientServices.ClientServices.Role
{
    public class JWTTokenRole : IRole, IDisposable
    {

        private string? _Role;

        private IRegistService _RegistService;

        public JWTTokenRole(IRegistService registService)
        {
            _RegistService = registService;
        }

        private readonly SemaphoreSlim _manageRoleLocker = new SemaphoreSlim(1, 1);




        private string _GetRoleFromJwtToken(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            if (!tokenHandler.CanReadToken(jwtToken))
                return null;

            var token = tokenHandler.ReadJwtToken(jwtToken);

            var roleClaim = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

            return roleClaim?.Value;
        }

        public async Task<string?> GetRole()
        {
            await _manageRoleLocker.WaitAsync();

            try
            {
                if (string.IsNullOrWhiteSpace(_Role))
                {

                    var R = _RegistService.GetValue("Role", null);

                    if (R == null) return null;

                    _Role = R.ToString();

                    if (string.IsNullOrWhiteSpace(_Role)) return null;

                }

                return _Role;

            }
            finally
            {
                _manageRoleLocker?.Release();

            }

        }

        public async Task Remove()
        {
            await _manageRoleLocker.WaitAsync();

            try
            {
                _Role = null;

                _RegistService.DeleteValue("Role");
            }
            finally
            {
                _manageRoleLocker?.Release();
            }

        }

        public async Task SetRole(string JWTToken)
        {
            await _manageRoleLocker.WaitAsync();

            try
            {

                var RoleFromToken = _GetRoleFromJwtToken(JWTToken);

                if (string.IsNullOrWhiteSpace(RoleFromToken)) return;

                _RegistService.SetValue("Role", RoleFromToken);

                _Role = RoleFromToken;

            }

            finally { _manageRoleLocker?.Release(); }

        }

        public void Dispose()
        {
            _manageRoleLocker?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}