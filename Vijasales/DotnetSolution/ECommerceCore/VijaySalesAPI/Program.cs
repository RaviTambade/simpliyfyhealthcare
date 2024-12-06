using Catalog.Repositories;
using Catalog.Repositories.Connected;
using Catalog.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddCors();

 
builder.Services.AddCors();

builder.Services.AddControllers();
builder.Services.AddDistributedMemoryCache();  // This is the key line for in-memory cache

// Add session service
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".ShoppingCart.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(600);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Adding services which are needed in the future
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// Register IDataRepository and ProductRepository for dependency injection
builder.Services.AddTransient<IProductRepository, ProductRepository>();

// Register ProductService (already done in your code)
builder.Services.AddTransient<IProductService, ProductService>();

var app = builder.Build();
// Configure the HTTP request pipeline.


app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());


 
app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();
app.UseSession();
app.MapControllers();
app.Run();
