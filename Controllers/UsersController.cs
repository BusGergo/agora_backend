using agora_shop.Services.IServices;

namespace agora_shop.Controllers;

public class UsersController
{
    IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }
}