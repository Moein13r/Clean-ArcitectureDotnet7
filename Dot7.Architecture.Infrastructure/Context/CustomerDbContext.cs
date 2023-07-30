using Dot7.Architecture.Application.Context;
using Dot7.Architecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dot7.Architecture.Infrastructure.Context;

public class CustomerDbContext : DbContext, ICustomerDbContext
{
    public CustomerDbContext(DbContextOptions<CustomerDbContext> options):base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().ToTable("Customer");
    }
    public virtual DbSet<Customer> Customer {get;set;}

    public async Task<int> SaveToDbAsync()
    {
        return await SaveChangesAsync();
    }
}