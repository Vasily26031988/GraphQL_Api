﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQLFactory.Core.Domain.Administration;

namespace GraphQLFactory.Core.Domain.PromoCodeManagement
{
	public class PromoCode
		: BaseEntity
	{
		public string Code { get; set; }

		public string ServiceInfo { get; set; }

		public DateTime BeginDate { get; set; }

		public DateTime EndDate { get; set; }

		public string PartnerName { get; set; }

		public virtual Employee PartnerManager { get; set; }

		public Guid? PartnerManagerId { get; set; }

		public virtual Preference Preference { get; set; }

		public Guid PreferenceId { get; set; }

		public virtual ICollection<PromoCodeCustomer> Customers { get; set; }
	}
}
