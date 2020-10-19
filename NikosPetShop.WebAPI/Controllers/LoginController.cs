using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NikosPetShop.Core.ApplicationServices;
using NikosPetShop.Core.DomainServices;
using NikosPetShop.Core.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NikosPetShop.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private IUserService UserService;
        private IAuthenticationHelper AuthenticationHelper;

        public LoginController(IUserService userService, IAuthenticationHelper authenticationHelper)
        {
            UserService = userService;
            AuthenticationHelper = authenticationHelper;
        }

        [HttpPost]
        public ActionResult Login([FromBody] LoginInputModel loginInputModel)
        {
            try
            {
                User foundUser = UserService.Login(loginInputModel);

                if (foundUser == null)
                {
                    return Unauthorized();
                }

                var tokenString = AuthenticationHelper.GenerateJWTToken(foundUser);

                return Ok(new
                {
                    username = loginInputModel.Username,
                    token = tokenString,
                });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized();
            }

        }
    }

}
