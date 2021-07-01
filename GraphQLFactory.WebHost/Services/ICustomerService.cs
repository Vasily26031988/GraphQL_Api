using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQLFactory.WebHost.Models;

namespace GraphQLFactory.WebHost.Services
{
    public interface ICustomerService
    {
	    Task<IEnumerable<CustomerShortResponse>> GetAllAsync();
	    Task<CustomerResponse> GetByIdAsync(Guid id);
	    Task<CustomerResponse> CreateAsync(CreateOrEditCustomerRequest request);
	    Task<bool> EditAsync(Guid id, CreateOrEditCustomerRequest request);
	    Task<bool> DeleteAsync(Guid id);
    }
}
