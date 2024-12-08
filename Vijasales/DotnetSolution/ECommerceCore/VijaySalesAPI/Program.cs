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
<<<<<<< HEAD

=======
>>>>>>> 1c3e562c2a702c3bb0a317f72bf044c2174b191c

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
=======
<<<<<<< HEAD


app.UseCors("AllowLocalhost");



app.UseRouting();
=======
<<<<<<< HEAD
>>>>>>> 6fe8338d10e992de45d556b6df162021fb64e5b1
// Configure the HTTP request pipeline.


app.UseCors("AllowLocalhost");
<<<<<<< HEAD
app.UseRouting();
app.UseRouting();
=======


>>>>>>> f2b11bc1b37c218161e722235d5b6a7414e5d63d


app.UseRouting();


<<<<<<< HEAD
=======







app.UseRouting();

>>>>>>> 1c3e562c2a702c3bb0a317f72bf044c2174b191c
app.UseCors("AllowLocalhost");
app.UseRouting();
<<<<<<< HEAD
=======


>>>>>>> 1c3e562c2a702c3bb0a317f72bf044c2174b191c
app.UseCors("AllowLocalhost");
app.UseRouting();
<<<<<<< HEAD
=======



>>>>>>> f2b11bc1b37c218161e722235d5b6a7414e5d63d
app.UseCors("AllowLocalhost");

app.UseRouting();


app.UseCors("AllowLocalhost");
app.UseRouting();


<<<<<<< HEAD

=======
<<<<<<< HEAD
app.UseCors("AllowLocalhost");

app.UseRouting();

=======
<<<<<<< HEAD

=======
>>>>>>> 3e7d74c60a3b4e3520b607f1dfac3c64b7cb8b1c
>>>>>>> 1c3e562c2a702c3bb0a317f72bf044c2174b191c
>>>>>>> f2b11bc1b37c218161e722235d5b6a7414e5d63d
>>>>>>> 6fe8338d10e992de45d556b6df162021fb64e5b1
app.UseAuthorization();
app.UseSession();
app.MapControllers();
app.Run();
