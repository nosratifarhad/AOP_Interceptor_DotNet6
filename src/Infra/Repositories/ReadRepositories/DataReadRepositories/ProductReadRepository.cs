using AOPInterceptorWebApplication.Domain;
using AOPInterceptorWebApplication.Domain.Entities;

namespace AOPInterceptorWebApplication.Infra.Repositories.ReadRepositories.DataReadRepositories;

public class ProductReadRepository : IProductReadRepository
{
    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await Task.FromResult(new List<Product>()
            {
                new Product(1,"Test_1"),
                new Product(2,"Test_2")
            });
    }
}
