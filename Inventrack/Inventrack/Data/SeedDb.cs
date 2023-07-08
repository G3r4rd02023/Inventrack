using Inventrack.Data.Entities;
using Inventrack.Enums;
using Inventrack.Helpers;

namespace Inventrack.Data
{
	public class SeedDb
	{
		private readonly DataContext _context;
		private readonly IUserHelper _userHelper;
		public SeedDb(DataContext context,IUserHelper userHelper)
		{
			_context = context;
			_userHelper = userHelper;
		}

		public async Task SeedAsync()
		{
			await _context.Database.EnsureCreatedAsync();
			await CheckRolesAsync();
			await CheckUserAsync("Gerardo", "Lanza", "gerardo@yopmail.com", "3223-1146", 
			UserType.Admin);
		}

		private async Task<User> CheckUserAsync(
					
					string firstName,
					string lastName,
					string email,
					string phone,
					
					UserType userType)
		{
			User user = await _userHelper.GetUserAsync(email);
			if (user == null)
			{
				user = new User
				{
					FirstName = firstName,
					LastName = lastName,
					Email = email,
					UserName = email,
					PhoneNumber = phone,					
					UserType = userType,
				};
				await _userHelper.AddUserAsync(user, "123456");
				await _userHelper.AddUserToRoleAsync(user, userType.ToString());
			}
			return user;
		}

		private async Task CheckRolesAsync()
		{
			await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
			await _userHelper.CheckRoleAsync(UserType.User.ToString());
		}

	}

}

