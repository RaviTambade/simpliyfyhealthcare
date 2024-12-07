using Catalog.Repositories;
using Catalog.Repositories.Connected;
using Catalog.Services;
using CRM.Repositories.ORM;
using CRM.Repositories;
using CRM.Services;
using PaymentProcessing.Services;
using PaymentProcessing.Repositories;
using PaymentProcessing.Repositories.Connected;

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

// Register ProductService (already done in your code)
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IUserService, UserService>();


builder.Services.AddTransient<IPaymentRepository, PaymentRepository>();

builder.Services.AddTransient<IPaymentServices, PaymentServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowLocalhost");

app.UseRouting();
app.UseAuthorization();

app.UseSession();
app.MapControllers();
app.Run();
