using System.Linq;

using Serilog;

using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Data;
using HotChocolate;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;


namespace Demo
{




	[ExtendObjectType("Query")]
	public class Book_Query
	{
		private readonly ILogger log = Log.ForContext<User_Mutation>();

		[UseProjection]
		public IQueryable<Bigtable> bigtable([Service] Demo_Context context) 
		{
			return context.bigtable;
		}


	}
}
