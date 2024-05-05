namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models.Preke;


/// <summary>
/// Database operations related to 'darbutojas' entity.
/// </summary>
public class PrekeRepo
{
	public static List<PrekeL> List()
	{
		var query =
			$@"SELECT
				pr.Prekes_ID,
				pr.Tipas
				pr.Pavadinimas,
				pr.Kaina,
				pr.Ivertinimas,
				gamin.pavadinimas AS gamintojas,
				kateg.pavadinimas AS kategorija
			FROM
				`preke` pr
				LEFT JOIN `gamintojas` gamin ON gamin.id_Gamintojas=pr.fk_Gamintojasid_Gamintojas
				LEFT JOIN `kategorija` kateg ON kateg.id_Kategorija=pr.fk_Kategorijaid_Kategorija
			ORDER BY gamin.pavadinimas ASC, pr.Prekes_ID ASC";
		var drc = Sql.Query(query);

		var result = 
			Sql.MapAll<PrekeL>(drc, (dre, t) => {
				t.ID = dre.From<int>("Prekes_ID");
				t.Tipas = dre.From<string>("Tipas");
				t.Pavadinimas = dre.From<string>("Pavadinimas");
				t.Kaina = dre.From<double>("Kaina");
				t.Ivertinimas = dre.From<int>("Ivertinimas");
				t.Gamintojas = dre.From<string>("gamintojas");
				t.Kategorija = dre.From<string>("kategorija");
			});

		return result;
	}
	public static List<Preke> ListForGamintojas(int gamintojasID)
	{
		var query = $@"SELECT * FROM `preke` WHERE fk_Gamintojasid_Gamintojas=?gamintojasID ORDER BY Prekes_ID ASC";
		var drc =
			Sql.Query(query, args => {
				args.Add("?gamintojasID", gamintojasID);
			});

		var result = 
			Sql.MapAll<Preke>(drc, (dre, t) => {
				t.ID = dre.From<int>("Prekes_ID");
				t.Tipas = dre.From<string>("Tipas");
				t.Pavadinimas = dre.From<string>("Pavadinimas");
				t.Kaina = dre.From<double>("Kaina");
				t.Ivertinimas = dre.From<int>("Ivertinimas");
				t.FkGamintojas = dre.From<int>("fk_Gamintojasid_Gamintojas");
			});

		return result;
	}

	public static PrekeCE Find(int id)
	{
		var query = $@"SELECT * FROM `preke` WHERE Prekes_ID=?Prekes_ID";

		var drc = 
			Sql.Query(query, args => {
				args.Add("?Prekes_ID", id);
			});

		if( drc.Count > 0 )
		{
			var result = 
				Sql.MapOne<PrekeCE>(drc, (dre, t) => {
				t.Preke.ID = dre.From<int>("Prekes_ID");
				t.Preke.Tipas = dre.From<string>("Tipas");
				t.Preke.Pavadinimas = dre.From<string>("Pavadinimas");
				t.Preke.Kaina = dre.From<double>("Kaina");
				t.Preke.Ivertinimas = dre.From<int>("Ivertinimas");
				t.Preke.FkGamintojas = dre.From<int>("fk_Gamintojasid_Gamintojas");
				t.Preke.FkKategorija = dre.From<int>("fk_Kategorijaid_Kategorija");
				});
			
			return result;
		}

		return null;
	}

	public static PrekeL FindForDeletion(int id)
	{
		var query =
			$@"SELECT
				pr.Prekes_ID,
				pr.Tipas,
				pr.Pavadinimas,
				pr.Kaina,
				pr.Ivertinimas,
				gamin.pavadinimas AS gamintojas,
				kateg.pavadinimas AS kategorija
			FROM
				`preke` pr
				LEFT JOIN `gamintojas` gamin ON gamin.id_Gamintojas=pr.fk_Gamintojasid_Gamintojas
				LEFT JOIN `kategorija` kateg ON kateg.id_Kategorija=pr.fk_Kategorijaid_Kategorija
			WHERE
				pr.Prekes_ID = ?Prekes_ID";
		var drc =
			Sql.Query(query, args => {
				args.Add("?Prekes_ID", id);
			});

		var result = 
			Sql.MapOne<PrekeL>(drc, (dre, t) => {
				t.ID = dre.From<int>("Prekes_ID");
				t.Tipas = dre.From<string>("Tipas");
				t.Pavadinimas = dre.From<string>("Pavadinimas");
				t.Kaina = dre.From<double>("Kaina");
				t.Ivertinimas = dre.From<int>("Ivertinimas");
				t.Gamintojas = dre.From<string>("gamintojas");
				t.Kategorija = dre.From<string>("kategorija");
			});

		return result;
	}

	public static void Update(PrekeCE prek)
	{						
		var query = 
			$@"UPDATE `preke`
			SET 
				Tipas=?Tipas,
				Pavadinimas=?Pavadinimas, 
				Kaina=?Kaina,
				Ivertinimas=?Ivertinimas,
				fk_Gamintojasid_Gamintojas=?fk_Gamintojasid_Gamintojas,
				fk_Kategorijaid_Kategorija=?fk_Kategorijaid_Kategorija
			WHERE 
				Prekes_ID=?Prekes_ID";

		Sql.Update(query, args => {
			args.Add("?Tipas", prek.Preke.Tipas);
			args.Add("?Pavadinimas", prek.Preke.Pavadinimas);
			args.Add("?Kaina", prek.Preke.Kaina);
			args.Add("?Ivertinimas", prek.Preke.Ivertinimas);
			args.Add("?fk_Gamintojasid_Gamintojas", prek.Preke.FkGamintojas);
			args.Add("?fk_Kategorijaid_Kategorija", prek.Preke.FkKategorija);
			args.Add("?Prekes_ID", prek.Preke.ID);
		});				
	}

	public static void Insert(PrekeCE prek)
	{							
		var query = 
			$@"INSERT INTO `preke`
			(
				Prekes_ID,
				Tipas,
				Pavadinimas,
				Kaina,
				Ivertinimas,
				fk_Gamintojasid_Gamintojas,
				fk_Kategorijaid_Kategorija
			)
			VALUES(
				?Prekes_ID,
				?Tipas,
				?Pavadinimas,
				?Kaina,
				?Ivertinimas,
				?fk_Gamintojasid_Gamintojas,
				?fk_Kategorijaid_Kategorija
			)";

		Sql.Insert(query, args => {
			args.Add("?Pavadinimas", prek.Preke.Pavadinimas);
			args.Add("?Tipas", prek.Preke.Tipas);
			args.Add("?Kaina", prek.Preke.Kaina);
			args.Add("?Ivertinimas", prek.Preke.Ivertinimas);
			args.Add("?fk_Gamintojasid_Gamintojas", prek.Preke.FkGamintojas);
			args.Add("?fk_Kategorijaid_Kategorija", prek.Preke.FkKategorija);
			args.Add("?Prekes_ID", prek.Preke.ID);
		});				
	}

	public static void Delete(int id)
	{			
		var query = $@"DELETE FROM `preke` WHERE Prekes_ID=?Prekes_ID";
		Sql.Delete(query, args => {
			args.Add("?Prekes_ID", id);
		});			
	}
}
