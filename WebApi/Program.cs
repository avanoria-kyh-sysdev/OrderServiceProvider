using Microsoft.EntityFrameworkCore;
using WebApi.Data.Contexts;
using WebApi.Grpc;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("OrderDatabase")));
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddGrpcClient<CustomerGrpcService.CustomerGrpcServiceClient>(x =>
{
    x.Address = new Uri(builder.Configuration["GrpcSettings:CustomerServiceProvider"]!);
});


builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
