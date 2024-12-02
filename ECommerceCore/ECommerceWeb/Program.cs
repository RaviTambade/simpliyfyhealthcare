var builder = WebApplication.CreateBuilder(args);

//services configuration
//Adding services which needed in future
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddTransient<IProductService, ProductService>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
//asp.net middleware pipeline

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
