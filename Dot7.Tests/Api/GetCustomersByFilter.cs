using Dot7.Architecture.Api.Controllers;
using Dot7.Architecture.Application.Customer.GetAllBeaches;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dot7.Tests.Api
{
    public class GetCustomersByFilter
    {
        public GetCustomersByFilter()
        {

        }
        [Fact]
        async void Should_FilterCustomers_ByProps()
        {
            Mock<IMediator> customerQuery = new Mock<IMediator>();
            customerQuery.Setup(m => m.Send(It.IsAny<GetAllCustomersRequest>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(Mocks.CustomerDbContext.GetCustomerDbContext().Object.Customer.Select(itm =>
            new GetAllCustomersResponse
            {
                BankAccountNumber = itm.BankAccountNumber,
                DateOfBirth = itm.DateOfBirth,
                Email = itm.Email,
                FirstName = itm.FirstName,
                Id = itm.Id,
                LastName = itm.LastName,
                PhoneNumber = itm.PhoneNumber
            }).ToList()));
            var customerController = new CustomerController(customerQuery.Object);
            var response = await customerController.GetAsync();
            response.Should().BeOfType<OkObjectResult>();
            ((OkObjectResult)response).Value.Should().NotBeNull();
            ((OkObjectResult)response).Value.Should().BeOfType<List<GetAllCustomersResponse>>();
        }
    }
}