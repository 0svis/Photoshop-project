namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;



/// <summary>
/// Database operations related to 'Aikstele' entity.
/// </summary>
public class GamintojasRepo
{
	public static List<Gamintojas> List()
	{
		var query = $@"SELECT * FROM `gamintojas` ORDER BY id_Gamintojas ASC";
		var drc = Sql.Query(query);

		var result = 
			Sql.MapAll<Gamintojas>(drc, (dre, t) => {
				t.Pavadinimas = dre.From<string>("Pavadinimas");
				t.Salis = dre.From<string>("Salis");
				t.Adresas = dre.From<string>("Adresas");
				t.Id = dre.From<int>("id_Gamintojas");
			});
		return result;
	}

	public static List<Talpina> ListTalpina()
	{
		var query = $@"SELECT * FROM `talpina` ORDER BY fk_Sandelysid_Sandelys ASC";
		var drc = Sql.Query(query);

		var result = 
			Sql.MapAll<Talpina>(drc, (dre, t) => {
				t.FkSandelys = dre.From<int>("fk_Sandelysid_Sandelys");
				t.FkPreke = dre.From<int>("fk_PrekePrekes_ID");
			});
		return result;
	}
}