using VNext.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace VNext.DAL
{
  public class MyDbContext : DbContext
  {    
    public MyDbContext() : base("VNextConnectionString")
    {
      Database.SetInitializer<MyDbContext>(new MyDbInitializer());
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    }
  }
}