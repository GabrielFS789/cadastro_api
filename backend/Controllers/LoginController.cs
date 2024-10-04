using backend.DTOs;
using backend.Services;
using backend.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public LoginController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]

        public async Task<ActionResult<Array>> GetToken(LoginDTO loginDTO)
        {
            var token = await _tokenService.GerarToken(loginDTO);
            if(token is null)
                return Unauthorized();
            return Ok(new { token });
        }

    }
}
