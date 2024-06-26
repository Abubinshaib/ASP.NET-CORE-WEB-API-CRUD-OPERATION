using ASP.NET_CORE_WEB_API_CRUD_OPERATION.Configurations;
using ASP.NET_CORE_WEB_API_CRUD_OPERATION.Contracts;
using ASP.NET_CORE_WEB_API_CRUD_OPERATION.Data.Models;
using ASP.NET_CORE_WEB_API_CRUD_OPERATION.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Configure the ConnectionString and DbContext class
builder.Services.AddDbContext<GeeksStoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EFCoreDBConnection"));
});


builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddAutoMapper(typeof(MapperConfig));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
