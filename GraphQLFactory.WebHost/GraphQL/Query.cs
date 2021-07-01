using GraphQLFactory.Core.Domain.PromoCodeManagement;
using GraphQLFactory.DataAccess;
using HotChocolate;
using System.Linq;

namespace GraphQLFactory.WebHost.GraphQL
{
	public class Query
	{
		public IQueryable<Customer> GetCustomers([Service] DataContext context)
		{
			return context.Customers;
		}
	}
}
