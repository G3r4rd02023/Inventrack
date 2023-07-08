using Inventrack.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Inventrack.Data
{
	public class DataContext : IdentityDbContext<User>
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		public DbSet<Stock> Stocks { get; set; }
	}
}
