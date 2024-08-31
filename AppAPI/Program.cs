using AppAPI.Repositories;
using AppAPI.Repositories.EntityInterface;
using AppAPI.Repositories.EntityRepos;
using AppAPI.Service;
using AppAPI.Service.EntityInterface;
using AppAPI.Service.EntityServices;
using AppData.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TStoreDb>();


builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IBaseServices<>), typeof(BaseServices<>));

builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IBillRepository, BillRepositories>();
builder.Services.AddScoped<ICartDetailRepository, CartDetailRepositories>();
builder.Services.AddScoped<ICartRepository, CartRepositories>();
builder.Services.AddScoped<IProductDetailRepository, ProductDetailRepositories>();
builder.Services.AddScoped<IProductRepository, ProductRepositories>();

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
