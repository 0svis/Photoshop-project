namespace Org.Ktu.Isk.P175B602.Autonuoma.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Pirkejas' entity.
/// </summary>
public class Pirkejas
{
	[DisplayName("Pirkėjo ID")]
	[Required]
	public int Id { get; set; }

	[DisplayName("Vardas")]
	[MaxLength(20)]
	[Required]
	public string Vardas { get; set; }

	[DisplayName("Pavardė")]
	[MaxLength(25)]
	[Required]
	public string Pavarde { get; set; }

	[DisplayName("Telefono numeris")]
	[Required]
	public double Telefono_numeris { get; set; }

	[DisplayName("Elektroninis paštas")]
	[EmailAddress]
	[Required]
	public string El_Pasto_Adresas { get; set; }

	[DisplayName("Miestas")]
	[MaxLength(25)]
	[Required]
	public string Miestas { get; set; }

	[DisplayName("Adresas")]
	[MaxLength(40)]
	[Required]
	public string Adresas { get; set; }

	[DisplayName("Pašto adresas")]
	[MaxLength(7)]
	[Required]
	public string Pasto_Kodas { get; set; }
}