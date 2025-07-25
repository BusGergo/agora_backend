using agora_shop.Data;
using agora_shop.Models;
using agora_shop.Repositories.IRepositories;

namespace agora_shop.Repositories;

public class UsersRepository :  IUsersRepository
{
    private readonly AppDbContext _context;

    public UsersRepository(AppDbContext context)
    {
        _context = context;
    }

    public User? GetUserByEmail(string targetEmail)
    {
        return _context.Users.FirstOrDefault(u => u.Email == targetEmail);
    }

    public User? GetUserByPhoneNumber(string targetPhoneNumber)
    {
        return _context.Users.FirstOrDefault(u => u.PhoneNumber == targetPhoneNumber);
    }
}