using Catalog.Repositories;
using Catalog.Repositories.Connected;
using Catalog.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
<<<<<<< HEAD

builder.Services.AddCors();

=======
 
builder.Services.AddCors();
>>>>>>> 903df9b73efdd6bdf4f32778b23a1d4a4d4d8c7f
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
builder.Services.AddTransient<IDataRepository, ProductRepository>();

// Register ProductService (already done in your code)
builder.Services.AddTransient<IProductService, ProductService>();

var app = builder.Build();
// Configure the HTTP request pipeline.
<<<<<<< HEAD

app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

=======
 
app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
>>>>>>> 903df9b73efdd6bdf4f32778b23a1d4a4d4d8c7f
app.UseAuthorization();
app.UseSession();
app.MapControllers();
app.Run();
