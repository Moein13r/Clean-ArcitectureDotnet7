using AutoMapper;
using Dot7.Architecture.Application.Customer.GetAllBeaches;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.ObjectModel;
using FluentAssertions.Numeric;
using FluentAssertions;
using Dot7.Architecture.Application.Customer.CreateCustomer;
using Dot7.Architecture.Application.Customer.DeleteCustomer;
using Dot7.Architecture.Application.Customer.UpdateCustomer;
using Dot7.Architecture.Application.Context;
using Dot7.Architecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Dot7.Tests
{
    public class UnitTest1
    {
        private readonly CustomerDbContext _mockDbContext;
        public UnitTest1()
        {            
            _mockDbContext = Mocks.CustomerDbContext.GetCustomerDbContext().Object;            
        }

        [Fact]
        public async void GetCustomersTest()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new GetAllCustomersMapper());
            });
            var mapper = mockMapper.CreateMapper();

            var handler = new GetAllCustomersQueryHandler(_mockDbContext, mapper);
            var result = await handler.Handle(new GetAllCustomersRequest(), CancellationToken.None);
            result.Should().Satisfy(itm => itm.Id > 0);
            result.Count.Should().Be(6);
        }
        [Fact]
        public async void ShouldSaveToDataBase()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CreateCustomerMapper());
            });
            var mapper = mockMapper.CreateMapper();

            var handler = new CreateCustomerCommandHandler(_mockDbContext, mapper);
            var result = await handler.Handle(new CreateCustomerRequest
            {
                FirstName = "Moein",
                LastName = "Raeisy",
                PhoneNumber = "092221565115",
                BankAccountNumber = 0,
                DateOfBirth = "1404/05/05",
                Email = "test@gmail.com"
            }, CancellationToken.None);
            result.Should().BeOfType(typeof(int));
            result.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(6)]
        public async void ShouldDeleteFromDataBase(int id)
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DeleteAllCustomersMapper());
            });
            var mapper = mockMapper.CreateMapper();

            var handler = new DeleteAllCustomersQueryHandler(_mockDbContext, mapper);
            var result = await handler.Handle(new DeleteAllCustomersRequest { Id = id }, CancellationToken.None);
            Assert.True(result);
            Assert.False(_mockDbContext.Customer.Any(itm => itm.Id == id));
        }
        [Fact]
        public async void ShouldUpdateToDataBase()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UpdateCustomersMapper());
            });
            var mapper = mockMapper.CreateMapper();

            var handler = new UpdateCustomersQueryHandler(_mockDbContext, mapper);
            var customer = new UpdateCustomersRequest
            {
                Id = 2,
                FirstName = "Moein",
                LastName = "Raeisy",
                BankAccountNumber = 1011_3190_0780_4540,
                DateOfBirth = "1998/04/04",
                Email = "Person2@gmail.com",
                PhoneNumber = "+98xxxxxx2364"
            };
            var result = await handler.Handle(customer, CancellationToken.None);
            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThan(0);
            Assert.Equal(result.FirstName, customer.FirstName);
            Assert.Equal(result.LastName, customer.LastName);
            Assert.Equal(result.Email, customer.Email);
            Assert.Equal(result.PhoneNumber, customer.PhoneNumber);
            Assert.Equal(result.BankAccountNumber, customer.BankAccountNumber);
            Assert.Equal(result.DateOfBirth, customer.DateOfBirth);
        }
    }
}