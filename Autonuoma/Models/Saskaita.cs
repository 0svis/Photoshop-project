namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.Saskaita;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'darbutojas' entity.
/// </summary>
public class Saskaita
{
	[DisplayName("ID Nr.")]
	[Required]
	public int ID { get; set; }

	[DisplayName("Data")]
	[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
	public DateTime Data { get; set; }

	[DisplayName("Suma")]
	[Range(0, double.MaxValue, ErrorMessage = "The value must be a positive number")]
	[Required]
	public double Suma { get; set; }

	[DisplayName("Būsena")]
	public int FkBusena { get; set; }

	[DisplayName("Užsakymo ID")]
	public int FkUzsakymas { get; set; }
}

public class SaskaitaL
{
	[DisplayName("ID Nr.")]
	[Required]
	public int ID { get; set; }

	[DisplayName("Data")]
	[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
	public DateTime Data { get; set; }

	[DisplayName("Suma")]
	[Range(0, double.MaxValue, ErrorMessage = "The value must be a positive number")]
	[Required]
	public double Suma { get; set; }

	[DisplayName("Būsena")]
	public string Busena { get; set; }

	[DisplayName("Užsakymo ID")]
	public int FkUzsakymas { get; set; }
}

/// <summary>
/// Model of 'Modelis' entity used in creation and editing forms.
/// </summary>
public class SaskaitaCE
{
	/// <summary>
	/// Entity data
	/// </summary>
	public class SaskaitaM
	{
		[DisplayName("ID Nr.")]
		[Required]
		public int ID { get; set; }

		[DisplayName("Data")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime Data { get; set; }

		[DisplayName("Suma")]
		[Range(0, double.MaxValue, ErrorMessage = "The value must be a positive number")]
		[Required]
		public double Suma { get; set; }

		[DisplayName("Būsena")]
		public int Busena { get; set; }

		[DisplayName("Užsakymo ID")]
		public int FkUzsakymas { get; set; }
	}

	/// <summary>
	/// Select lists for making drop downs for choosing values of entity fields.
	/// </summary>
	public class ListsM
	{
		public IList<SelectListItem> Busenos { get; set; }

		public IList<SelectListItem> Uzsakymai { get; set; }
	}

	/// <summary>
	/// Entity view.
	/// </summary>
	public SaskaitaM Sask { get; set; } = new SaskaitaM();

	/// <summary>
	/// Lists for drop down controls.
	/// </summary>
	public ListsM Lists { get; set; } = new ListsM();
}

/// <summary>
/// 'AutoBusena' enumerator in lists.
/// </summary>
public class Busena
{
	public int Id { get; set; }

	public string Pavadinimas { get; set; }
}