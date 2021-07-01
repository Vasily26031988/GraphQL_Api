using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenDonut;

namespace GraphQLFactory.WebHost.GraphQL
{
    public class DeleteCustomerPayload : Payload
    {
	    public bool Result { get; }

	    public DeleteCustomerPayload(bool result) => Result = result;
	   

	    public DeleteCustomerPayload(UserError error) 
		    : base(new []{error})
	    {
	    }

		
    }
}
