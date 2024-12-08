using Catalog.Repositories;
using Catalog.Repositories.ORM;
using Catalog.Services;

using CRM.Repositories.ORM;
using CRM.Repositories;
using CRM.Services;

using PaymentProcessing.Services;
using PaymentProcessing.Repositories;
<<<<<<< HEAD
using PaymentProcessing.Repositories.Connected;

using OrderProcessing.Repositories.Connected;
using OrderProcessing.Services;
using OrderProcessing.Services.Connected;

=======
<<<<<<< HEAD
=======
<<<<<<< HEAD

using PaymentProcessing.Repositories.Connected;

>>>>>>> a846a3beef50e0ef8a5ef90fbedf52154ab9e37e

using Banking.Repositories.Connected;
using Banking.Services;
using OrderProcessing.Repositories.Connected;
using OrderProcessing.Services;
using OrderProcessing.Services.Connected;

<<<<<<< HEAD

using Banking.Repositories.Connected;
=======
>>>>>>> a846a3beef50e0ef8a5ef90fbedf52154ab9e37e


using Banking.Repositories.Connected;
using Banking.Services;
using Banking.Repositories.Connected;
=======
>>>>>>> 37ddc07faaa1c18dd7d0182b6964b5fa277c86ac
using PaymentProcessing.Repositories.Connected;

using OrderProcessing.Repositories.Connected;
using OrderProcessing.Services;
using OrderProcessing.Services.Connected;
using Banking.Repositories.Connected;
using Banking.Services;
<<<<<<< HEAD
using OrderProcessing.Repositories.Connected;
using OrderProcessing.Services;
using OrderProcessing.Services.Connected;

<<<<<<< HEAD
using Banking.Repositories.Connected;
using Banking.Services;
using Banking.Repositories.Connected;

=======

=======
using Banking.Repositories.Connected;
using Banking.Services;
using Banking.Repositories.Connected;
>>>>>>> 9b2a796986941dd7555008528c99c9e4b1581233
=======
>>>>>>> 20a940d9cc95b13718582d1a552a7ac566d38ac5
>>>>>>> 37ddc07faaa1c18dd7d0182b6964b5fa277c86ac
>>>>>>> a846a3beef50e0ef8a5ef90fbedf52154ab9e37e
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

// Register IDataRepository 

builder.Services.AddTransient<IUserDataRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();


builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();


builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();


builder.Services.AddTransient<IPaymentRepository, PaymentRepository>();
builder.Services.AddTransient<IPaymentServices, PaymentServices>();


builder.Services.AddTransient<IShipmentRepository, ShipmentRepository>();
builder.Services.AddTransient<IShipmentService, ShipmentService>();


builder.Services.AddTransient<ICardRepository, CardRepository>();
builder.Services.AddTransient<ICardService, CardServices>();


//Register context

var app = builder.Build();

<<<<<<< HEAD
=======
<<<<<<< HEAD

>>>>>>> a846a3beef50e0ef8a5ef90fbedf52154ab9e37e
app.UseCors("AllowLocalhost");
app.UseRouting();
app.UseRouting();

app.UseCors("AllowLocalhost");

app.UseRouting();

app.UseCors("AllowLocalhost");

app.UseRouting();

<<<<<<< HEAD

app.UseCors("AllowLocalhost");
app.UseRouting();


=======
=======
<<<<<<< HEAD



=======
// Configure the HTTP request pipeline.
>>>>>>> 20a940d9cc95b13718582d1a552a7ac566d38ac5
>>>>>>> 37ddc07faaa1c18dd7d0182b6964b5fa277c86ac
app.UseCors("AllowLocalhost");
app.UseRouting();

>>>>>>> a846a3beef50e0ef8a5ef90fbedf52154ab9e37e
app.UseAuthorization();
app.UseSession();
app.MapControllers();
app.Run();
