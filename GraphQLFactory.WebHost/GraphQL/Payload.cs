using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLFactory.WebHost.GraphQL
{
    public class Payload
    {
	   
	    protected Payload(IReadOnlyList<UserError> errors = null) => Errors = errors;

        public IReadOnlyList<UserError> Errors { get; }

    }
}
