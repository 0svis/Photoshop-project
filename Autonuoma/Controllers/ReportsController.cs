namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.PilnasUzsakymas;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.Preke;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.Saskaita;
using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using ContractsReport = Org.Ktu.Isk.P175B602.Autonuoma.Models.PilnasUzsakymas;


/// <summary>
/// Controller for producing reports.
/// </summary>
public class ReportsController : Controller
{

	/// <summary>
	/// Produces contracts report.
	/// </summary>
	/// <param name="dateFrom">Starting date. Can be null.</param>
	/// <param name="dateTo">Ending date. Can be null.</param>
	/// <returns>Report view.</returns>
	[HttpGet]
	public ActionResult Contracts(DateTime? dateFrom, DateTime? dateTo, string busena, int ivertinimas, string pirkejas)
	{
		var report = new ContractsReport.Report();
		report.DateFrom = dateFrom;
		report.DateTo = dateTo?.AddHours(23).AddMinutes(59).AddSeconds(59); //move time of end date to end of day
		report.Busena = busena;
		report.Ivertinimas = ivertinimas;
		report.Pirkejas = pirkejas;

		report.PilniUzsakymai = AtaskaitaRepo.GetContracts(report.DateFrom, report.DateTo, report.Busena, report.Ivertinimas, report.Pirkejas);

		foreach (var item in report.PilniUzsakymai)
		{
			report.VisoSuma += item.Kaina;
		}

		return View(report);
	}
}
