using System.Linq;

using Serilog;

using HotChocolate;
using HotChocolate.Types;
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


	[ExtendObjectType("Book")]
	public class Book_Resolver
	{
		public IQueryable<User> GetAuthor(Book book, [Service] Demo_Context context)
		{
			return null;
		}
	}


	[ExtendObjectType("Query")]
	public class Book_Query
	{
		private readonly ILogger log = Log.ForContext<User_Mutation>();
		public IQueryable<Book> GetBooks([Service] Demo_Context context) 
		{
			return context.books;
		}

		public IQueryable<Book> GetBookById([Service] Demo_Context context, [ID(nameof(Book))]int id) 
		{
			return null;
		}


	}
}
