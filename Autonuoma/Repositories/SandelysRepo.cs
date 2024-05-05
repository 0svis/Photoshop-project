namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;



/// <summary>
/// Database operations related to 'Aikstele' entity.
/// </summary>
public class SandelysRepo
{
	public static List<Sandelys> List()
	{
		var query = $@"SELECT * FROM `sandelys` ORDER BY id_Sandelys ASC";
		var drc = Sql.Query(query);

		var result = 
			Sql.MapAll<Sandelys>(drc, (dre, t) => {
				t.Miestas = dre.From<string>("Miestas");
				t.Adresas = dre.From<string>("Adresas");
				t.Pasto_kodas = dre.From<string>("Pasto kodas");
				t.Darbuotoju_skaicius = dre.From<int>("Darbuotoju_skaicius");
				t.Id = dre.From<int>("id_Sandelys");
			});
		return result;
	}
}
