using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace ChamCongVN_BE.Models
{
    public class TokenManager
    {
        private static string Secret = "ERMN05OPLoDvbTTa/QkqLNMI7cPLguaRyHzyg7n5qNBVjQmtBhz4SzYh4NBVCXi3KJHlSXKP+oi2+bXr6CUYTR==";
        public static string GenerateToken(int AccountID, int RoleID, int EmployeeID)
        {
            byte[] key = Convert.FromBase64String(Secret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                      new Claim(ClaimTypes.NameIdentifier, AccountID.ToString()),
                      new Claim(ClaimTypes.NameIdentifier, RoleID.ToString()),
                      new Claim(ClaimTypes.NameIdentifier, EmployeeID.ToString())
                  }),
                Expires = DateTime.UtcNow.AddMinutes(240),
                SigningCredentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }
        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                if (jwtToken == null)
                    return null;
                byte[] key = Convert.FromBase64String(Secret);
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
                SecurityToken securityToken;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token,
                      parameters, out securityToken);
                return principal;
            }
            catch
            {
                return null;
            }
        }
        public static string ValidateToken(string token)
        {
            string username = null;
            ClaimsPrincipal principal = GetPrincipal(token);
            if (principal == null)
                return null;
            ClaimsIdentity identity = null;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException)
            {
                return null;
            }
            Claim usernameClaim = identity.FindFirst(ClaimTypes.Name);
            username = usernameClaim.Value;
            return username;
        }
        public static string ValidateCheck()
        {
            ChamCongVNEntities db = new ChamCongVNEntities();
            // Get Auth header
            var handler = new JwtSecurityTokenHandler();
            string authHeader = HttpContext.Current.Request.Headers["Authorization"];
            if (authHeader != null)
            {
                authHeader = authHeader.Replace("Bearer ", "");
                var jsonToken = handler.ReadToken(authHeader);
                var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
                var claims = tokenS.Claims.ToList();
                // Dòng này để check trong database
                //string accountID = claims[6].Value;
                //var checkDatabase = db.Accounts.Where(x => x.IDUser == Convert.ToInt32(accountID)).FirstOrDefault();
                int getData = Convert.ToInt32(claims[3].Value);
                var infoEmp = db.Employees.Where(x => x.EmployeeID == getData).FirstOrDefault();
                if (infoEmp.PositionID == 1 || infoEmp.PositionID == 2 || infoEmp.PositionID == 3 || infoEmp.PositionID == 4)
                {
                    if (infoEmp.PositionID == 1)
                        return "GD";
                    else if (infoEmp.PositionID == 2)
                        return "QL";
                    else if (infoEmp.PositionID == 3)
                        return "KT";
                    else
                        return "NV";
                }
                else
                    return "Access Denied";
            }
            else
            {
                return "Access Denied";
            }
        }
    }
}