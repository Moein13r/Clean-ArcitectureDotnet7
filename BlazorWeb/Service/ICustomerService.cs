using BlazorWeb.Data;
using Dot7.Architecture.Application.Customer.CreateCustomer;

namespace BlazorWeb.Service
{
    public interface ICustomerService
    {
        public Task<int> AddCustomer(Customer customer, CancellationToken cancellationToken);
    }
}
