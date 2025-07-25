using agora_shop.Repositories;
using agora_shop.Repositories.IRepositories;
using agora_shop.Services.IServices;

namespace agora_shop.Services;

public class ProductsService :  IProductsService
{
    IProductsRepository _productsRepository;

    public ProductsService(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }
}