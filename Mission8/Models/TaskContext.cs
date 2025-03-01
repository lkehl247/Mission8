using Microsoft.EntityFrameworkCore;

namespace Mission8.Models;

public class TaskContext: DbContext //Liaison from the app to the databas
{
    public TaskContext(DbContextOptions<TaskContext> options) : base(options)
    {
    }
    
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) // Seed data
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Home" },
            new Category { CategoryId = 2, CategoryName = "Work" },
            new Category { CategoryId = 3, CategoryName = "School" },
            new Category { CategoryId = 4, CategoryName = "Church" }
        );
    }
} 