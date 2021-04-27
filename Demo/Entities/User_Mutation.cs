using System;

using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Types;


using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;


namespace Demo
{


	[ExtendObjectType("Mutation")]
	public class User_Mutation
	{
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

			context.Users.Add(user);
			await context.SaveChangesAsync();
			return false;
		}

		public async Task<bool> user_login([Service] Demo_Context context, string email, string password)
		{
			User user = await context.Users.FirstOrDefaultAsync(u => u.email == email);
			bool success = Userpw.SHA512_compare(user.pwhash64, user.guid, password);
			return success;
		}


	}
}