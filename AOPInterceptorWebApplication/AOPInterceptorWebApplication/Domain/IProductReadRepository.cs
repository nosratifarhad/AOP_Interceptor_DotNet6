using AOPInterceptorWebApplication.Domain.Entitys;

namespace AOPInterceptorWebApplication.Domain
{
    public interface IProductReadRepository
    {
        Task<Product> GetProductAsync(int productId);

        Task<IEnumerable<Product>> GetProductsAsync();

        Task<bool> IsExistProductAsync(int productId);
    }
}
