using Catalog.Repositories;
using Catalog.Repositories.ORM;
using Catalog.Services;
using CRM.Repositories.ORM;
using CRM.Repositories;
using CRM.Services;
using PaymentProcessing.Services;
using PaymentProcessing.Repositories;
using PaymentProcessing.Repositories.Connected;
using OrderProcessing.Repositories.Connected;
using OrderProcessing.Services;
using OrderProcessing.Services.Connected;

using Shipment.Repositories;
using Shipment.Repositories.ORM;
using Shipment.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();

builder.Services.AddControllers();
builder.Services.AddDistributedMemoryCache();  // This is the key line for in-memory cache

// Add session service
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "ShoppingCart.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(600);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.Cookie.SecurePolicy = CookieSecurePolicy.None;

});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:5260", "http://localhost:5284")  // Allow your frontend's URL
              .AllowAnyHeader()  // Allow any headers
              .AllowAnyMethod()  // Allow any HTTP methods (GET, POST, etc.)
              .AllowCredentials();  // Allow cookies and credentials to be sent
    });
});
// Adding services which are needed in the future
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
// Register IDataRepository and ProductRepository for dependency injection

builder.Services.AddTransient<IUserDataRepository, UserRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();


// Register ProductService (already done in your code)
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IPaymentRepository, PaymentRepository>();
builder.Services.AddTransient<IPaymentServices, PaymentServices>();
builder.Services.AddTransient<IOrderService, OrderService>();

builder.Services.AddTransient<IShipmentRepository, ShipmentRepository>();
builder.Services.AddTransient<IShipmentService, ShipmentService>();

var app = builder.Build();

<<<<<<< HEAD
// Configure the HTTP request pipeline.


app.UseCors("AllowLocalhost");




app.UseRouting();









app.UseRouting();

app.UseCors("AllowLocalhost");

app.UseRouting();


app.UseCors("AllowLocalhost");

app.UseRouting();



app.UseCors("AllowLocalhost");

app.UseRouting();

=======
>>>>>>> 3e7d74c60a3b4e3520b607f1dfac3c64b7cb8b1c
app.UseCors("AllowLocalhost");
app.UseRouting();


<<<<<<< HEAD

=======
>>>>>>> 3e7d74c60a3b4e3520b607f1dfac3c64b7cb8b1c
app.UseAuthorization();
app.UseSession();
app.MapControllers();
app.Run();
