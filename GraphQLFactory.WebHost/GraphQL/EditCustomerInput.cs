using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLFactory.WebHost.GraphQL
{
	public record EditCustomerInput
	(
		Guid Id,
		string FirstName,
		string LastName,
		string Email,
		List<Guid> PreferenceIds
	);



}
