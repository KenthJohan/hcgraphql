namespace Demo
{
	public class Query
	{
		public Book GetBook() =>
			new Book
			{
				name = "C# in depth.",
				author = new User
				{
					email = "Jon Skeet"
				}
			};
	}
}
