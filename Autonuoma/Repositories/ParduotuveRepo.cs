namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;



/// <summary>
/// Database operations related to 'Aikstele' entity.
/// </summary>
public class ParduotuveRepo
{
	public static List<Parduotuve> List()
	{
		var query = $@"SELECT * FROM `parduotuve` ORDER BY id_Parduotuve ASC";
		var drc = Sql.Query(query);

		var result = 
			Sql.MapAll<Parduotuve>(drc, (dre, t) => {
				t.Pavadinimas = dre.From<string>("Pavadinimas");
				t.Miestas = dre.From<string>("Miestas");
				t.Adresas = dre.From<string>("Adresas");
				t.Pasto_kodas = dre.From<string>("Pasto kodas");
				t.Darbuotoju_skaicius = dre.From<int>("Darbuotoju_skaicius");
				t.Id = dre.From<int>("id_Parduotuve");
				t.fkSandelys = dre.From<int>("fk_Sandelysid_Sandelys");
			});
		return result;
	}
}
