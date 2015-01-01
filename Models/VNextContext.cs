using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace VNext.Models
{
  public class VNextContext : DbContext
  {
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<User>().Key(a => a.Id);
      base.OnModelCreating(builder);
    }
  }
}