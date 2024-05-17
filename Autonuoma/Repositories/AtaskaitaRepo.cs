namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using ContractsReport = Org.Ktu.Isk.P175B602.Autonuoma.Models.PilnasUzsakymas;


/// <summary>
/// Database operations related to reports.
/// </summary>
public class AtaskaitaRepo
{
	public static List<ContractsReport.PilnasUzsakymas> GetContracts(DateTime? dateFrom, DateTime? dateTo, string busen, int ivert, string pirk)
	{
		var query = $@"SELECT 
				uzs.Uzsakymo_ID,
                up.fk_PrekePrekes_ID,
				prek.Pavadinimas, 
				SUM(up.Kiekis) AS Kiekis,
				uzs.fk_PirkejasPirkejo_ID AS PirkejoID,
				UPPER(CONCAT(pirk.Vardas,' ',pirk.Pavarde)) AS Pirkejas,
				SUM(prek.Kaina * up.Kiekis) AS Kaina,	
				prek.Kaina AS PrekKaina,
				uzs.DATA AS Data,
				kat.Pavadinimas AS Kategorija,
				gam.Pavadinimas AS Gamintojas,
				prek.Ivertinimas AS Ivertinimas,
				bus.NAME AS saskaita,
				bs1.bendra_suma AS BendraKaina,
				bs1.PrekiuKiekis AS PrekiuKiekis,
				bs1.MinIvertinimas AS MinIvertinimas
			FROM 
				uzsakymas uzs
			JOIN pirkejas pirk ON uzs.fk_PirkejasPirkejo_ID = pirk.Pirkejo_ID
			JOIN uzsakyta_preke up ON uzs.Uzsakymo_ID = up.fk_UzsakymasUzsakymo_ID
			JOIN preke prek ON up.fk_PrekePrekes_ID = prek.Prekes_ID
			JOIN kategorija kat ON prek.fk_Kategorijaid_Kategorija = kat.id_Kategorija
			JOIN gamintojas gam ON prek.fk_Gamintojasid_Gamintojas = gam.id_Gamintojas
			LEFT JOIN saskaita sas ON uzs.Uzsakymo_ID = sas.fk_UzsakymasUzsakymo_ID
			LEFT JOIN busena bus ON sas.Busena = bus.id_Busena
			LEFT JOIN
					(
						SELECT
							uzs1.Uzsakymo_ID,
							SUM(prek1.Kaina * up1.Kiekis) as bendra_suma,
							COUNT(prek1.Prekes_ID) AS PrekiuKiekis,
							Min(prek1.Ivertinimas) AS MinIvertinimas
						FROM `uzsakymas` uzs1
						LEFT JOIN uzsakyta_preke up1 ON uzs1.Uzsakymo_ID = up1.fk_UzsakymasUzsakymo_ID
						JOIN preke prek1 ON up1.fk_PrekePrekes_ID = prek1.Prekes_ID
						JOIN pirkejas pirk1 ON uzs1.fk_PirkejasPirkejo_ID = pirk1.Pirkejo_ID
						WHERE
							uzs1.Data >= IFNULL(?nuo, uzs1.Data) AND uzs1.Data <= IFNULL(?iki, uzs1.Data) AND prek1.Ivertinimas >= IFNULL(?ivert, prek1.Ivertinimas)
							AND CONCAT(pirk1.Vardas,' ',pirk1.Pavarde) LIKE CONCAT(IFNULL(?pirk, ''), '%')
					GROUP BY uzs1.Uzsakymo_ID
					) AS bs1
					ON bs1.Uzsakymo_ID = uzs.Uzsakymo_ID
			WHERE 
				uzs.Data >= IFNULL(?nuo, uzs.Data) AND uzs.Data <= IFNULL(?iki, uzs.Data)
				AND prek.Ivertinimas >= IFNULL(?ivert, prek.Ivertinimas) AND CONCAT(pirk.Vardas,' ',pirk.Pavarde) LIKE CONCAT(IFNULL(?pirk, ''), '%')
				AND (?busen IS NULL OR ?busen = IFNULL(bus.Name,'Nėra saskaitos'))
            GROUP BY prek.Prekes_ID, uzs.Uzsakymo_ID, pirk.Pirkejo_ID
			ORDER BY  
				pirk.Pirkejo_ID, uzs.Data ASC, uzs.Uzsakymo_ID;";

		var drc =
			Sql.Query(query, args => {
				args.Add("?nuo", dateFrom);
				args.Add("?iki", dateTo);
				args.Add("?busen", busen);
				args.Add("?ivert", ivert);
				args.Add("?pirk", pirk);
			});

		var result = 
			Sql.MapAll<ContractsReport.PilnasUzsakymas>(drc, (dre, t) => {
				t.Uzsakymo_ID = dre.From<int>("Uzsakymo_ID");
        		t.Kiekis = dre.From<int>("Kiekis");
        		t.PrekesPav = dre.From<string>("Pavadinimas");
				t.PrekesKaina = dre.From<decimal>("PrekKaina");
				t.Gamintojas = dre.From<string>("Gamintojas");
				t.Kategorija = dre.From<string>("Kategorija");
				t.Ivertinimas = dre.From<int>("Ivertinimas");
        		t.PirkejoID = dre.From<int>("PirkejoID");
        		t.PirkejoVardas = dre.From<string>("Pirkejas");
        		t.Kaina = dre.From<decimal>("Kaina");
				t.VisaKaina = dre.From<decimal>("BendraKaina");
        		t.Data = dre.From<DateTime>("Data");
				t.Saskaita = dre.From<string>("Saskaita");
				t.PrekiuKiekis = dre.From<int>("PrekiuKiekis");
				t.MinIvertinimas = dre.From<int>("MinIvertinimas");
			});

		return result;
	}
}
