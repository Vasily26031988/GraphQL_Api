using System;
using System.Collections.Generic;
using GraphQLFactory.Core.Domain.PromoCodeManagement;
using GraphQLFactory.DataAccess;
using HotChocolate;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GraphQLFactory.Core.Abstractions.Repositories;
using HotChocolate.Types.Relay;

namespace GraphQLFactory.WebHost.GraphQL
{
	public class Query
	{
		public async Task<List<Customer>> GetCustomers([Service] IRepository<Customer> customerRepository)
		{
			return (await customerRepository.GetAllAsync()).ToList();
		}

		public async Task<Customer> GetCustomerById([Service] IRepository<Customer> customerRepository, Guid id)
		{
			return await customerRepository.GetByIdAsync(id);
		}

		public async Task<List<Preference>> GetPreferences([Service] IRepository<Preference> preferenceRepository)
		{
			return (await preferenceRepository.GetAllAsync()).ToList();
		}

		// public IQueryable<Customer> GetCustomers([Service] DataContext context) =>
		// 	context.Customers;
		//
		// public Task<Customer> GetCustomerByIdAsync(
		// 	[ID(nameof(Customer))] Guid id,
		// 	CustomerByIdDataLoader customerById,
		// 	CancellationToken cancellationToken) =>
		// 	customerById.LoadAsync(id, cancellationToken);
		//
		// public async Task<IEnumerable<Customer>> GetCustomersByIdAsync(
		// 	[ID(nameof(Customer))] Guid[] ids,
		// 	CustomerByIdDataLoader customerById,
		// 	CancellationToken cancellationToken) =>
		// 	await customerById.LoadAsync(ids, cancellationToken);
	}
}


