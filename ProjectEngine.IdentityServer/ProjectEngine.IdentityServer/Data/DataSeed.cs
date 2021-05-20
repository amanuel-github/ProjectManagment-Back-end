
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using AuthServer.Infrastructure.Data.Identity;

namespace AuthServer.Data
{
    public class DataSeed
    {
       
        public async static void SeedData(UserManager<AppUser> _userManager)
        {
            
            if (!_userManager.Users.Any())
            {
                AppUser user = new AppUser
                {

                    
                    UserName = "saytoyirga@gmail.com",
                    Email = "saytoyirga@gmail.com",
                    Name = "Name"


                };

                 var createUser =  await _userManager.CreateAsync(user, "password").ConfigureAwait(true);

                var isCreated = createUser.Succeeded;
                var error = createUser.Errors;
                var ret = createUser.ToString();

            }



        }
  }
}
