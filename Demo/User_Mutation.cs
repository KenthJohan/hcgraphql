using System;
using System.Threading.Tasks;

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

		public async Task<bool> user_register([Service] Demo_Context context, string email, string password)
		{
			if (string.IsNullOrEmpty(email))
			{
				throw new QueryException(
					ErrorBuilder.New()
						.SetMessage("The email cannot be empty.")
						.SetCode("EMAIL_EMPTY")
						.Build());
			}

			if (string.IsNullOrEmpty(password))
			{
				throw new QueryException(
					ErrorBuilder.New()
						.SetMessage("The password cannot be empty.")
						.SetCode("PASSWORD_EMPTY")
						.Build());
			}

			User user = new User{email = email};
			user.guid = Guid.NewGuid();
			user.pwhash64 = Userpw.SHA512_make(user.guid, password);

			log.Information("Adding {@User}", user);
			context.Users.Add(user);
			try
			{
				await context.SaveChangesAsync();
			}
			catch
			{
				return false;
			}
			return true;
		}

		public async Task<bool> user_login([Service] Demo_Context context, string email, string password)
		{
			User user = await context.Users.FirstOrDefaultAsync(u => u.email == email);
			bool success = Userpw.SHA512_compare(user.pwhash64, user.guid, password);
			log.Information("The {@User} logged in: {success}", user, success);
			return success;
		}


	}
}