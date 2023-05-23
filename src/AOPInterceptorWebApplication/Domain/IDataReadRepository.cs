
namespace AOPInterceptorWebApplication.Domain;

public interface IDataReadRepository
{
    Task<List<int>> GetListDatasAsync();
}
