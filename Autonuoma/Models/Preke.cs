namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.Preke;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Preke' entity.
/// </summary>
public class Preke
{
	[DisplayName("ID Nr.")]
	[Required]
	public int ID { get; set; }

	[DisplayName("Prekės tipas")]
	[MaxLength(20)]
	[Required]
	public string Tipas { get; set; }

	[DisplayName("Prekės pavadinimas")]
	[MaxLength(40)]
	[Required]
	public string Pavadinimas { get; set; }

	[DisplayName("Prekės kaina")]
	[Range(0, double.MaxValue, ErrorMessage = "The value must be a positive number")]
	[Required]
	public double Kaina { get; set; }

	[DisplayName("Prekės įvertinimas")]
	[Range(1, 5, ErrorMessage = "The value must be a between 1 and 5")]
	[Required]
	public int Ivertinimas { get; set; }

	[DisplayName("Gamintojo ID")]
	[Required]
	public int FkGamintojas { get; set; }

	[DisplayName("Kategorijos ID")]
	[Required]
	public int FkKategorija { get; set; }
}

public class PrekeL
{
    [DisplayName("ID Nr.")]
    [Required]
    public int ID { get; set; }

    [DisplayName("Prekės tipas")]
    [MaxLength(20)]
    [Required]
    public string Tipas { get; set; }

    [DisplayName("Prekės pavadinimas")]
    [MaxLength(40)]
    [Required]
    public string Pavadinimas { get; set; }

    [DisplayName("Prekės kaina")]
    [Range(0, double.MaxValue, ErrorMessage = "The value must be a positive number")]
    [Required]
    public double Kaina { get; set; }

    [DisplayName("Prekės įvertinimas")]
    [Range(1, 5, ErrorMessage = "The value must be a between 1 and 5")]
    [Required]
    public int Ivertinimas { get; set; }

    [DisplayName("Gamintojas")]
    [Required]
    public string Gamintojas { get; set; }

    [DisplayName("Kategorija")]
    [Required]
    public string Kategorija { get; set; }
}

public class PrekeCE
{
    public class PrekeM
    {
        [DisplayName("ID Nr.")]
        [Required]
        public int ID { get; set; }

        [DisplayName("Prekės tipas")]
        [MaxLength(20)]
        [Required]
        public string Tipas { get; set; }

        [DisplayName("Prekės pavadinimas")]
        [MaxLength(40)]
        [Required]
        public string Pavadinimas { get; set; }

        [DisplayName("Prekės kaina")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be a positive number")]
        [Required]
        public double Kaina { get; set; }

        [DisplayName("Prekės įvertinimas")]
        [Range(1, 5, ErrorMessage = "The value must be a between 1 and 5")]
        [Required]
        public int Ivertinimas { get; set; }

        [DisplayName("Gamintojo ID")]
        [Required]
        public int FkGamintojas { get; set; }

        [DisplayName("Kategorijos ID")]
        [Required]
        public int FkKategorija { get; set; }
    }

    public class ListsM
    {
        public IList<SelectListItem> Gamintojai { get; set; }
        public IList<SelectListItem> Kategorijos { get; set; }
    }
    public PrekeM Preke { get; set; } = new PrekeM();

    public ListsM Lists { get; set; } = new ListsM();
}