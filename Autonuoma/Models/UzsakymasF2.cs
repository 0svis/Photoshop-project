namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.UzsakymasF2;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Uzsakymas' entity.
/// </summary>
/// 
public class Uzsakymas
{
    [DisplayName("ID Nr.")]
    [Required]
    public int ID { get; set; }

    [DisplayName("Kaina")]
    [Range(0, double.MaxValue, ErrorMessage = "The value must be a positive number")]
    [Required]
    public decimal Kaina { get; set; }

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
    [DisplayName("Uzsakymo ID")]
    [Required]
    public int Id { get; set; }

    [DisplayName("Prekės kaina")]
    [Range(0, double.MaxValue, ErrorMessage = "The value must be a positive number")]
    [Required]
    public decimal Kaina { get; set; }

    [DisplayName("Data")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    [Required]
    public DateTime Data { get; set; }

    [DisplayName("Pirkejas")]
    [Required]
    public string Pirkejas { get; set; }

    [DisplayName("Darbutojas")]
    [Required]
    public string darbutojas { get; set; }
}

public class UzsakymasCE
{
    public class UzsakymasM
    {
        [DisplayName("Uzsakymo ID")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Prekės kaina")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be a positive number")]
        [Required]
        public decimal Kaina { get; set; }

        [DisplayName("Data")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Required]
        public DateTime Data { get; set; }

        [DisplayName("Pirkejo ID")]
        [Required]
        public int FkPirkejas { get; set; }

        [DisplayName("Darbutojo ID")]
        [Required]
        public int FkDarbutojas { get; set; }
    }
    public class UzsakytaPrekeM
    {
        public int InListId { get; set; }

        public int PrekesId { get; set; }

        [DisplayName("Preke")]
        public string Preke { get; set; }

        [DisplayName("Kiekis")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The value must be a positive number")]
        public int Kiekis { get; set; }

        [DisplayName("Kaina")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be a positive number")]
        [Required]
        public decimal Kaina { get; set; }
    }

    public class ListsM
    {
        public IList<SelectListItem> Pirkejai { get; set; }
        public IList<SelectListItem> Darbutojai { get; set; }
        public IList<SelectListItem> Prekes { get; set; }
    }
    public UzsakymasM Uzsakymas { get; set; } = new UzsakymasM();
    public IList<UzsakytaPrekeM> UzsakytosPrekes { get; set; } = new List<UzsakytaPrekeM>();
    public ListsM Lists { get; set; } = new ListsM();
}