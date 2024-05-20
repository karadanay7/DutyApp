using Microsoft.EntityFrameworkCore;
using DutyApp.Domain.Entities;

namespace DutyApp.Persistence.Context
{
  public class DutyAppDbContext : DbContext
  {
    public DutyAppDbContext(DbContextOptions<DutyAppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Domain.Entities.Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // Configure relationships and constraints here
    }
  }
}
