using Microsoft.EntityFrameworkCore;

namespace DutyApp.Persistence;

public class DutyAppDbContext : DbContext
{
    public DutyAppDbContext(DbContextOptions<DutyAppDbContext> options) : base(options)
    {

    }
    public DbSet<DutyApp.Domain.User> Users { get; set; }
    public DbSet<DutyApp.Domain.Group> Groups { get; set; }
    public DbSet<DutyApp.Domain.Task> Tasks { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DutyApp.Domain.User>().HasKey(u => u.Id);
        modelBuilder.Entity<DutyApp.Domain.User>().HasMany(u => u.Groups).WithOne(g => g.Creator).HasForeignKey(g => g.CreatorId);
        modelBuilder.Entity<DutyApp.Domain.User>().HasMany(u => u.Tasks).WithOne(t => t.Creator).HasForeignKey(t => t.CreatorId);
        modelBuilder.Entity<DutyApp.Domain.User>().Property(u => u.UserName).IsRequired();
        modelBuilder.Entity<DutyApp.Domain.User>().Property(u => u.Email).IsRequired();
        modelBuilder.Entity<DutyApp.Domain.User>().HasIndex(u => u.Email).IsUnique();
        modelBuilder.Entity<DutyApp.Domain.User>().HasIndex(u => u.UserName).IsUnique();
        modelBuilder.Entity<DutyApp.Domain.User>().HasMany(u => u.Groups).WithMany(g => g.Members);
        modelBuilder.Entity<DutyApp.Domain.Group>().HasKey(g => g.Id);
        modelBuilder.Entity<DutyApp.Domain.Group>().HasMany(g => g.Members).WithMany(u => u.Groups);
        modelBuilder.Entity<DutyApp.Domain.Group>().HasMany(g => g.Tasks).WithOne(t => t.Group).HasForeignKey(t => t.GroupId);
        modelBuilder.Entity<DutyApp.Domain.Group>().Property(g => g.Name).IsRequired();
        modelBuilder.Entity<DutyApp.Domain.Task>().HasKey(t => t.Id);
        modelBuilder.Entity<DutyApp.Domain.Task>().Property(t => t.Title).IsRequired();
        modelBuilder.Entity<DutyApp.Domain.Task>().Property(t => t.Description).IsRequired();
        modelBuilder.Entity<DutyApp.Domain.Task>().Property(t => t.Deadline).IsRequired();
        modelBuilder.Entity<DutyApp.Domain.Task>().HasOne(t => t.Group).WithMany(g => g.Tasks);
        modelBuilder.Entity<DutyApp.Domain.Task>().HasOne(t => t.Creator).WithMany(u => u.Tasks);
    }
}

