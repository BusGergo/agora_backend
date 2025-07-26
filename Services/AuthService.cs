using agora_shop.Data;
using agora_shop.DTO.User;
using agora_shop.Models;
using agora_shop.Repositories.IRepositories;
using agora_shop.Results;
using agora_shop.Services.IServices;
using agora_shop.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace agora_shop.Services;

public class AuthService : IAuthService
{
    IUsersRepository _usersRepository;
    IConfiguration _config;

    public AuthService(IUsersRepository repository, IConfiguration configuration)
    {
        _usersRepository = repository;
        _config = configuration;
    }
    
    public ServiceResult<string> LoginEmail(UserLoginEmailDTO dto)
    {
        var user = _usersRepository.GetUserByEmail(dto.Email);
        if (user == null)
            return ServiceResult<string>.Failure("User not found");

        var hasher = new PasswordHasher<User>();
        var result = hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
        if (result == PasswordVerificationResult.Failed)
            return ServiceResult<string>.Failure("Invalid password");

        var token = JwtTokenGenerator.GenerateJwtToken(user, _config);
        return ServiceResult<string>.Ok(token);
    }

    public ServiceResult<string> LoginPhoneNumber(UserLoginPhoneDTO dto)
    {
        var user = _usersRepository.GetUserByPhoneNumber(dto.PhoneNumber);
        if (user == null)
            return ServiceResult<string>.Failure("User not found");
        
        var hasher = new PasswordHasher<User>();
        var result = hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
        if (result == PasswordVerificationResult.Failed)
            return ServiceResult<string>.Failure("Invalid password");
        
        var token = JwtTokenGenerator.GenerateJwtToken(user, _config);
        return ServiceResult<string>.Ok(token);
    }

    public ServiceResult<string> RegisterUser(UserRegisterDTO dto)
    {
        if(dto.Password != dto.ConfirmPassword)
            return ServiceResult<string>.Failure("Passwords do not match");
        
        var hasher = new PasswordHasher<User>();
        var newUser = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PasswordHash = hasher.HashPassword(null, dto.Password),
            PhoneNumber = dto.PhoneNumber,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        
        _usersRepository.CreateUser(newUser);
        return ServiceResult<string>.Ok("User created");
    }
}