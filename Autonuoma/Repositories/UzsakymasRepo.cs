namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models.Uzsakymas;


/// <summary>
/// Database operations related to 'darbutojas' entity.
/// </summary>
public class UzsakymasRepo
{
	public static List<UzsakymasL> List()
	{
		var query =
			$@"SELECT
				uzs.Uzsakymo_ID,
				uzs.Kaina,
				uzs.Data,
				CONCAT(pirk.Vardas,' ',pirk.Pavarde) as pirkejas,
				CONCAT(darb.Vardas,' ',darb.Pavarde) as darbutojas
			FROM
				`uzsakymas` uzs
				LEFT JOIN `pirkejas` pirk ON pirk.Pirkejo_ID=uzs.fk_PirkejasPirkejo_ID
				LEFT JOIN `darbutojas` darb ON darb.Darbuotojo_ID=uzs.fk_DarbutojasDarbuotojo_ID
			ORDER BY uzs.Uzsakymo_ID ASC";
		var drc = Sql.Query(query);

		var result = 
			Sql.MapAll<UzsakymasL>(drc, (dre, t) => {
				t.ID = dre.From<int>("Uzsakymo_ID");
				t.Kaina = dre.From<double>("Kaina");
				t.Data = dre.From<DateTime>("Data");
				t.Pirkejas = dre.From<string>("pirkejas");
				t.darbutojas = dre.From<string>("darbutojas");
			});

		return result;
	}

	public static List<UzsakymasL> ListLeft()
	{
		var query =
			$@"SELECT
				uzs.Uzsakymo_ID,
				uzs.Kaina,
				uzs.Data,
				CONCAT(pirk.Vardas,' ',pirk.Pavarde) as pirkejas,
				CONCAT(darb.Vardas,' ',darb.Pavarde) as darbutojas
			FROM
				`uzsakymas` uzs
				LEFT JOIN `darbutojas` darb ON darb.Darbuotojo_ID=uzs.fk_DarbutojasDarbuotojo_ID
				LEFT JOIN `pirkejas` pirk ON pirk.Pirkejo_ID=uzs.fk_PirkejasPirkejo_ID
				WHERE
				uzs.Uzsakymo_ID NOT IN (
				SELECT fk_UzsakymasUzsakymo_ID FROM `saskaita`
				)
			ORDER BY uzs.Uzsakymo_ID ASC";
		var drc = Sql.Query(query);

		var result =
			Sql.MapAll<UzsakymasL>(drc, (dre, t) => {
				t.ID = dre.From<int>("Uzsakymo_ID");
				t.Kaina = dre.From<double>("Kaina");
				t.Data = dre.From<DateTime>("Data");
				t.darbutojas = dre.From<string>("darbutojas");
				t.Pirkejas = dre.From<string>("pirkejas");
			});

		return result;
	}

	public static UzsakymasCE Find(int id)
	{
		var query = $@"SELECT * FROM `uzsakymas` WHERE Uzsakymo_ID=?Uzsakymo_ID";

		var drc = 
			Sql.Query(query, args => {
				args.Add("?Uzsakymo_ID", id);
			});

		if( drc.Count > 0 )
		{
			var result = 
				Sql.MapOne<UzsakymasCE>(drc, (dre, t) => {
				t.Uzsak.ID = dre.From<int>("Uzsakymo_ID");
				t.Uzsak.Kaina = dre.From<double>("Kaina");
				t.Uzsak.Data = dre.From<DateTime>("Data");
                t.Uzsak.FkPirkejas = dre.From<int>("fk_PirkejasPirkejo_ID");
                t.Uzsak.Fkdarbutojas = dre.From<int>("fk_DarbutojasDarbuotojo_ID");
				});
			
			return result;
		}

		return null;
	}

	public static UzsakymasL FindForDeletion(int id)
	{
		var query =
			$@"SELECT
				uzs.Uzsakymo_ID,
				uzs.Kaina,
				uzs.Data,
				CONCAT(pirk.Vardas,' ',pirk.Pavarde) as pirkejas,
				CONCAT(darb.Vardas,' ',darb.Pavarde) as darbutojas
			FROM
				`uzsakymas` uzs
				LEFT JOIN `pirkejas` pirk ON pirk.Pirkejo_ID=uzs.fk_PirkejasPirkejo_ID
				LEFT JOIN `darbutojas` darb ON darb.Darbuotojo_ID=uzs.fk_DarbutojasDarbuotojo_ID
			WHERE
				uzs.Uzsakymo_ID = ?Uzsakymo_ID";
		var drc =
			Sql.Query(query, args => {
				args.Add("?Uzsakymo_ID", id);
			});

		var result = 
			Sql.MapOne<UzsakymasL>(drc, (dre, t) => {
				t.ID = dre.From<int>("Uzsakymo_ID");
				t.Kaina = dre.From<double>("Kaina");
				t.Data = dre.From<DateTime>("Data");
                t.Pirkejas = dre.From<string>("pirkejas");
                t.darbutojas = dre.From<string>("darbutojas");
			});

		return result;
	}

	public static void Update(UzsakymasCE uzs)
	{						
		var query = 
			$@"UPDATE `uzsakymas`
			SET 
				Kaina=?Kaina,
				Data=?Data,
				fk_PirkejasPirkejo_ID=?fk_PirkejasPirkejo_ID,
				fk_DarbutojasDarbuotojo_ID=?fk_DarbutojasDarbuotojo_ID
			WHERE 
				Uzsakymo_ID=?Uzsakymo_ID";

		Sql.Update(query, args => {
            args.Add("?Uzsakymo_ID", uzs.Uzsak.ID);
            args.Add("?Kaina", uzs.Uzsak.Kaina);
			args.Add("?Data", uzs.Uzsak.Data);
            args.Add("?fk_PirkejasPirkejo_ID", uzs.Uzsak.FkPirkejas);
            args.Add("?fk_DarbutojasDarbuotojo_ID", uzs.Uzsak.Fkdarbutojas);
		});				
	}

	public static void Insert(UzsakymasCE uzs)
	{							
		var query = 
			$@"INSERT INTO `uzsakymas`
			(
				Uzsakymo_ID,
				Kaina,
				Data,
				fk_PirkejasPirkejo_ID,
				fk_DarbutojasDarbuotojo_ID
			)
			VALUES(
				?Uzsakymo_ID,
				?Kaina,
				?Data,
				?fk_PirkejasPirkejo_ID,
				?fk_DarbutojasDarbuotojo_ID
			)";

		Sql.Insert(query, args => {
            args.Add("?Uzsakymo_ID", uzs.Uzsak.ID);
            args.Add("?Kaina", uzs.Uzsak.Kaina);
			args.Add("?Data", uzs.Uzsak.Data);
            args.Add("?fk_PirkejasPirkejo_ID", uzs.Uzsak.FkPirkejas);
            args.Add("?fk_DarbutojasDarbuotojo_ID", uzs.Uzsak.Fkdarbutojas);
		});				
	}

	public static void Delete(int id)
	{			
		var query = $@"DELETE FROM `uzsakymas` WHERE Uzsakymo_ID=?Uzsakymo_ID";
		Sql.Delete(query, args => {
			args.Add("?Uzsakymo_ID", id);
		});			
	}
}
