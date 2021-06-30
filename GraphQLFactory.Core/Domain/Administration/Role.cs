using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQLFactory.Core.Domain.PromoCodeManagement;

namespace GraphQLFactory.Core.Domain.Administration
{
	public class Role
		: BaseEntity
	{
		public string Name { get; set; }

		public string Description { get; set; }
	}
}
