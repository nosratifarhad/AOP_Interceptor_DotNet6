using AOPInterceptorWebApplication.Dtos;

namespace AOPInterceptorWebApplication.Services.Contracts;

public interface IProductServices
{
    Task<IEnumerable<ProductDto>> GetProductsAsync();

}
