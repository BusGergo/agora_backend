using agora_shop.Repositories.IRepositories;
using agora_shop.Services.IServices;
namespace agora_shop.Services;

public class UsersService :  IUsersService
{
    IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }
}