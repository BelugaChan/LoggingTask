using LoggingTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoggingTask.Persistence.Context;

public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
{
    public DbSet<ProductEntity> Products { get; set; }  
}