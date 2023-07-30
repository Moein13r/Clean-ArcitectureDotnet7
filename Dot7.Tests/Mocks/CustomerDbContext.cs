using Dot7.Architecture.Application.Context;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dot7.Architecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Dot7.Tests.Mocks
{
    public class CustomerDbContext
    {
        public static DbSet<TData> GetMock<TData>(List<TData> lstData) where TData : class
        {
            var queryable = lstData.AsQueryable();
            var dbSet = new Mock<DbSet<TData>>();
            dbSet.As<IQueryable<TData>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<TData>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<TData>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<TData>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<TData>())).Callback<TData>((s) => lstData.Add(s));
            return dbSet.Object;
        }
        public static Mock<Dot7.Architecture.Infrastructure.Context.CustomerDbContext> GetCustomerDbContext()
        {
            List<Customer> customersList = new List<Customer>
            {
                new Customer{ Id = 1, FirstName = "Person 1",LastName="L Person 1",BankAccountNumber=1000_0110_0780_9440,DateOfBirth="1990/04/04",Email="Person1@gmail.com",PhoneNumber="+98xxxxxx2965"},
                new Customer{ Id = 2, FirstName = "Person 2",LastName = "L Person 2",BankAccountNumber=1011_3190_0780_4540,DateOfBirth="1998/04/04",Email="Person2@gmail.com",PhoneNumber="+98xxxxxx2364"},
                new Customer{ Id = 3, FirstName = "Person 3",LastName = "L Person 3",BankAccountNumber=1011_3190_1780_4540,DateOfBirth="2000/04/04",Email="Person3@gmail.com",PhoneNumber="+98xxxxxx1363"},
                new Customer{ Id = 4, FirstName = "Person 4",LastName = "L Person 4",BankAccountNumber=1011_3190_0781_4540,DateOfBirth="2003/04/04",Email="Person4@gmail.com",PhoneNumber="+98xxxxxx2167"},
                new Customer{ Id = 5, FirstName = "Person 5",LastName = "L Person 5",BankAccountNumber=1011_3190_0710_4540,DateOfBirth="1988/04/04",Email="Person5@gmail.com",PhoneNumber="+98xxxxxx2314"},
                new Customer{ Id = 6, FirstName = "Person 6",LastName = "L Person 6",BankAccountNumber=1011_3190_0180_4540,DateOfBirth="1999/04/04",Email="Person6@gmail.com",PhoneNumber="+98xxxxxx2164"}
            };
            var mockContext = GetMock(customersList);
            Mock<Dot7.Architecture.Infrastructure.Context.CustomerDbContext> mockDbContext =
            new Mock<Architecture.Infrastructure.Context.CustomerDbContext>(           
            new DbContextOptionsBuilder<Dot7.Architecture.Infrastructure.Context.CustomerDbContext>()
            .UseInMemoryDatabase("Customers")
            .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options);
            mockDbContext.Setup(c => c.Customer).Returns(mockContext);
            return mockDbContext;
        }
    }
}
