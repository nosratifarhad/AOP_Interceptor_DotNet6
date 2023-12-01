using AOPInterceptorWebApplication.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AOPInterceptorWebApplication.Controllers;

[ApiController]
public class ProductsController : ControllerBase
{
    #region Fields
    private readonly IProductServices _dataServices;

    #endregion Fields

    #region Ctor

    public ProductsController(IProductServices dataServices)
    {
        _dataServices = dataServices;
    }

    #endregion Ctor

    [HttpGet("/api/v1/Products/get-product-list")]
    public async ValueTask<IActionResult> GetProductsAsync()
    {
        var products = await _dataServices.GetProductsAsync();

        return Ok(products);
    }

}
