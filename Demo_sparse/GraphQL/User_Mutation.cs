using System;
using System.Threading.Tasks;
using System.Linq;


using Microsoft.EntityFrameworkCore;

using Serilog;

using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Types;

namespace Demo
{


	[ExtendObjectType("Mutation")]
	public class User_Mutation
	{
		private readonly ILogger log = Log.ForContext<User_Mutation>();

		public int user_register([Service] Demo_Context context, string email, string password)
		{
			return 1;
		}


	}
}