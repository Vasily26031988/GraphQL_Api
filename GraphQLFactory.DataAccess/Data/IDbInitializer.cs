using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLFactory.DataAccess.Data
{
	public interface IDbInitializer
	{
		public void InitializeDb();
	}
}
