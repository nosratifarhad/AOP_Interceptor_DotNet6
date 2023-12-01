using AOPInterceptorWebApplication.Domain;
using AOPInterceptorWebApplication.Domain.Entities;
using AOPInterceptorWebApplication.Dtos;
using AOPInterceptorWebApplication.Services.Contracts;

namespace AOPInterceptorWebApplication.Services;

public class ProductServices : IProductServices
{
    #region Fields

    private readonly IProductReadRepository _productReadRepository;

    #endregion Fields

    #region Ctor

    public ProductServices(IProductReadRepository productReadRepository)
    {
        _productReadRepository = productReadRepository;
    }

    #endregion Ctor

    #region Implement

    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        var products = await _productReadRepository.GetProductsAsync().ConfigureAwait(false);

        var productsDto = ConvertProductToProductDto(products);

        return productsDto;
    }

    #endregion Implement

    #region [ Private ]

    private IEnumerable<ProductDto> ConvertProductToProductDto(IEnumerable<Product> products)
    {
        List<ProductDto> productDtos = new List<ProductDto>();
        foreach (var item in products)
            productDtos.Add(new ProductDto()
            {
                Id = item.Id,
                Name = item.Name,
            });

        return productDtos;
    }
    #endregion [ private ]

}
