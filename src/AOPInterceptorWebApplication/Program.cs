using AOPInterceptorWebApplication.Domain;
using AOPInterceptorWebApplication.Infra.Repositories.ReadRepositories.DataReadRepositories;
using AOPInterceptorWebApplication.Logging;
using AOPInterceptorWebApplication.Services;
using AOPInterceptorWebApplication.Services.Contracts;
using Castle.DynamicProxy;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region [ DI ]

builder.Services.AddSingleton(new ProxyGenerator());
builder.Services.AddScoped<ILoggingInterceptor, LoggingInterceptor>();

builder.Services.AddProxiedScoped<IDataReadRepository, DataReadRepository>();
builder.Services.AddProxiedTransient<IDataServices, DataServices>();

#endregion [ DI ]

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
