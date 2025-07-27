namespace BackendAPI.Data{

using Microsoft.EntityFrameworkCore;
using BackendAPI.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<User> Users { get; set; }
}}