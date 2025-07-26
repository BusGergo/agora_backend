using agora_shop.DTO.User;
using agora_shop.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace agora_shop.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    IAuthService _authService;
    
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("loginEmail")]
    public IActionResult LoginEmail([FromBody] UserLoginEmailDTO dto)
    {
        var res = _authService.LoginEmail(dto);
        if (!res.Success)
            return Unauthorized(new {error = res.ErrorMessage});
        
        return Ok(res.Data);
    }

    [HttpPost("loginPhone")]
    public IActionResult LoginPhoneNumber(UserLoginPhoneDTO dto)
    {
        var res = _authService.LoginPhoneNumber(dto);
        if (!res.Success)
            return Unauthorized(new {error = res.ErrorMessage});
        
        return Ok(res.Data);
    }

    [HttpPost("register")]
    public IActionResult Register(UserRegisterDTO dto)
    {
        var res = _authService.RegisterUser(dto);
        if (!res.Success)
            return Unauthorized(new {error = res.ErrorMessage});
        
        return Ok(res.Data);
    }
}