using System;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core
{
  public class MainDbContext : DbContext
  {
    private const string HOST = "127.0.0.1";
    private const string USER = "root";
    private const string PASSWORD = "testdbpass";
    private const string DATABASE = "playground";

    private string ConnectionString => $"Server={HOST};User ID={USER};Password={PASSWORD};Database={DATABASE}";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
      optionsBuilder.UseMySql(ConnectionString, new MySqlServerVersion(new Version(5, 7, 24)))
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors();

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
  }
}