using Inventrack.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Inventrack.Data.Entities
{
	public class User:IdentityUser
	{
		[Display(Name = "Nombres")]
		[MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public string FirstName { get; set; }

		[Display(Name = "Apellidos")]
		[MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public string LastName { get; set; }

		[Display(Name = "Foto")]
		public string? ImageUrl { get; set; }

		[Display(Name = "Foto")]
		public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
			? null
		   //: $"https://localhost:7195/images/noimage.png";
		   : $"https://localhost:7195/{ImageUrl.Substring(1)}";

		[Display(Name = "Tipo de usuario")]
		public UserType UserType { get; set; }

		[Display(Name = "Usuario")]
		public string FullName => $"{FirstName} {LastName}";

		public ICollection<Stock> Stocks { get; set; }

	}
}
