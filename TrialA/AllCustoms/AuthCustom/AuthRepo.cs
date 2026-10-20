using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrialA.DTOs.AuthDTOs;
using TrialA.GenaricRepos;
using TrialA.Models;

namespace TrialA.AllCustoms.AuthCustom
{
    public class AuthRepo : GenaricRepo<User> , IAuthRepo
    {
        private readonly Context _context;
        private readonly IConfiguration configuration;
        public AuthRepo(Context context , IConfiguration c) : base(context) 
        {
            _context = context;
            configuration = c;
        }

        public async Task<string> Login(LoginDTOs dto)
        {
            var e = await _context.users.Where(i => i.Email == dto.Email).FirstOrDefaultAsync();
            if (e == null)
            {
                throw new Exception();
            }
            if(e.PassWord == dto.PassWord)
            {
                return Tokenn(e);
            }
            return null;
        }



        public async Task<bool> Register(RegisterDTOs dto)
        {
            if(dto.Role == "Admin")
            {
                throw new Exception();
            }
            return true;
        }










        private string Tokenn(User u)
        {
            var Calimas = new List<Claim>() {
                new Claim("Name" , u.FullName),
                new Claim("Email",u.Email),
                new Claim(ClaimTypes.Role, u.Role)

            };
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
            var signingCredentialss = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var t = new JwtSecurityToken(
                issuer: configuration["JWT:issuer"],
                audience: configuration["JWT:Audience"],
                claims: Calimas,
                expires: DateTime.Now.AddHours(Convert.ToDouble(configuration["JWT:expireDateInHour"])),
                signingCredentials: signingCredentialss

            );
            var y = new JwtSecurityTokenHandler().WriteToken(t);
            return y;

        }
    }
}
