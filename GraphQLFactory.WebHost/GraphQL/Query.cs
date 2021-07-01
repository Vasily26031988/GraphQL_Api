using System;
using System.Collections.Generic;
using GraphQLFactory.Core.Domain.PromoCodeManagement;
using GraphQLFactory.DataAccess;
using HotChocolate;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate.Types.Relay;

namespace GraphQLFactory.WebHost.GraphQL
{
	public class Query
	{
		public IQueryable<Customer> GetCustomers([Service] DataContext context) =>
			context.Customers;

		public Task<Customer> GetCustomerByIdAsync(
			[ID(nameof(Customer))] Guid id,
			CustomerByIdDataLoader customerById,
			CancellationToken cancellationToken) =>
			customerById.LoadAsync(id, cancellationToken);

		public async Task<IEnumerable<Customer>> GetCustomersByIdAsync(
			[ID(nameof(Customer))] Guid[] ids,
			CustomerByIdDataLoader customerById,
			CancellationToken cancellationToken) =>
			await customerById.LoadAsync(ids, cancellationToken);

    }
}
