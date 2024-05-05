namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;


/// <summary>
/// Database operations related to 'Klientas' entity.
/// </summary>
public class PirkejasRepo
{
	public static List<Pirkejas> List()
	{
		var query = $@"SELECT * FROM `pirkejas` ORDER BY Pirkejo_ID ASC";
		var drc = Sql.Query(query);

		var result = 
			Sql.MapAll<Pirkejas>(drc, (dre, t) => {
				t.Id = dre.From<int>("Pirkejo_ID");
				t.Vardas = dre.From<string>("Vardas");
				t.Pavarde = dre.From<string>("Pavarde");
				t.Telefono_numeris = dre.From<double>("Telefono_numeris");
				t.El_Pasto_Adresas = dre.From<string>("El_pasto_adresas");
				t.Miestas = dre.From<string>("Miestas");
				t.Adresas = dre.From<string>("Adresas");
				t.Pasto_Kodas = dre.From<string>("Pasto_Kodas");
			});

		return result;
	}

	public static Pirkejas Find(int id)
	{
		var query = $@"SELECT * FROM `pirkejas` WHERE Pirkejo_ID=?Pirkejo_ID";

		var drc =
			Sql.Query(query, args => {
				args.Add("?Pirkejo_ID", id);
			});

		if( drc.Count > 0 )
		{
			var result = 
				Sql.MapOne<Pirkejas>(drc, (dre, t) => {
                    t.Id = dre.From<int>("Pirkejo_ID");
                    t.Vardas = dre.From<string>("Vardas");
                    t.Pavarde = dre.From<string>("Pavarde");
                    t.Telefono_numeris = dre.From<double>("Telefono_numeris");
                    t.El_Pasto_Adresas = dre.From<string>("El_pasto_adresas");
                    t.Miestas = dre.From<string>("Miestas");
                    t.Adresas = dre.From<string>("Adresas");
                    t.Pasto_Kodas = dre.From<string>("Pasto_Kodas");
                });

			return result;
		}

		return null;
	}

	public static void Insert(Pirkejas pirkejas)
	{
		var query =
			$@"INSERT INTO `pirkejas`
			(
				Pirkejo_ID,
				Vardas,
				Pavarde,
				Telefono_numeris,
				El_pasto_adresas,
				Miestas,
				Adresas,
				Pasto_Kodas
			)
			VALUES(
				?Pirkejo_ID,
				?Vardas,
				?Pavarde,
				?Telefono_numeris,
				?El_pasto_adresas,
				?Miestas,
				?Adresas,
				?Pasto_Kodas
			)";

		Sql.Insert(query, args => {
			args.Add("?Pirkejo_ID", pirkejas.Id);
			args.Add("?Vardas", pirkejas.Vardas);
			args.Add("?Pavarde", pirkejas.Pavarde);
			args.Add("?Telefono_numeris", pirkejas.Telefono_numeris);
			args.Add("?El_pasto_adresas", pirkejas.El_Pasto_Adresas);
			args.Add("?Miestas", pirkejas.Miestas);
			args.Add("?Adresas", pirkejas.Adresas);
			args.Add("?Pasto_Kodas", pirkejas.Pasto_Kodas);
		});
	}

	public static void Update(Pirkejas pirkejas)
	{
		var query =
			$@"UPDATE `pirkejas`
			SET
				Vardas=?Vardas,
				Pavarde=?Pavarde,
				Telefono_numeris=?Telefono_numeris,
				El_pasto_adresas=?El_pasto_adresas,
				Miestas=?Miestas,
				Adresas=?Adresas,
				Pasto_Kodas=?Pasto_Kodas
			WHERE
				Pirkejo_ID=?Pirkejo_ID";

		Sql.Update(query, args => {
			args.Add("?Pirkejo_ID", pirkejas.Id);
			args.Add("?Vardas", pirkejas.Vardas);
			args.Add("?Pavarde", pirkejas.Pavarde);
			args.Add("?Telefono_numeris", pirkejas.Telefono_numeris);
			args.Add("?El_pasto_adresas", pirkejas.El_Pasto_Adresas);
			args.Add("?Miestas", pirkejas.Miestas);
			args.Add("?Adresas", pirkejas.Adresas);
		});
	}

	public static void Delete(int id)
	{
		var query = $@"DELETE FROM `pirkejas` WHERE Pirkejo_ID=?Pirkejo_ID";
		Sql.Delete(query, args => {
			args.Add("?Pirkejo_ID", id);
		});
	}
}
