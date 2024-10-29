using Microsoft.EntityFrameworkCore;
using Praktikum_Test3.Model;

namespace Praktikum_Test3.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    public DbSet<Student> Student { get; set; }
    public DbSet<Course> Course { get; set; }
    public DbSet<Instructor> Instructor { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    
}