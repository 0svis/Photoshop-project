namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.PilnasUzsakymas;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'darbutojas' entity.
/// </summary>
public class PilnasUzsakymas
{
	public int Uzsakymo_ID { get; set; }

	[DisplayName("Kiekis")]
	public int Kiekis { get; set; }

	[DisplayName("Pavadinimas")]
	public string PrekesPav { get; set; }

	[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
	public DateTime Data { get; set; }
	public decimal Kaina { get; set; }
	public int PirkejoID{get;set;}
	public string PirkejoVardas { get; set; }
	public string PirkejoPavarde { get; set; }
}

public class Report
{
	[DataType(DataType.DateTime)]
	[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
	public DateTime? DateFrom { get; set; }

	[DataType(DataType.DateTime)]
	[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
	public DateTime? DateTo { get; set; }

	public List<PilnasUzsakymas> PilniUzsakymai { get; set; }

	public decimal VisoSuma { get; set; }
}
