using Estimation.Domain.interfaces;
using Estimation.Domain.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

using Microsoft.Extensions.Configuration;

/*
namespace Estimation.Data.Repostitories
{
    public class UserRepository : IUserRepository
    {

        //private readonly RepositoryContext _repoDbContext;
        private readonly AppSetting _appSetting;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(IOptions<AppSetting> appSetting,SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {

            //_repoDbContext = repoDbcontext;
            _appSetting = appSetting.Value;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public Task<int> AddUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> Authenticate(string Email, string Password)
        {
            //var user = _repoDbContext.User.SingleOrDefault(x => x.UserName == username && x.Password == password);
            ApplicationUser _applicationUser = null;

            var user = await _signInManager.PasswordSignInAsync(Email, Password, false, false);

            if (user.Succeeded) 
            { 

                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == Email);

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSetting.Secret);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                            new Claim(ClaimTypes.Name, appUser.Id.ToString())
                    }),

                    Expires = DateTime.UtcNow.AddMinutes(3),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                appUser.Token = tokenHandler.WriteToken(token);

                

                return appUser;
            }

            

            return _applicationUser;


        }
    }
}
*/