using System.Linq;
using System;


using Serilog;

using HotChocolate;
using HotChocolate.Types;


namespace Demo
{

	[ExtendObjectType("User")]
	public class User_Resolver
	{
		public string pwhash_base64(User user)
		{
			return Convert.ToBase64String(user.pwhash);
		}

		public IQueryable<Book> GetBooks(User user, [Service] Demo_Context context)
		{
			return context.books.Where(b => b.author_id == user.id);
		}
	}


	[ExtendObjectType("Query")]
	public class User_Query
	{
		private readonly ILogger log = Log.ForContext<User_Query>();

		public IQueryable<User> GetUsers([Service] Demo_Context context)
		{
			return context.users;
		}
	}
}
