using agora_shop.Data;
using agora_shop.DTO.User;
using agora_shop.Models;
using agora_shop.Services.IServices;
using agora_shop.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace agora_shop.Controllers;

public class AuthController : ControllerBase
{
    IAuthService _authService;
    
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("loginEmail")]
    public IActionResult LoginEmail(UserLoginEmailDTO dto)
    {
        var res = _authService.LoginEmail(dto);
        if (!res.Success)
            return Unauthorized(new {error = res.ErrorMessage});
        
        return Ok(res.Data);
    }

    [HttpPost("LoginPhone")]
    public IActionResult LoginPhoneNumber(UserLoginPhoneDTO dto)
    {
        var res = _authService.LoginPhoneNumber(dto);
        if (!res.Success)
            return Unauthorized(new {error = res.ErrorMessage});
        
        return Ok(res.Data);
    }
}