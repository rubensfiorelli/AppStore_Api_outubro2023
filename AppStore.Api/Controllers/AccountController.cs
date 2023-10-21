using AppStore.Application.DTOs.Input;
using AppStore.Application.Interfaces;
using AppStore.Application.Services;
using AppStore.Domain.Extensions;
using AppStore.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace AppStore.Api.Controllers
{
    [Authorize]
    [Route("v1")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly IUserService _userService;

        public AccountController(TokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("accounts")]
        public async Task<IActionResult> Post(UserDtoCreate model)
        {
            try
            {                
                if (!ModelState.IsValid)
                    return BadRequest(new Notification<string>(ModelState.GetErrors()));

                await _userService.Add(model);

                return Ok(new Notification<dynamic>(model.Email, model.PasswordHash));

            }
            catch (DbUpdateException)
            {
                return StatusCode(409, new Notification<string>("Usuário já cadastrado"));
            }
            catch
            {
                return StatusCode(500, new Notification<string>("Erro interno no servidor"));
            }

        }

        [AllowAnonymous]
        [HttpPost("accounts/logon")]
        public async Task<IActionResult> Logon(LogonDto model, CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Notification<string>(ModelState.GetErrors()));

            var existing = await _userService.GetUserEmail(model.Email, ct);

            if (existing is null)
                return StatusCode(401, new Notification<string>("Usuário / Senha inválidos"));

            if (!PasswordHasher.Verify(existing.Password, model.Password))
                return StatusCode(401, new Notification<string>("Usuário / Senha inválidos"));

            try
            {
                var token = _tokenService.GenerateToken(existing);

                return Ok(new Notification<string>(token, null));
            }
            catch
            {
                return StatusCode(500, new Notification<string>("Internal Server error"));
            }



        }
    }
}
