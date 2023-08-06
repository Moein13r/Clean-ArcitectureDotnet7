using AutoMapper;
using Dot7.Architecture.Api.Controllers;
using Dot7.Architecture.Application.Customer.GetAllBeaches;
using Dot7.Architecture.Infrastructure.Context;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dot7.Tests.Application
{
    public class GetCustomersByFilter
    {
        CustomerDbContext _mockDbContext;
        public GetCustomersByFilter()
        {
            _mockDbContext = Mocks.CustomerDbContext.GetCustomerDbContext().Object;
        }
        [Fact]
        async void Should_FilterCustomers_ByProps()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new GetAllCustomersMapper());
            });
            var mapper = mockMapper.CreateMapper();

            var handler = new GetAllCustomersQueryHandler(_mockDbContext, mapper);
            var result = await handler.Handle(new GetAllCustomersRequest(), CancellationToken.None);
            result.Should().NotBeNull();
            result.Should().BeOfType<List<GetAllCustomersResponse>>();
            var customers = result.OfType<GetAllCustomersResponse>();
        }
    }
}