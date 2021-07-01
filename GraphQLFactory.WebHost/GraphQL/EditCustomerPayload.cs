using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQLFactory.Core.Domain.PromoCodeManagement;

namespace GraphQLFactory.WebHost.GraphQL
{
    public class EditCustomerPayload : Payload
    {
	    public EditCustomerPayload(Customer customer) 
	    {
		    Customer = customer;
	    }

	    public EditCustomerPayload(UserError error) 
		    : base(new[] {error})
	    {
	    }

	    public Customer Customer { get; }  
    }
}
