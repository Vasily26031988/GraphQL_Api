using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQLFactory.Core.Abstractions.Gateways;

namespace GraphQLFactory.Integration
{
	public class NotificationGateway
		: INotificationGateway
	{
		public Task SendNotificationToPartnerAsync(Guid partnerId, string message)
		{
			

			return Task.CompletedTask;
		}
	}
}
