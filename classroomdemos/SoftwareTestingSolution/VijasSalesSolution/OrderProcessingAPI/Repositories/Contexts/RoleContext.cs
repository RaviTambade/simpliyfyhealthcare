using Transflower.MembershipRolesMgmt.Models.Entities;
using Microsoft.EntityFrameworkCore;
namespace Transflower.MembershipRolesMgmt.Repositories.Contexts;
public class RoleContext : DbContext
{
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<User> Users { get; set; }
    
    public RoleContext(DbContextOptions options)
        : base(options)
    {
        Roles = Set<Role>();
        UserRoles = Set<UserRole>();
        Users=Set<User>();
    }
}