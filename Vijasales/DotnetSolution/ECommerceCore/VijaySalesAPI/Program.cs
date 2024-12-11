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
=======

<<<<<<< HEAD

=======





using Banking.Repositories.Connected;
using Banking.Services;




=======
<<<<<<< HEAD

=======
<<<<<<< HEAD
=======

>>>>>>> e45eaf0e36ee34c83f17b79fc8b8d518271be55e
>>>>>>> 9fcdc4b5d785379b3bf1454a1696e5f49b3f0f84
>>>>>>> 3ec300bf8ce64754610ae48243db12a966af9686
>>>>>>> 5cb31ec77b5792d08c1cbffb46d7aea0ac1a310e
>>>>>>> d896072a549b003f79eccb1ecb8a936f1c61af95
>>>>>>> 9f138423b37ef8986c2a0204305b3bec18594860
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
        policy.WithOrigins("http://localhost:5260", "http://localhost:5284", "http://localhost:5218")  // Allow your frontend's URL
>>>>>>> d896072a549b003f79eccb1ecb8a936f1c61af95
>>>>>>> 9f138423b37ef8986c2a0204305b3bec18594860
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
app.UseCors("AllowLocalhost");
app.UseRouting();
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD


//Register context
>>>>>>> d896072a549b003f79eccb1ecb8a936f1c61af95

var app = builder.Build();

=======
<<<<<<< HEAD
>>>>>>> 3ec300bf8ce64754610ae48243db12a966af9686


>>>>>>> 5cb31ec77b5792d08c1cbffb46d7aea0ac1a310e


var app = builder.Build();


<<<<<<< HEAD
=======










<<<<<<< HEAD


=======
>>>>>>> 3ec300bf8ce64754610ae48243db12a966af9686
>>>>>>> 5cb31ec77b5792d08c1cbffb46d7aea0ac1a310e
app.UseCors("AllowLocalhost");
app.UseRouting();



>>>>>>> 9f138423b37ef8986c2a0204305b3bec18594860
app.UseAuthorization();
app.UseSession();
app.MapControllers();
<<<<<<< HEAD
app.Run();
=======
app.Run();






>>>>>>> d896072a549b003f79eccb1ecb8a936f1c61af95
