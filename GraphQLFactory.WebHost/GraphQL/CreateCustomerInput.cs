using System;
using System.Collections.Generic;

namespace GraphQLFactory.WebHost.GraphQL
{
	public record CreateCustomerInput
		(
		string FirstName,
		string LastName,
		string Email,
		List<Guid> PreferenceIds
		);
}
