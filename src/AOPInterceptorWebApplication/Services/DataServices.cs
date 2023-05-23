using AOPInterceptorWebApplication.Domain;
using AOPInterceptorWebApplication.Services.Contracts;

namespace AOPInterceptorWebApplication.Services;

public class DataServices : IDataServices
{
    #region Fields

    private readonly IDataReadRepository _dataReadRepository;

    #endregion Fields

    #region Ctor

    public DataServices(
        IDataReadRepository ataReadRepository)
    {
        _dataReadRepository = ataReadRepository;
    }

    #endregion Ctor

    #region Implement

    public async Task<List<int>> GetListDatasAsync()
    {
       return await _dataReadRepository.GetListDatasAsync().ConfigureAwait(false);
    }

    #endregion Implement
}
