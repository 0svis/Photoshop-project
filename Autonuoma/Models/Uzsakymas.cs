namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.Uzsakymas;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'darbutojas' entity.
/// </summary>
public class Uzsakymas
{
	[DisplayName("ID Nr.")]
	[Required]
	public int ID { get; set; }

	[DisplayName("Kaina")]
	[Range(0, double.MaxValue, ErrorMessage = "The value must be a positive number")]
	[Required]
	public double Kaina { get; set; }
	
	[DisplayName("Data")]
	[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
	public DateTime Data { get; set; }

	[DisplayName("Pirkėjo ID")]
	public int FkPirkejas { get; set; }

    [DisplayName("Darbuotojo ID")]
    public int Fkdarbutojas { get; set; }

}

public class UzsakymasL
{
	[DisplayName("ID Nr.")]
	[Required]
	public int ID { get; set; }

	[DisplayName("Kaina")]
	[Range(0, double.MaxValue, ErrorMessage = "The value must be a positive number")]
	[Required]
	public double Kaina { get; set; }
	
	[DisplayName("Data")]
	[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
	public DateTime Data { get; set; }

    [DisplayName("Pirkėjas")]
    public string Pirkejas { get; set; }

    [DisplayName("darbutojas")]
	public string darbutojas { get; set; }
}

/// <summary>
/// Model of 'Modelis' entity used in creation and editing forms.
/// </summary>
public class UzsakymasCE
{
	/// <summary>
	/// Entity data
	/// </summary>
	public class UzsakymasM
	{
		[DisplayName("ID Nr.")]
		[Required]
		public int ID { get; set; }

		[DisplayName("Kaina")]
		[Range(0, double.MaxValue, ErrorMessage = "The value must be a positive number")]
		[Required]
		public double Kaina { get; set; }
	
		[DisplayName("Data")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime Data { get; set; }

        [DisplayName("Pirkėjo ID")]
        public int FkPirkejas { get; set; }

        [DisplayName("Darbuotojo ID")]
		public int Fkdarbutojas { get; set; }
	}

	/// <summary>
	/// Select lists for making drop downs for choosing values of entity fields.
	/// </summary>
	public class ListsM
	{
		public IList<SelectListItem> Pirkejai { get; set; }
		public IList<SelectListItem> Darbutojai { get; set; }
	}

	/// <summary>
	/// Entity view.
	/// </summary>
	public UzsakymasM Uzsak { get; set; } = new UzsakymasM();

	/// <summary>
	/// Lists for drop down controls.
	/// </summary>
	public ListsM Lists { get; set; } = new ListsM();
}