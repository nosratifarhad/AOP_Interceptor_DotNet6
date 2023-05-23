using AOPInterceptorWebApplication.InputModels.ProductInputModels;
using AOPInterceptorWebApplication.ViewModels.ProductViewModels;

namespace AOPInterceptorWebApplication.Services.Contracts
{
    public interface IProductServices
    {
        Task<int> CreateProductAsync(CreateProductInputModel inputModel);

        Task UpdateProductAsync(UpdateProductInputModel inputModel);

        Task DeleteProductAsync(int productId);

        ValueTask<ProductViewModel> GetProductAsync(int productId);

        ValueTask<IEnumerable<ProductViewModel>> GetProductsAsync();
    }
}
