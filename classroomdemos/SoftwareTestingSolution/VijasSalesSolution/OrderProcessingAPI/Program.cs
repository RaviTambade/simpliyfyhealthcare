using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.Intrinsics.X86;
using System.Text;
using Transflower.MembershipRolesMgmt.Repositories.Contexts;
using Transflower.MembershipRolesMgmt.Services.Interfaces;
using Transflower.MembershipRolesMgmt.Services;
using Transflower.MembershipRolesMgmt.Repositories.Interfaces;
using Transflower.MembershipRolesMgmt.Repositories;
using Transflower.MembershipRolesMgmt.Helpers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add authentication with JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
builder.Services.AddDbContext<RoleContext>(
    options =>
        options
            .UseMySql(
                builder.Configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 28))
            )
            .LogTo(Console.WriteLine, LogLevel.Information)
);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<TokenHelper>();

builder.Services
    .AddOptions<JwtSettings>()
    .BindConfiguration("JWT")
    .ValidateDataAnnotations()
    .ValidateOnStart();

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseCors(a => a.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();
// Use authentication
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<JwtMiddleware>();

app.MapControllers();
app.Run();
