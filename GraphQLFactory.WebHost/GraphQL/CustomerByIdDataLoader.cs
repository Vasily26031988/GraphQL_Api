using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GraphQLFactory.Core.Abstractions.Repositories;
using GraphQLFactory.Core.Domain.PromoCodeManagement;
using GreenDonut;
using HotChocolate.DataLoader;

namespace GraphQLFactory.WebHost.GraphQL
{
    public class CustomerByIdDataLoader : BatchDataLoader<Guid, Customer>
    {
	    private readonly IRepository<Customer> _customerRepository;

	    public CustomerByIdDataLoader(
		    IRepository<Customer> customerRepository, 
		    IBatchScheduler batchScheduler) 
		    : base(batchScheduler)
	    {
		    _customerRepository = customerRepository;
	    }


	    protected override async Task<IReadOnlyDictionary<Guid, Customer>> LoadBatchAsync(
		    IReadOnlyList<Guid> keys, 
		    CancellationToken cancellationToken)
	    {
		    var customers = await _customerRepository.GetRangeByIdsAsync(keys.ToList());
		    return customers.ToDictionary(x=>x.Id);
	    }
    }
}
