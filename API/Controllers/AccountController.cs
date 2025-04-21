using System;
using API.DTOs;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController(SignInManager<User> signInManager) : BaseApiController
    {
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterDto registerDto)
        {
            var user = new User
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                DisplayName = registerDto.DisplayName,
            };

            var result = await signInManager.UserManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("Register", error.Description);
            }

            return ValidationProblem();
        }

        [AllowAnonymous]
        [HttpGet("user-info")]
        public async Task<ActionResult> GetUserInfo()
        {
            if (User.Identity?.IsAuthenticated == false) return NoContent();

            var user = await signInManager.UserManager.GetUserAsync(User);
            if (user == null) return NotFound();

            return Ok(new
            {
                user.DisplayName,
                user.Email,
                user.Id,
                user.UserName,
            });
        }

        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return NoContent();
        }
    }
}