using Catalog.Repositories;
using Catalog.Repositories.Connected;
using Catalog.Services;
<<<<<<< HEAD
using CRM.Repositories.ORM;
using CRM.Repositories;
using CRM.Services;
=======
using PaymentProcessing.Services;
using PaymentProcessing.Repositories;
using PaymentProcessing.Repositories.Connected;
>>>>>>> d1dc1443681bbd5dc44a04ee128c9ae991492135

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
<<<<<<< HEAD
builder.Services.AddCors();

=======


builder.Services.AddCors();

 
builder.Services.AddCors();

>>>>>>> d1dc1443681bbd5dc44a04ee128c9ae991492135
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
<<<<<<< HEAD
builder.Services.AddTransient<IDataRepository, ProductRepository>();
builder.Services.AddTransient<IUserDataRepository, UserRepository>();
=======
builder.Services.AddTransient<IProductRepository, ProductRepository>();

>>>>>>> d1dc1443681bbd5dc44a04ee128c9ae991492135
// Register ProductService (already done in your code)
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IUserService, UserService>();


builder.Services.AddTransient<IPaymentRepository, PaymentRepository>();

builder.Services.AddTransient<IPaymentServices, PaymentServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
<<<<<<< HEAD

app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
=======


app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());


 
app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

>>>>>>> d1dc1443681bbd5dc44a04ee128c9ae991492135
app.UseAuthorization();
app.UseSession();
app.MapControllers();
app.Run();
