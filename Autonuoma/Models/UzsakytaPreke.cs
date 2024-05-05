namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.UzsakytaPreke;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'UzsakytaPreke' entity.
/// </summary>
public class UzsakytaPreke
{
	[DisplayName("Prekes kiekis")]
	[Range(0, int.MaxValue, ErrorMessage = "The value must be a positive number")]
	[Required]
	public int Kiekis { get; set; }

	[DisplayName("Uzsakytos Prekes ID")]
	[Required]
	public int Id { get; set; }

	[DisplayName("Prekes ID")]
	[Required]
	public int FkPreke { get; set; }

	[DisplayName("Uzsakymo ID")]
	[Required]
	public int FkUzsakymas { get; set; }
}

public class UzsakytaPrekeL
{
    [DisplayName("Prekes kiekis")]
    [Range(0, int.MaxValue, ErrorMessage = "The value must be a positive number")]
    [Required]
    public int Kiekis { get; set; }

    [DisplayName("Uzsakytos Prekes ID")]
    [Required]
    public int Id { get; set; }

    [DisplayName("Preke")]
    [Required]
    public string Preke { get; set; }

    [DisplayName("Uzsakymas")]
    [Required]
    public string Uzsakymas { get; set; }
}

public class UzsakytasPrekeCE
{
    public class UzsakytaPrekeM
    {
        [DisplayName("Prekes kiekis")]
        [Range(0, int.MaxValue, ErrorMessage = "The value must be a positive number")]
        [Required]
        public int Kiekis { get; set; }

        [DisplayName("Uzsakytos Prekes ID")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Prekes ID")]
        [Required]
        public int FkPreke { get; set; }

        [DisplayName("Uzsakymo ID")]
        [Required]
        public int FkUzsakymas { get; set; }
    }

    public class ListsM
    {
        public IList<SelectListItem> Prekes { get; set; }
        public IList<SelectListItem> Uzsakymai { get; set; }
    }

    public UzsakytaPrekeM UzsakPreke { get; set; } = new UzsakytaPrekeM();
    public ListsM Lists { get; set; } = new ListsM();
}