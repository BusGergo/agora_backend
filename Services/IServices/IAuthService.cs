using agora_shop.DTO.User;
using agora_shop.Results;
using Microsoft.AspNetCore.Mvc;

namespace agora_shop.Services.IServices;

public interface IAuthService
{
    public ServiceResult<string> LoginEmail(UserLoginEmailDTO dto);
    public ServiceResult<string> LoginPhoneNumber(UserLoginPhoneDTO dto);
    public ServiceResult<string> RegisterUser(UserRegisterDTO dto);
}