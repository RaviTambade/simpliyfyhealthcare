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


<<<<<<< HEAD



=======
<<<<<<< HEAD

=======
>>>>>>> 3e3c6050d1e1936886f42a5a5c2b4994c8f8a699
>>>>>>> c1f93641034418c03e3e45c12037a357dd8902e3
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
<<<<<<< HEAD
        policy.WithOrigins("http://localhost:5260", "http://localhost:5284", "http://localhost:12890");  // Allow your frontend's URL

        policy.WithOrigins("http://localhost:5260", "http://localhost:5284", "http://localhost:5218")  // Allow your frontend's URL

=======
<<<<<<< HEAD

        policy.WithOrigins("http://localhost:5260", "http://localhost:5284", "http://localhost:12890")  // Allow your frontend's URL


=======
        policy.WithOrigins("http://localhost:5260", "http://localhost:5284", "http://localhost:5218")  // Allow your frontend's URL
>>>>>>> e0234d6a7594804d1649daed26c9b112e6dc3e42
>>>>>>> 3e3c6050d1e1936886f42a5a5c2b4994c8f8a699
>>>>>>> c1f93641034418c03e3e45c12037a357dd8902e3
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
<<<<<<< HEAD


var app = builder.Build();


=======
//Register context

var app = builder.Build();

<<<<<<< HEAD
app.UseCors("AllowLocalhost");





























=======
<<<<<<< HEAD


app.UseCors("AllowLocalhost");
app.UseRouting();
app.UseRouting();
app.UseRouting();
app.UseRouting();
app.UseCors("AllowLocalhost");
app.UseRouting();
app.UseCors("AllowLocalhost");
app.UseRouting();
app.UseCors("AllowLocalhost");
app.UseRouting();
=======
>>>>>>> e0234d6a7594804d1649daed26c9b112e6dc3e42
app.UseCors("AllowLocalhost");
app.UseRouting();

>>>>>>> 3e3c6050d1e1936886f42a5a5c2b4994c8f8a699
>>>>>>> c1f93641034418c03e3e45c12037a357dd8902e3
app.UseAuthorization();
app.UseSession();
app.MapControllers();
app.Run();






