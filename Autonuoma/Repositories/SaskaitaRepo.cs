namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models.Saskaita;


/// <summary>
/// Database operations related to 'darbutojas' entity.
/// </summary>
public class SaskaitaRepo
{
	public static List<SaskaitaL> List()
	{
		var query =
			$@"SELECT
				sas.Saskaitos_ID,
				sas.Data,
				sas.Suma,
				b.name AS busena,
				sas.fk_UzsakymasUzsakymo_ID
			FROM
				`saskaita` sas
				LEFT JOIN `busena` b ON b.id_Busena=sas.Busena
			ORDER BY sas.Saskaitos_ID ASC";
		var drc = Sql.Query(query);

		var result = 
			Sql.MapAll<SaskaitaL>(drc, (dre, t) => {
				t.ID = dre.From<int>("Saskaitos_ID");
				t.Data = dre.From<DateTime>("Data");
				t.Suma = dre.From<double>("Suma");
				t.Busena = dre.From<string>("busena");
				t.FkUzsakymas = dre.From<int>("fk_UzsakymasUzsakymo_ID");
			});

		return result;
	}

	public static SaskaitaCE Find(int id)
	{
		var query = $@"SELECT * FROM `saskaita` WHERE Saskaitos_ID=?Saskaitos_ID";

		var drc = 
			Sql.Query(query, args => {
				args.Add("?saskaitos_ID", id);
			});

		if( drc.Count > 0 )
		{
			var result = 
				Sql.MapOne<SaskaitaCE>(drc, (dre, t) => {
				t.Sask.ID = dre.From<int>("Saskaitos_ID");
				t.Sask.Data = dre.From<DateTime>("Data");
				t.Sask.Suma = dre.From<double>("Suma");
				t.Sask.Busena = dre.From<int>("Busena");
				t.Sask.FkUzsakymas = dre.From<int>("fk_UzsakymasUzsakymo_ID");
				});
			
			return result;
		}

		return null;
	}

	public static SaskaitaCE FindFkUzsakymas(int id)
	{
		var query = $@"SELECT * FROM `saskaita` WHERE fk_UzsakymasUzsakymo_ID=?fk_UzsakymasUzsakymo_ID";

		var drc =
			Sql.Query(query, args => {
				args.Add("?fk_UzsakymasUzsakymo_ID", id);
			});

		if (drc.Count > 0)
		{
			var result =
				Sql.MapOne<SaskaitaCE>(drc, (dre, t) => {
					t.Sask.ID = dre.From<int>("Saskaitos_ID");
					t.Sask.Data = dre.From<DateTime>("Data");
					t.Sask.Suma = dre.From<double>("Suma");
					t.Sask.Busena = dre.From<int>("Busena");
					t.Sask.FkUzsakymas = dre.From<int>("fk_UzsakymasUzsakymo_ID");
				});

			return result;
		}

		return null;
	}

	public static SaskaitaL FindForDeletion(int id)
	{
		var query =
			$@"SELECT
				sas.Saskaitos_ID,
				sas.Data,
				sas.Suma,
				b.name AS busena,
				sas.fk_UzsakymasUzsakymo_ID
			FROM
				`saskaita` sas
				LEFT JOIN `busena` b ON b.id_Busena=sas.Busena
			WHERE
				sas.Saskaitos_ID = ?Saskaitos_ID";
		var drc =
			Sql.Query(query, args => {
				args.Add("?Saskaitos_ID", id);
			});

		var result = 
			Sql.MapOne<SaskaitaL>(drc, (dre, t) => {
				t.ID = dre.From<int>("Saskaitos_ID");
				t.Data = dre.From<DateTime>("Data");
				t.Suma = dre.From<double>("Suma");
				t.Busena = dre.From<string>("busena");
				t.FkUzsakymas = dre.From<int>("fk_UzsakymasUzsakymo_ID");
			});

		return result;
	}

	public static void Update(SaskaitaCE uzs)
	{						
		var query = 
			$@"UPDATE `saskaita`
			SET 
				Data=?Data,
				Suma=?Suma,
				Busena=?Busena,
				fk_UzsakymasUzsakymo_ID=?fk_UzsakymasUzsakymo_ID
			WHERE 
				Saskaitos_ID=?Saskaitos_ID";

		Sql.Update(query, args => {
			args.Add("?Data", uzs.Sask.Data);
			args.Add("?Suma", uzs.Sask.Suma);
			args.Add("?Busena", uzs.Sask.Busena);
			args.Add("?fk_UzsakymasUzsakymo_ID", uzs.Sask.FkUzsakymas);
			args.Add("?Saskaitos_ID", uzs.Sask.ID);
		});				
	}

	public static void Insert(SaskaitaCE uzs)
	{							
		var query = 
			$@"INSERT INTO `saskaita`
			(
				Saskaitos_ID,
				Data,
				Suma,
				Busena,
				fk_UzsakymasUzsakymo_ID
			)
			VALUES(
				?Saskaitos_ID,
				?Data,
				?Suma,
				?Busena,
				?fk_UzsakymasUzsakymo_ID
			)";

		Sql.Insert(query, args => {
			args.Add("?Data", uzs.Sask.Data);
			args.Add("?Suma", uzs.Sask.Suma);
			args.Add("?Busena", uzs.Sask.Busena);
			args.Add("?fk_UzsakymasUzsakymo_ID", uzs.Sask.FkUzsakymas);
			args.Add("?Saskaitos_ID", uzs.Sask.ID);
		});				
	}

	public static void Delete(int id)
	{			
		var query = $@"DELETE FROM `saskaita` WHERE Saskaitos_ID=?Saskaitos_ID";
		Sql.Delete(query, args => {
			args.Add("?Saskaitos_ID", id);
		});			
	}

	public static List<Busena> ListBusena()
	{
		var query = $@"SELECT * FROM `busena` ORDER BY id_Busena ASC";
		var drc = Sql.Query(query);

		var result =
			Sql.MapAll<Busena>(drc, (dre, t) => {
				t.Id = dre.From<int>("id_Busena");
				t.Pavadinimas = dre.From<string>("name");
			});

		return result;
	}
}
