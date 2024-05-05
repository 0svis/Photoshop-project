namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Newtonsoft.Json;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.UzsakymasF2;


/// <summary>
/// Controller for working with 'Sutartis' entity. Implementation of F2 version.
/// </summary>
public class UzsakymasF2Controller : Controller
{
	/// <summary>
	/// This is invoked when either 'Index' action is requested or no action is provided.
	/// </summary>
	/// <returns>Entity list view.</returns>
	[HttpGet]
	public ActionResult Index()
	{
		return View(UzsakymasF2Repo.ListUzsakymas());
	}

	/// <summary>
	/// This is invoked when creation form is first opened in a browser.
	/// </summary>
	/// <returns>Entity creation form.</returns>
	[HttpGet]
	public ActionResult Create()
	{
		var sutCE = new UzsakymasCE();

		sutCE.Uzsakymas.Data = DateTime.Now;
		
		PopulateLists(sutCE);

		return View(sutCE);
	}


	/// <summary>
	/// This is invoked when buttons are pressed in the creation form.
	/// </summary>
	/// <param name="save">If not null, indicates that 'Save' button was clicked.</param>
	/// <param name="add">If not null, indicates that 'Add' button was clicked.</param>
	/// <param name="remove">If not null, indicates that 'Remove' button was clicked and contains in-list-id of the item to remove.</param>
	/// <param name="sutCE">Entity view model filled with latest data.</param>
	/// <returns>Returns creation from view or redirets back to Index if save is successfull.</returns>
	[HttpPost]
	public ActionResult Create(int? save, int? add, int? remove, UzsakymasCE sutCE)
	{
		//addition of new 'UzsakytosPaslaugos' record was requested?
		if( add != null )
		{
			//add entry for the new record
			var up =
				new UzsakymasCE.UzsakytaPrekeM {
					InListId =
						sutCE.UzsakytosPrekes.Count > 0 ?
						sutCE.UzsakytosPrekes.Max(it => it.InListId) + 1 :
						0,

					Preke = null,
					Kiekis = 0,
					Kaina = 0
				};
			sutCE.UzsakytosPrekes.Add(up);

			//make sure @Html helper is not reusing old model state containing the old list
			ModelState.Clear();

			//go back to the form
			PopulateLists(sutCE);
			return View(sutCE);
		}

		//removal of existing 'UzsakytosPaslaugos' record was requested?
		if( remove != null )
		{
			//filter out 'UzsakytosPaslaugos' record having in-list-id the same as the given one
			sutCE.UzsakytosPrekes =
				sutCE
					.UzsakytosPrekes
					.Where(it => it.InListId != remove.Value)
					.ToList();

			//make sure @Html helper is not reusing old model state containing the old list
			ModelState.Clear();

			//go back to the form
			PopulateLists(sutCE);
			return View(sutCE);
		}

		//save of the form data was requested?
		if( save != null )
		{

			//form field validation passed?
			if( ModelState.IsValid )
			{
				//create new 'Sutartis'
				sutCE.Uzsakymas.Id = UzsakymasF2Repo.InsertUzsakymas(sutCE);
				//create new 'UzsakytosPaslaugos' records
				foreach ( var upVm in sutCE.UzsakytosPrekes )
					UzsakymasF2Repo.InsertUzsakytaPreke(sutCE.Uzsakymas.Id, upVm);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}
			//form field validation failed, go back to the form
			else
			{
				PopulateLists(sutCE);
				return View(sutCE);
			}
		}
		//should not reach here
		throw new Exception("Should not reach here.");
	}

	/// <summary>
	/// This is invoked when editing form is first opened in browser.
	/// </summary>
	/// <param name="id">ID of the entity to edit.</param>
	/// <returns>Editing form view.</returns>
	[HttpGet]
	public ActionResult Edit(int id)
	{
		var sutCE = UzsakymasF2Repo.FindUzsakymasCE(id);
		
		sutCE.UzsakytosPrekes = UzsakymasF2Repo.ListUzsakytaPreke(id);			
		PopulateLists(sutCE);

		return View(sutCE);
	}

	/// <summary>
	/// This is invoked when buttons are pressed in the editing form.
	/// </summary>
	/// <param name="id">ID of the entity being edited</param>
	/// <param name="save">If not null, indicates that 'Save' button was clicked.</param>
	/// <param name="add">If not null, indicates that 'Add' button was clicked.</param>
	/// <param name="remove">If not null, indicates that 'Remove' button was clicked and contains in-list-id of the item to remove.</param>
	/// <param name="sutCE">Entity view model filled with latest data.</param>
	/// <returns>Returns editing from view or redired back to Index if save is successfull.</returns>
	[HttpPost]
	public ActionResult Edit(int id, int? save, int? add, int? remove, UzsakymasCE sutCE)
	{
		//addition of new 'UzsakytosPaslaugos' record was requested?
		if( add != null )
		{
			//add entry for the new record
			var up =
				new UzsakymasCE.UzsakytaPrekeM {
					InListId =
						sutCE.UzsakytosPrekes.Count > 0 ?
						sutCE.UzsakytosPrekes.Max(it => it.InListId) + 1 :
						0,

					Preke = null,
					Kiekis = 0,
					Kaina = 0
				};
			sutCE.UzsakytosPrekes.Add(up);

			//make sure @Html helper is not reusing old model state containing the old list
			ModelState.Clear();

			//go back to the form
			PopulateLists(sutCE);
			return View(sutCE);
		}

		//removal of existing 'UzsakytosPaslaugos' record was requested?
		if( remove != null )
		{
			//filter out 'UzsakytosPaslaugos' record having in-list-id the same as the given one
			sutCE.UzsakytosPrekes =
				sutCE
					.UzsakytosPrekes
					.Where(it => it.InListId != remove.Value)
					.ToList();

			//make sure @Html helper is not reusing old model state containing the old list
			ModelState.Clear();

			//go back to the form
			PopulateLists(sutCE);
			return View(sutCE);
		}

		//save of the form data was requested?
		if( save != null )
		{
			//form field validation passed?
			if( ModelState.IsValid )
			{
				//update 'Sutartis'
				UzsakymasF2Repo.UpdateUzsakymas(sutCE);

				//delete all old 'UzsakytosPaslaugos' records
				UzsakymasF2Repo.DeleteUzsakytaPrekeForUzsakymas(sutCE.Uzsakymas.Id);

				//create new 'UzsakytosPaslaugos' records
				foreach( var upVm in sutCE.UzsakytosPrekes )
					UzsakymasF2Repo.InsertUzsakytaPreke(sutCE.Uzsakymas.Id, upVm);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}
			//form field validation failed, go back to the form
			else
			{
				PopulateLists(sutCE);
				return View(sutCE);
			}
		}

		//should not reach here
		throw new Exception("Should not reach here.");
	}

	/// <summary>
	/// This is invoked when deletion form is first opened in browser.
	/// </summary>
	/// <param name="id">ID of the entity to delete.</param>
	/// <returns>Deletion form view.</returns>
	[HttpGet]
	public ActionResult Delete(int id)
	{
		var sutCE = UzsakymasF2Repo.FindUzsakymasCE(id);
		return View(sutCE);
	}

	/// <summary>
	/// This is invoked when deletion is confirmed in deletion form
	/// </summary>
	/// <param name="id">ID of the entity to delete.</param>
	/// <returns>Deletion form view on error, redirects to Index on success.</returns>
	[HttpPost]
	public ActionResult DeleteConfirm(int id)
	{
		//load 'Sutartis'
		var sutCE = UzsakymasF2Repo.FindUzsakymasCE(id);
		var sasCE = SaskaitaRepo.FindFkUzsakymas(id);
		if(sasCE == null) 
		{
			//delete the entity
			UzsakymasF2Repo.DeleteUzsakytaPrekeForUzsakymas(id);
			UzsakymasF2Repo.DeleteUzsakymas(id);

			//redired to list form
			return RedirectToAction("Index");
		}
		else
		{
			//enable explanatory message and show delete form
			ViewData["deletionNotPermitted"] = true;
			return View("Delete", sutCE);
		}


	}

	/// <summary>
	/// Populates select lists used to render drop down controls.
	/// </summary>
	/// <param name="sutCE">'Sutartis' view model to append to.</param>
	private void PopulateLists(UzsakymasCE sutCE)
	{
		//load entities for the select lists
		var darbutojai = DarbutojasRepo.List();
		var pirkejai = PirkejasRepo.List();
		var prekes = PrekeRepo.List();

		sutCE.Lists.Darbutojai =
			darbutojai
				.Select(it =>
				{
					return
						new SelectListItem
						{
							Value = Convert.ToString(it.ID),
							Text = $"{it.Vardas} {it.Pavarde}"
						};
				})
				.ToList();

		sutCE.Lists.Pirkejai =
			pirkejai
				.Select(it =>
				{
					return
						new SelectListItem
						{
							Value = Convert.ToString(it.Id),
							Text = $"{it.Vardas} {it.Pavarde}"
						};
				})
				.ToList();

		sutCE.Lists.Prekes =
			prekes
				.Select(it =>
				{
					return
						new SelectListItem
						{
							Value = Convert.ToString(it.ID),
							Text = $"{it.Pavadinimas}"
						};
				})
				.ToList();
	}
}
