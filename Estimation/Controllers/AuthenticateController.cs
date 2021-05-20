using Estimation.Domain.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Estimation.Domain.models;
using Estimation.Data.Repostitories;

/*
namespace Estimation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController: ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public AuthenticateController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> login([FromBody]LoginRequest login)
        {
            if(login == null)
                return Unauthorized();

            var user = await _userRepo.Authenticate(login.Email, login.Password).ConfigureAwait(true);

            if(user == null)
                return  Unauthorized();

            return Ok(user);
        }


    }
}
*/