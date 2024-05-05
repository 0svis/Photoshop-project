namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Newtonsoft.Json;

using Org.Ktu.Isk.P175B602.Autonuoma.Models.UzsakymasF2;


/// <summary>
/// Database operations related to 'Sutartis' entity.
/// </summary>
public class UzsakymasF2Repo
{
	public static List<UzsakymasL> ListUzsakymas()
	{
		var query =
			$@"SELECT
				s.Uzsakymo_ID,
				s.Kaina as Kaina,
				s.DATA as DATA,
				CONCAT(n.Vardas,' ', n.Pavarde) as pirkejas,
				CONCAT(d.Vardas,' ',d.Pavarde) as darbutojas
			FROM
				`uzsakymas` s
				LEFT JOIN `pirkejas` n ON s.fk_PirkejasPirkejo_ID=n.Pirkejo_ID
				LEFT JOIN `darbutojas` d ON s.fk_DarbutojasDarbuotojo_ID=d.Darbuotojo_ID
			ORDER BY s.Uzsakymo_ID DESC";

		var drc = Sql.Query(query);

		var result =
			Sql.MapAll<UzsakymasL>(drc, (dre, t) => {
				t.Id = dre.From<int>("Uzsakymo_ID");
				t.Kaina = dre.From<decimal>("Kaina");
				t.Data = dre.From<DateTime>("Data");
				t.Pirkejas = dre.From<string>("Pirkejas");
				t.darbutojas = dre.From<string>("Darbutojas");
			});

		return result;
	}

	public static UzsakymasCE FindUzsakymasCE(int id)
	{
		var query = $@"SELECT * FROM `uzsakymas` WHERE Uzsakymo_ID=?Uzsakymo_ID";
		var drc =
			Sql.Query(query, args => {
				args.Add("?Uzsakymo_ID", id);
			});

		var result =
			Sql.MapOne<UzsakymasCE>(drc, (dre, t) => {
				//make a shortcut
				var uzs = t.Uzsakymas;

				//
				uzs.Id = dre.From<int>("Uzsakymo_ID");
				uzs.Kaina = dre.From<decimal>("Kaina");
				uzs.Data = dre.From<DateTime>("Data");
				uzs.FkPirkejas = dre.From<int>("fk_PirkejasPirkejo_ID");
				uzs.FkDarbutojas = dre.From<int>("fk_DarbutojasDarbuotojo_ID");
			});

		return result;
	}

	public static int InsertUzsakymas(UzsakymasCE uzsCE)
	{
		var query =
			$@"INSERT INTO `uzsakymas`
			(
				Kaina,
				DATA,
				fk_PirkejasPirkejo_ID,
				fk_DarbutojasDarbuotojo_ID
			)
			VALUES(
				?Kaina,
				?DATA,
				?fk_PirkejasPirkejo_ID,
				?fk_DarbutojasDarbuotojo_ID
			)";

		var ID =
			Sql.Insert(query, args => {
				//make a shortcut
				var uzs = uzsCE.Uzsakymas;

				//
				args.Add("?Kaina", uzs.Kaina);
				args.Add("?DATA", uzs.Data);
				args.Add("?fk_PirkejasPirkejo_ID", uzs.FkPirkejas);
				args.Add("?fk_DarbutojasDarbuotojo_ID", uzs.FkDarbutojas);
			});

		return (int)ID;
	}

	public static void UpdateUzsakymas(UzsakymasCE uzsCE)
	{
		var query =
			$@"UPDATE `uzsakymas`
			SET
				`Kaina` = ?Kaina,
				`Data` = ?Data,
				`fk_PirkejasPirkejo_ID` = ?fk_PirkejasPirkejo_ID,
				`fk_DarbutojasDarbuotojo_ID` = ?fk_DarbutojasDarbuotojo_ID
			WHERE Uzsakymo_ID=?Uzsakymo_ID";

		Sql.Update(query, args => {
			//make a shortcut
			var uzs = uzsCE.Uzsakymas;

			//
			args.Add("?Kaina", uzs.Kaina);
			args.Add("?Data", uzs.Data);
			args.Add("?fk_PirkejasPirkejo_ID", uzs.FkPirkejas);
			args.Add("?fk_DarbutojasDarbuotojo_ID", uzs.FkDarbutojas);
			args.Add("?Uzsakymo_ID", uzs.Id);
		});
	}

	public static void DeleteUzsakymas(int id)
	{
		var query = $@"DELETE FROM `uzsakymas` where Uzsakymo_ID=?Uzsakymo_ID";
		Sql.Delete(query, args => {
			args.Add("?Uzsakymo_ID", id);
		});
	}

	public static List<UzsakymasCE.UzsakytaPrekeM> ListUzsakytaPreke(int uzsakymasID)
	{
		var query =
			$@"SELECT prek.Kaina AS Kaina,
			prek.Pavadinimas AS Pavadinimas,
			prek.Prekes_ID AS PrekesID,
			uzs.Kiekis AS Kiekis
			FROM `uzsakyta_Preke` uzs
			LEFT JOIN `preke` prek ON prek.Prekes_ID=uzs.fk_PrekePrekes_ID
			WHERE fk_UzsakymasUzsakymo_ID = ?UzsakymasID
			ORDER BY fk_PrekePrekes_ID ASC";
		var drc = Sql.Query(query, args =>
		{
			args.Add("?UzsakymasID", uzsakymasID);
		});

		var result =
			Sql.MapAll<UzsakymasCE.UzsakytaPrekeM>(drc, (dre, t) => {
				t.Preke = dre.From<string>("Pavadinimas");
				t.PrekesId = dre.From<int>("PrekesID");
				t.Kiekis = dre.From<int>("Kiekis");
				t.Kaina = dre.From<int>("Kaina");
			});
		 for( int i = 0; i<result.Count; i++ )
			result[i].InListId = i;

		return result;
	}

	public static void InsertUzsakytaPreke(int uzsakymasId, UzsakymasCE.UzsakytaPrekeM up)
	{
		//
		var query =
			$@"INSERT INTO `uzsakyta_Preke`
				(
					fk_UzsakymasUzsakymo_ID,
					fk_PrekePrekes_ID,
					Kiekis
				)
				VALUES(
					?fk_UzsakymasUzsakymo_ID,
					?fk_PrekePrekes_ID,
					?Kiekis
				)";

		Sql.Insert(query, args => {
			args.Add("?fk_UzsakymasUzsakymo_ID", uzsakymasId);
			args.Add("?fk_PrekePrekes_ID", Convert.ToInt32(up.PrekesId));
			args.Add("?Kiekis", up.Kiekis);
		});
	}

	public static void DeleteUzsakytaPrekeForUzsakymas(int uzsakymas)
	{
		var query =
			$@"DELETE FROM a
			USING `uzsakyta_Preke` as a
			WHERE a.fk_UzsakymasUzsakymo_ID=?fkid";

		Sql.Delete(query, args => {
			args.Add("?fkid", uzsakymas);
		});
	}
}