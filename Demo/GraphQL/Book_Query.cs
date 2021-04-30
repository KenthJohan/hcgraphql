using System.Linq;

using Serilog;

using HotChocolate;
using HotChocolate.Types;

namespace Demo
{
	[ExtendObjectType("Query")]
	public class Book_Query
	{
		private readonly ILogger log = Log.ForContext<User_Mutation>();
		public IQueryable<Book> GetBooks([Service] Demo_Context context) 
		{
			return context.books;
		}

		public IQueryable<Book> GetBookById([Service] Demo_Context context) 
		{
			return context.books;
		}


	}
}
