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
using Banking.Repositories.Connected;
using Banking.Services;
using Shipment.Repositories;
using Shipment.Repositories.ORM;
using Shipment.Services;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using VijaySalesAPI.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
=======

<<<<<<< HEAD
using Banking.Repositories.Connected;
using Banking.Services;
=======
>>>>>>> d489f186a430aa5cd88f3f6c1d9e494b66a840db
using Shipment.Repositories;
using Shipment.Repositories.ORM;
using Shipment.Services;
>>>>>>> 7a418ba70d4881a591081d61969e86d4508b8041

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
=======
<<<<<<< HEAD
>>>>>>> 7a418ba70d4881a591081d61969e86d4508b8041

        policy.WithOrigins("http://localhost:5260", "http://localhost:5284", "http://localhost:12890");  // Allow your frontend's URL
        policy.WithOrigins("http://localhost:5260", "http://localhost:5284", "http://localhost:5218");  // Allow your frontend's URL
        policy.WithOrigins("http://localhost:5260", "http://localhost:5284", "http://localhost:5218") // Allow your frontend's URL

<<<<<<< HEAD
=======
=======
        policy.WithOrigins("http://localhost:5260", "http://localhost:5284", "http://localhost:5218")  // Allow your frontend's URL
>>>>>>> d489f186a430aa5cd88f3f6c1d9e494b66a840db
>>>>>>> 7a418ba70d4881a591081d61969e86d4508b8041
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
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IUserDataRepository, UserRepository>();

//JWT Setup

// Configure JWT Authentication
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddCookie(options =>
{
    options.Cookie.Name = "YourAppAuthCookie"; // Set cookie name
    options.Cookie.HttpOnly = true; // Security: ensures cookie is only sent in HTTP requests
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; // Use secure cookies in production (set to Always if HTTPS is used)
    options.Cookie.SameSite = SameSiteMode.Strict; // Helps to prevent CSRF attacks
    options.SlidingExpiration = true; // Cookie expires after a set time but is renewed with activity

})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };


});
=======
<<<<<<< HEAD


//Register context
>>>>>>> 7a418ba70d4881a591081d61969e86d4508b8041


var app = builder.Build();
app.UseCors("AllowLocalhost");
app.UseRouting();
app.UseAuthorization();
app.UseSession();
app.MapControllers();
 
app.Run();


<<<<<<< HEAD
=======






 
=======
var app = builder.Build();

>>>>>>> 7a418ba70d4881a591081d61969e86d4508b8041
app.UseCors("AllowLocalhost");
app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapControllers();

app.Run();
<<<<<<< HEAD
=======
>>>>>>> d489f186a430aa5cd88f3f6c1d9e494b66a840db
>>>>>>> 7a418ba70d4881a591081d61969e86d4508b8041
