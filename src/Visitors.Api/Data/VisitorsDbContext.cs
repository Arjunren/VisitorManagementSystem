using Microsoft.EntityFrameworkCore;using Visitors.Api.Models;
namespace Visitors.Api.Data;
public sealed class VisitorsDbContext(DbContextOptions<VisitorsDbContext> options):DbContext(options){public DbSet<User> Users=>Set<User>();public DbSet<Visitor> Visitors=>Set<Visitor>();public DbSet<Visit> Visits=>Set<Visit>();protected override void OnModelCreating(ModelBuilder b){b.Entity<User>().HasIndex(x=>x.Username).IsUnique();b.Entity<Visitor>().HasIndex(x=>x.Email).IsUnique();b.Entity<Visit>().HasIndex(x=>x.Reference).IsUnique();b.Entity<Visit>().HasIndex(x=>x.BadgeNumber).IsUnique();}}
