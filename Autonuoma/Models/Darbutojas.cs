namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.Darbutojas;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Darbutojas' entity.
/// </summary>
public class Darbutojas
{
	[DisplayName("ID")]
	[MaxLength(10)]
	[Required]
	public int ID { get; set; }

	[DisplayName("Vardas")]
	[MaxLength(20)]
	[Required]
	public string Vardas { get; set; }

	[DisplayName("Pavardė")]
	[MaxLength(20)]
	[Required]
	public string Pavarde { get; set; }

    [DisplayName("Telefono numeris")]
    [Phone]
    [Required]
    public double Telefono_numeris { get; set; }

    [DisplayName("Elektroninis paštas")]
    [EmailAddress]
    [Required]
    public string El_Pasto_Adresas { get; set; }

	[DisplayName("Pareigos")]
	[MaxLength(15)]
	[Required]
	public string Pareigos { get; set; }

	[DisplayName("Asmens kodas")]
	[MaxLength(11)]
	[Required]
	public double Asmens_Kodas { get; set; }

	[DisplayName("Parduotuves ID")]
	[Required]
	public int FkParduotuve { get; set; }
}

public class DarbutojasL
{
    [DisplayName("ID")]
    [MaxLength(10)]
    [Required]
    public int ID { get; set; }

    [DisplayName("Vardas")]
    [MaxLength(20)]
    [Required]
    public string Vardas { get; set; }

    [DisplayName("Pavardė")]
    [MaxLength(20)]
    [Required]
    public string Pavarde { get; set; }

    [DisplayName("Telefono numeris")]
    [Phone]
    [Required]
    public double Telefono_numeris { get; set; }

    [DisplayName("Elektroninis paštas")]
    [EmailAddress]
    [Required]
    public string El_Pasto_Adresas { get; set; }

    [DisplayName("Pareigos")]
    [MaxLength(15)]
    [Required]
    public string Pareigos { get; set; }

    [DisplayName("Asmens kodas")]
    [MaxLength(11)]
    [Required]
    public double Asmens_Kodas { get; set; }

    [DisplayName("Parduotuve")]
    [Required]
    public string Parduotuve { get; set; }
}

public class DarbutojasCE
{
    public class DarbutojasM
    {
        [DisplayName("ID")]
        [MaxLength(10)]
        [Required]
        public int ID { get; set; }

        [DisplayName("Vardas")]
        [MaxLength(20)]
        [Required]
        public string Vardas { get; set; }

        [DisplayName("Pavardė")]
        [MaxLength(20)]
        [Required]
        public string Pavarde { get; set; }

        [DisplayName("Telefono numeris")]
        [Phone]
        [Required]
        public double Telefono_numeris { get; set; }

        [DisplayName("Elektroninis paštas")]
        [EmailAddress]
        [Required]
        public string El_Pasto_Adresas { get; set; }

        [DisplayName("Pareigos")]
        [MaxLength(15)]
        [Required]
        public string Pareigos { get; set; }

        [DisplayName("Asmens kodas")]
        [MaxLength(11)]
        [Required]
        public double Asmens_Kodas { get; set; }

        [DisplayName("Parduotuves ID")]
        [Required]
        public int FkParduotuve { get; set; }
    }

    public class ListsM
    {
        public IList<SelectListItem> Parduotuves { get; set; }
    }

    public DarbutojasM Darbutojas { get; set; } = new DarbutojasM();

    public ListsM Lists { get; set; } = new ListsM();
}