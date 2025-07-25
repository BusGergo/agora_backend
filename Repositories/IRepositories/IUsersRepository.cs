using agora_shop.Models;

namespace agora_shop.Repositories.IRepositories;

public interface IUsersRepository
{
    public User GetUserByEmail(string targetEmail);
    public User GetUserByPhoneNumber(string targetPhoneNumber);
}