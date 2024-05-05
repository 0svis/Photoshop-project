namespace Org.Ktu.Isk.P175B602.Autonuoma.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Aikstele' entity.
/// </summary>
public class Sandelys
{
	public string Miestas { get; set; }

	public string Adresas { get; set; }

	public string Pasto_kodas { get; set; }
	
	public int Darbuotoju_skaicius { get; set; }

	public int Id { get; set; }	
}

public class Talpina
{
	public int FkSandelys { get; set; }

	public int FkPreke { get; set; }	
}