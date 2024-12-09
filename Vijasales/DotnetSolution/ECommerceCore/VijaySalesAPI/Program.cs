using Catalog.Repositories;
using Catalog.Repositories.ORM;
using Catalog.Services;

using CRM.Repositories.ORM;
using CRM.Repositories;
using CRM.Services;

using PaymentProcessing.Services;
using PaymentProcessing.Repositories.Connected;


using Banking.Repositories.Connected;
using Banking.Services;

using OrderProcessing.Repositories.Connected;
using OrderProcessing.Services;
using OrderProcessing.Services.Connected;





using Banking.Repositories.Connected;
using Banking.Services;


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
<<<<<<< HEAD
        policy.WithOrigins("http://localhost:5260", "http://localhost:5284", "http://localhost:12890")  // Allow your frontend's URL
=======
        policy.WithOrigins("http://localhost:5260", "http://localhost:5284", "http://localhost:5218")  // Allow your frontend's URL
>>>>>>> e3e864c06bd45e8528a074c18cf4ff00597caa0e
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
builder.Services.AddTransient<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddTransient<IOrderItemService, OrderItemService>();
builder.Services.AddTransient<IOrderService, OrderService>();



builder.Services.AddTransient<IPaymentRepository, PaymentRepository>();
builder.Services.AddTransient<IPaymentServices, PaymentServices>();


builder.Services.AddTransient<IShipmentService, ShipmentService>();
builder.Services.AddTransient<IShipmentRepository, ShipmentRepository>();


builder.Services.AddTransient<ICardRepository, CardRepository>();
builder.Services.AddTransient<ICardService, CardServices>();

builder.Services.AddTransient<IBankRepository, BankRepository>();

builder.Services.AddTransient<IBankService, BankService>();


//Register context

var app = builder.Build();

<<<<<<< HEAD
=======
<<<<<<< HEAD


>>>>>>> ff16f1fcf1ab48bdaa5cce99d6e950f9a0c94232
app.UseCors("AllowLocalhost");
app.UseRouting();
app.UseRouting();

<<<<<<< HEAD
=======




app.UseRouting();
=======
<<<<<<< HEAD
>>>>>>> e3e864c06bd45e8528a074c18cf4ff00597caa0e









<<<<<<< HEAD
app.UseRouting();

app.UseCors("AllowLocalhost");
app.UseRouting();
 



app.UseCors("AllowLocalhost");
app.UseRouting();

=======
>>>>>>> e3e864c06bd45e8528a074c18cf4ff00597caa0e






<<<<<<< HEAD
=======
=======
>>>>>>> 161ff82bb30462960e946923b4c809146cb3f28d
>>>>>>> e3e864c06bd45e8528a074c18cf4ff00597caa0e
app.UseCors("AllowLocalhost");
app.UseRouting();



<<<<<<< HEAD
=======












>>>>>>> e3e864c06bd45e8528a074c18cf4ff00597caa0e
>>>>>>> ff16f1fcf1ab48bdaa5cce99d6e950f9a0c94232
app.UseAuthorization();
app.UseSession();
app.MapControllers();
app.Run();
