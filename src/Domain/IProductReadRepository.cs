
using AOPInterceptorWebApplication.Domain.Entities;

namespace AOPInterceptorWebApplication.Domain;

public interface IProductReadRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
}
