var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
<<<<<<< HEAD
builder.Services.AddCors();
=======
>>>>>>> 35a7b6257c5a6a69316773db50557691439ef819
builder.Services.AddControllers();

// Add in-memory distributed cache
builder.Services.AddDistributedMemoryCache();  // This is the key line for in-memory cache

// Add session service
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".ShoppingCart.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(600);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
<<<<<<< HEAD
app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

=======
>>>>>>> 35a7b6257c5a6a69316773db50557691439ef819
app.UseAuthorization();

// Enable session middleware after routing
app.UseSession();

app.MapControllers();

app.Run();
