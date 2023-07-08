using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventrack.Data.Entities
{
	public class Stock
	{
		public int Id { get; set; }

		[Display(Name = "Articulo")]
		[MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public string Name { get; set; }

		[DataType(DataType.MultilineText)]
		[Display(Name = "Descripción")]
		[MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
		public string Description { get; set; }

		[DisplayFormat(DataFormatString = "{0:N2}")]
		[Display(Name = "Existencia")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public float StockQuantity { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		[DisplayFormat(DataFormatString = "{0:C2}")]
		[Display(Name = "Precio")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public decimal Price { get; set; }

		[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
		[Display(Name = "Fecha de ingreso")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public DateTime AdmissionDate { get; set; }

		[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
		[Display(Name = "Fecha de caducidad")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public DateTime ExpirationDate { get; set; }

		[Display(Name = "Foto")]
		public string? ImageUrl { get; set; }

		[Display(Name = "Foto")]
		public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
			? null
		   //: $"https://localhost:7195/images/noimage.png";
		   : $"https://localhost:7195/{ImageUrl.Substring(1)}";

		public User User { get; set; }

	}
}
