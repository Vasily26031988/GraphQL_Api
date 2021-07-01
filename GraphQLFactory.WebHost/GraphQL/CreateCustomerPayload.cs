using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQLFactory.Core.Domain.PromoCodeManagement;

namespace GraphQLFactory.WebHost.GraphQL
{
    public class CreateCustomerPayload : Payload
    {
	    public CreateCustomerPayload(Customer customer)
	    {
		    Customer = customer;
	    }

	    protected CreateCustomerPayload(UserError error) : base(new [] {error})
	    {
	    }

		public Customer Customer { get; }
    }
}
