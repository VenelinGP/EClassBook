namespace EClassBook.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Data.Contracts;
    using Common.Models;
    using ViewModels;
    using Model;
    using Data;
    using Common.Infrastructure.Core;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authentication.Cookies;

    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IMembershipService membershipService;
        private readonly IUserRepository userRepository;
        private readonly ILoggingRepository loggingRepository;

        public AccountController(IMembershipService membershipService,
            IUserRepository userRepository,
            ILoggingRepository errorRepository)
        {
            this.membershipService = membershipService;
            this.userRepository = userRepository;
            loggingRepository = errorRepository;
        }


        [HttpPost("authenticate")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel user)
        {
            IActionResult result = new ObjectResult(false);
            GenericResult authenticationResult = null;

            try
            {
                MembershipContext userContext = membershipService.ValidateUser(user.Username, user.Password);

                if (userContext.User != null)
                {
                    Role roles = userRepository.GetUserRoles(user.Username);
                    List<Claim> claims = new List<Claim>();
                    Claim claim = new Claim(ClaimTypes.Role, "Admin", ClaimValueTypes.String, user.Username);
                    claims.Add(claim);
                    await HttpContext.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)),
                        new Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties { IsPersistent = user.RememberMe });

                    authenticationResult = new GenericResult()
                    {
                        Succeeded = true,
                        Message = "Authentication succeeded"
                    };
                }
                else
                {
                    authenticationResult = new GenericResult()
                    {
                        Succeeded = false,
                        Message = "Authentication failed"
                    };
                }
            }
            catch (Exception ex)
            {
                authenticationResult = new GenericResult()
                {
                    Succeeded = false,
                    Message = ex.Message
                };

                loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedOn = DateTime.Now });
                loggingRepository.Commit();
            }

            result = new ObjectResult(authenticationResult);
            return result;
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await HttpContext.Authentication.SignOutAsync("Cookies");
                return Ok();
            }
            catch (Exception ex)
            {
                loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedOn = DateTime.Now });
                loggingRepository.Commit();

                return BadRequest();
            }

        }

        [Route("register")]
        [HttpPost]
        public IActionResult Register([FromBody] RegistrationViewModel user)
        {
            IActionResult result = new ObjectResult(false);
            GenericResult registrationResult = null;

            try
            {
                if (ModelState.IsValid)
                {
                    User createUser = membershipService.CreateUser(user.Username, user.FirstName, user.LastName, user.Email, user.Password,  1 );

                    if (createUser != null)
                    {
                        registrationResult = new GenericResult()
                        {
                            Succeeded = true,
                            Message = "Registration succeeded"
                        };
                    }
                }
                else
                {
                    registrationResult = new GenericResult()
                    {
                        Succeeded = false,
                        Message = "Invalid fields."
                    };
                }
            }
            catch (Exception ex)
            {
                registrationResult = new GenericResult()
                {
                    Succeeded = false,
                    Message = ex.Message
                };

                loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedOn = DateTime.Now });
                loggingRepository.Commit();
            }

            result = new ObjectResult(registrationResult);
            return result;
        }
    }
}
