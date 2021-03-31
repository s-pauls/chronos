using Chronos.App.Models;
using Chronos.Domain.Entities;
using Chronos.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Chronos.Domain.Entities.User;

namespace Chronos.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(
            ILogger<UserController> logger,
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<User> GetUser()
        {
            if (HttpContext.User.Identity?.IsAuthenticated == true)
            {
                try
                {
                    var accessToken = HttpContext.User.Claims.FirstOrDefault(x => x.Type == nameof(Token.AccessToken))?.Value;

                    return await _userService.Get(accessToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "User {Name} is not authorized.", HttpContext.User.Identity.Name);
                }
            }

            return null;
        }


        [HttpPost("signin")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] Token token)
        {
            try
            {
                User user;
                try
                {
                    user = await _userService.Get(token.AccessToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unable to SingIn.");

                    return BadRequest("Invalid Access Token.");
                }

                var expiration = DateTime.TryParse(token.Expiration, out var expirationDate) ? expirationDate : DateTime.Today.AddMonths(1);

                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.DisplayName),
                    new Claim(nameof(Token.AccessToken), token.AccessToken),
                    new Claim(nameof(Domain.Entities.User.User.Id), user.Id)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = expiration
                });

                return Ok(user);
            }
            catch
            {
                return BadRequest("Invalid Access Token.");
            }
        }

        [HttpPost("signout")]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok();
        }
    }
}
