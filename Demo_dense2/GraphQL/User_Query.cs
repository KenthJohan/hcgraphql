using System.Linq;
using System;


using Serilog;

using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Data;
using HotChocolate.AspNetCore;
using HotChocolate.Types.Descriptors;


namespace Demo
{

	[ExtendObjectType("User")]
	public class User_Resolver
	{
		public string pwhash_base64(User user)
		{
			return Convert.ToBase64String(user.pwhash);
		}

		public int id_times_20(User user)
		{
			return 20;
		}

		public IQueryable<Book> GetBooks(User user, [Service] Demo_Context context)
		{
			return null;
		}

	}


	[ExtendObjectType("Query")]
	public class User_Query
	{
		private readonly ILogger log = Log.ForContext<User_Query>();
		
		[UseProjection]
		public IQueryable<Entity> users([Service] Demo_Context context)
		{
			return context.users;
		}

	}
}
