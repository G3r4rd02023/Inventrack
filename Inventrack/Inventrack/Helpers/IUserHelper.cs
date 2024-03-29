﻿using Inventrack.Data.Entities;
using Inventrack.Models;
using Microsoft.AspNetCore.Identity;

namespace Inventrack.Helpers
{
	public interface IUserHelper
	{
		Task<User> GetUserAsync(string email);
		Task<IdentityResult> AddUserAsync(User user, string password);
		Task CheckRoleAsync(string roleName);
		Task AddUserToRoleAsync(User user, string roleName);
		Task<bool> IsUserInRoleAsync(User user, string roleName);
		Task<SignInResult> LoginAsync(LoginViewModel model);
		Task LogoutAsync();

	}
}
