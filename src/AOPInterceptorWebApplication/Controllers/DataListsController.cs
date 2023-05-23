using AOPInterceptorWebApplication.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AOPInterceptorWebApplication.Controllers;

[ApiController]
public class DataListsController : ControllerBase
{
    #region Fields
    private readonly IDataServices _dataServices;

    #endregion Fields

    #region Ctor

    public DataListsController(IDataServices dataServices)
    {
        _dataServices = dataServices;
    }

    #endregion Ctor

    [HttpGet("/api/v1/getlistdata")]
    public async ValueTask<IActionResult> GetListDatasAsync()
    {
        var datalist = await _dataServices.GetListDatasAsync();

        return Ok(datalist);
    }

}
