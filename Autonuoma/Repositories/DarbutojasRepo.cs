namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models.Darbutojas;


/// <summary>
/// Database operations related to 'Darbutojas' entity.
/// </summary>
public class DarbutojasRepo
{
	public static List<DarbutojasL> List()
	{
		var query =
			$@"SELECT
				db.Darbuotojo_ID,
				db.Vardas,
				db.Pavarde,
				db.Telefono_numeris,
				db.El_Pasto_Adresas,
				db.Pareigos,
				db.Asmens_kodas,
				pard.pavadinimas AS parduotuve
			FROM
				`darbutojas` db
				LEFT JOIN `parduotuve` pard ON pard.id_Parduotuve=db.fk_Parduotuveid_Parduotuve
			ORDER BY pard.pavadinimas ASC, db.Darbuotojo_ID ASC";
		var drc = Sql.Query(query);

		var result = 
			Sql.MapAll<DarbutojasL>(drc, (dre, t) => {
				t.ID = dre.From<int>("Darbuotojo_ID");
				t.Vardas = dre.From<string>("Vardas");
				t.Pavarde = dre.From<string>("Pavarde");
				t.Telefono_numeris = dre.From<double>("Telefono_numeris");
				t.El_Pasto_Adresas = dre.From<string>("El_Pasto_Adresas");
				t.Pareigos = dre.From<string>("Pareigos");
				t.Asmens_Kodas = dre.From<double>("Asmens_kodas");
				t.Parduotuve = dre.From<string>("parduotuve");
			});

		return result;
	}

	public static DarbutojasCE Find(int id)
	{
		var query = $@"SELECT * FROM `darbutojas` WHERE Darbuotojo_ID=?Darbuotojo_ID";

		var drc = 
			Sql.Query(query, args => {
				args.Add("?Darbuotojo_ID", id);
			});

		if( drc.Count > 0 )
		{
			var result = 
				Sql.MapOne<DarbutojasCE>(drc, (dre, t) => {
				t.Darbutojas.ID = dre.From<int>("Darbuotojo_ID");
				t.Darbutojas.Vardas = dre.From<string>("Vardas");
				t.Darbutojas.Pavarde = dre.From<string>("Pavarde");
				t.Darbutojas.Telefono_numeris = dre.From<double>("Telefono_numeris");
				t.Darbutojas.El_Pasto_Adresas = dre.From<string>("El_Pasto_Adresas");
				t.Darbutojas.Pareigos = dre.From<string>("Pareigos");
				t.Darbutojas.Asmens_Kodas = dre.From<double>("Asmens_kodas");
				t.Darbutojas.FkParduotuve = dre.From<int>("fk_Parduotuveid_Parduotuve");
				});
			
			return result;
		}

		return null;
	}

	public static DarbutojasL FindForDeletion(int id)
	{
		var query =
			$@"SELECT
				db.Darbuotojo_ID,
				db.Vardas,
				db.Pavarde,
				db.Telefono_numeris,
				db.El_Pasto_Adresas,
				db.Pareigos,
				db.Asmens_kodas,
				pard.pavadinimas AS parduotuve
			FROM
				`darbutojas` db
				LEFT JOIN `parduotuve` pard ON pard.id_Parduotuve=db.fk_Parduotuveid_Parduotuve
			WHERE
				db.Darbuotojo_ID = ?Darbuotojo_ID";
		var drc =
			Sql.Query(query, args => {
				args.Add("?Darbuotojo_ID", id);
			});

		var result = 
			Sql.MapOne<DarbutojasL>(drc, (dre, t) => {
				t.ID = dre.From<int>("Darbuotojo_ID");
				t.Vardas = dre.From<string>("Vardas");
				t.Pavarde = dre.From<string>("Pavarde");
				t.Telefono_numeris = dre.From<double>("Telefono_numeris");
				t.El_Pasto_Adresas = dre.From<string>("El_Pasto_Adresas");
				t.Pareigos = dre.From<string>("Pareigos");
				t.Asmens_Kodas = dre.From<double>("Asmens_kodas");
				t.Parduotuve = dre.From<string>("parduotuve");
			});

		return result;
	}

	public static void Update(DarbutojasCE darb)
	{						
		var query = 
			$@"UPDATE `darbutojas`
			SET 
				Vardas=?Vardas, 
				Pavarde=?Pavarde,
				Telefono_numeris=?Telefono_numeris,
				El_Pasto_Adresas=?El_Pasto_Adresas,
				Pareigos=?Pareigos,
				Asmens_kodas=?Asmens_kodas,
				fk_Parduotuveid_Parduotuve=?fk_Parduotuveid_Parduotuve 
			WHERE 
				Darbuotojo_ID=?Darbuotojo_ID";

		Sql.Update(query, args => {
			args.Add("?Vardas", darb.Darbutojas.Vardas);
			args.Add("?Pavarde", darb.Darbutojas.Pavarde);
			args.Add("?Telefono_numeris", darb.Darbutojas.Telefono_numeris);
			args.Add("?El_pasto_adresas", darb.Darbutojas.El_Pasto_Adresas);
			args.Add("?Pareigos", darb.Darbutojas.Pareigos);
			args.Add("?Asmens_kodas", darb.Darbutojas.Asmens_Kodas);
			args.Add("?fk_Parduotuveid_Parduotuve", darb.Darbutojas.FkParduotuve);
			args.Add("?Darbuotojo_ID", darb.Darbutojas.ID);
		});				
	}

	public static void Insert(DarbutojasCE darb)
	{							
		var query = 
			$@"INSERT INTO `darbutojas`
			(
				Darbuotojo_ID,
				Vardas,
				Pavarde,
				Telefono_numeris,
				El_pasto_adresas,
				Pareigos,
				Asmens_kodas,
				fk_Parduotuveid_Parduotuve
			)
			VALUES(
				?Darbuotojo_ID,
				?Vardas,
				?Pavarde,
				?Telefono_numeris,
				?El_pasto_adresas,
				?Pareigos,
				?Asmens_kodas,
				?fk_Parduotuveid_Parduotuve
			)";

		Sql.Insert(query, args => {
			args.Add("?Vardas", darb.Darbutojas.Vardas);
			args.Add("?Pavarde", darb.Darbutojas.Pavarde);
			args.Add("?Telefono_numeris", darb.Darbutojas.Telefono_numeris);
			args.Add("?El_pasto_adresas", darb.Darbutojas.El_Pasto_Adresas);
			args.Add("?Pareigos", darb.Darbutojas.Pareigos);
			args.Add("?Asmens_kodas", darb.Darbutojas.Asmens_Kodas);
			args.Add("?fk_Parduotuveid_Parduotuve", darb.Darbutojas.FkParduotuve);
			args.Add("?Darbuotojo_ID", darb.Darbutojas.ID);
		});				
	}

	public static void Delete(int id)
	{			
		var query = $@"DELETE FROM `darbutojas` WHERE Darbuotojo_ID=?Darbuotojo_ID";
		Sql.Delete(query, args => {
			args.Add("?Darbuotojo_ID", id);
		});			
	}
}
