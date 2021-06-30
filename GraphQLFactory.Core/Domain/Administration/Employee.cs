﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQLFactory.Core.Domain.PromoCodeManagement;

namespace GraphQLFactory.Core.Domain.Administration
{
	public class Employee
		: BaseEntity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public string FullName => $"{FirstName} {LastName}";

		public string Email { get; set; }

		public Guid RoleId { get; set; }
		public virtual Role Role { get; set; }

		public int AppliedPromocodesCount { get; set; }
	}
}
