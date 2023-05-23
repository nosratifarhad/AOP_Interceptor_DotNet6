using AOPInterceptorWebApplication.Domain;

namespace AOPInterceptorWebApplication.Infra.Repositories.ReadRepositories.DataReadRepositories;

public class DataReadRepository : IDataReadRepository
{
    public Task<List<int>> GetListDatasAsync()
    {
        return Task.Run(() => new List<int>());
    }
}
