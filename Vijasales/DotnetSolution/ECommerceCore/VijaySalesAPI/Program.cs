using Catalog.Repositories;
using Catalog.Repositories.ORM;
using Catalog.Services;
using CRM.Repositories.ORM;
using CRM.Repositories;
using CRM.Services;
using PaymentProcessing.Services;
using PaymentProcessing.Repositories;
using PaymentProcessing.Repositories.Connected;
<<<<<<< HEAD
using OrderProcessing.Repositories.Connected;
using OrderProcessing.Services;
using OrderProcessing.Services.Connected;
=======
using Shipment.Repositories;
using Shipment.Repositories.ORM;
using Shipment.Services;
>>>>>>> 87a770e6a18280fbf28f3c09e974010ce5f91f5f

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();
<<<<<<< HEAD
=======

>>>>>>> 43bbecea692f39f5dd0cc61ee0cd468d44b5feda
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
        policy.WithOrigins("http://localhost:5284")  // Allow your frontend's URL
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

// Configure the HTTP request pipeline.
<<<<<<< HEAD
app.UseCors("AllowLocalhost");
app.UseRouting();
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 5b5df5b5acbb51f09e99850b90fecf21fd86476c

app.UseCors("AllowLocalhost");

<<<<<<< HEAD
=======

<<<<<<< HEAD

app.UseRouting();








=======
app.UseRouting();

>>>>>>> 5b5df5b5acbb51f09e99850b90fecf21fd86476c
>>>>>>> 87a770e6a18280fbf28f3c09e974010ce5f91f5f
>>>>>>> 43bbecea692f39f5dd0cc61ee0cd468d44b5feda
app.UseCors("AllowLocalhost");
app.UseRouting();
<<<<<<< HEAD
=======


<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
=======
>>>>>>> 43bbecea692f39f5dd0cc61ee0cd468d44b5feda
app.UseCors("AllowLocalhost");
app.UseRouting();
<<<<<<< HEAD
=======
>>>>>>> 39b54060ef2dfba8e3f5c219c6aec8b4c1cb01ab
>>>>>>> 5b5df5b5acbb51f09e99850b90fecf21fd86476c
>>>>>>> 87a770e6a18280fbf28f3c09e974010ce5f91f5f
>>>>>>> 43bbecea692f39f5dd0cc61ee0cd468d44b5feda
app.UseAuthorization();
app.UseSession();
app.MapControllers();
app.Run();
