using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace GYM_Frontend_UI.Data.JWT_Data
{
    public class clsJWTData
    {
        public enum enUserRole { eOwner = 1, eAdmin = 2 }
        public int? PersonID { get; private set; }
        public string? FirstName { get; private set; }
        public string? Role { get; private set; }
        public string? Gender { get; private set; }
        public string? JoiningDate { get; private set; }

        private clsJWTData() { }

        public static clsJWTData? CurrentUserData { get; private set; }
        public static void FillFromToken(string? jwtToken)
        {
            if (string.IsNullOrWhiteSpace(jwtToken))
                return;

            var handler = new JwtSecurityTokenHandler();

            if (!handler.CanReadToken(jwtToken))
                return;

            var token = handler.ReadJwtToken(jwtToken);

            var claims = token.Claims.ToDictionary(c => c.Type, c => c.Value);

            CurrentUserData = new clsJWTData
            {
                PersonID = int.TryParse(claims.GetValueOrDefault(ClaimTypes.NameIdentifier), out var id) ? id : null,
                FirstName = claims.GetValueOrDefault(ClaimTypes.Name),
                Role = claims.GetValueOrDefault(ClaimTypes.Role),
                Gender = claims.GetValueOrDefault(ClaimTypes.Gender),
                JoiningDate = claims.GetValueOrDefault("JoiningDate")
            };

        }

        public static void Clear()
        {
            CurrentUserData = null;
        }
    }
}