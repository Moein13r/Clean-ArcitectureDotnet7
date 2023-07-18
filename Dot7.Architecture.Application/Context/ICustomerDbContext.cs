using Microsoft.EntityFrameworkCore;

namespace Dot7.Architecture.Application.Context;

public interface ICustomerDbContext
{
    DbSet<Dot7.Architecture.Domain.Entities.Customer> Customer{get;}

    Task<int> SaveToDbAsync();
}