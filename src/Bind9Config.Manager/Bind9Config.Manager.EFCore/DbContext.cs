namespace Bind9Config.Manager.EFCore;

public class Bind9ConfigDbContext : DbContext
{
    public DbSet<> MyProperty { get; set; }
}
