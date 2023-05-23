namespace AOPInterceptorWebApplication.Services.Contracts;

public interface IDataServices
{
    Task<List<int>> GetListDatasAsync();

}
