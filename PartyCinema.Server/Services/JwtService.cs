using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PartyCinema.Server.Services
{
    public class JwtService
    {
        private string secureKey = "@@277772002426Kar26$#@#@@Step8###@@my@@my$$my2";

        public string Generate(string login, int userId)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secureKey));
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(credentials);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Iss, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, ((int)DateTime.Now.AddDays(2).Subtract(DateTime.UnixEpoch).TotalSeconds).ToString(System.Globalization.CultureInfo.InvariantCulture)),
                new Claim(JwtRegisteredClaimNames.Iat, ((int)DateTime.Now.Subtract(DateTime.UnixEpoch).TotalSeconds).ToString(System.Globalization.CultureInfo.InvariantCulture)),
                new Claim("login", login),
            };

            var payload = new JwtPayload(claims);
            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public JwtSecurityToken? Verify(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(secureKey);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ValidateIssuer = false
                }, out SecurityToken validatedToken);

                return (JwtSecurityToken)validatedToken;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
