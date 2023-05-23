using AOPInterceptorWebApplication.Domain;
using AOPInterceptorWebApplication.Infra.Repositories.ReadRepositories.DataReadRepositories;
using AOPInterceptorWebApplication.Services;
using AOPInterceptorWebApplication.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region [ DI ]

builder.Services.AddScoped<IDataReadRepository, DataReadRepository>();
builder.Services.AddScoped<IDataServices, DataServices>();

#endregion [ DI ]

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
