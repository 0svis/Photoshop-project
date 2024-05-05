namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;


public class KategorijaRepo
{
	public static List<Kategorija> List()
	{
		string query = $@"SELECT * FROM `kategorija` ORDER BY id_Kategorija ASC";
		var drc = Sql.Query(query);

		var result = 
			Sql.MapAll<Kategorija>(drc, (dre, t) => {
				t.Id = dre.From<int>("id_Kategorija");
				t.Pavadinimas = dre.From<string>("Pavadinimas");
			});

		return result;
	}

	public static Kategorija Find(int id)
	{
		var query = $@"SELECT * FROM `kategorija` WHERE id_Kategorija=?id_Kategorija";
		var drc = 
			Sql.Query(query, args => {
				args.Add("?id_Kategorija", id);
			});

		var result = 
			Sql.MapOne<Kategorija>(drc, (dre, t) => {
				t.Id = dre.From<int>("id_Kategorija");
				t.Pavadinimas = dre.From<string>("Pavadinimas");
			});

		return result;
	}

	public static void Update(Kategorija kategorija)
	{			
		var query = 
			$@"UPDATE `kategorija` 
			SET 
				Pavadinimas=?Pavadinimas 
			WHERE 
				id_Kategorija=?id_Kategorija";

		Sql.Update(query, args => {
			args.Add("?Pavadinimas", kategorija.Pavadinimas);
			args.Add("?id_Kategorija", kategorija.Id);
		});							
	}

	public static void Insert(Kategorija kategorija)
	{			
		var query = $@"INSERT INTO `kategorija` ( Pavadinimas ) VALUES ( ?Pavadinimas )";
		Sql.Insert(query, args => {
			args.Add("?Pavadinimas", kategorija.Pavadinimas);
		});
	}

	public static void Delete(int id)
	{			
		var query = $@"DELETE FROM `kategorija` where id_Kategorija=?id_Kategorija";
		Sql.Delete(query, args => {
			args.Add("?id_Kategorija", id);
		});			
	}
}
