namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.Uzsakymas;
using System.Security.Policy;


/// <summary>
/// Controller for working with 'darbutojas' entity.
/// </summary>
public class UzsakymasController : Controller
{
	/// <summary>
	/// This is invoked when either 'Index' action is requested or no action is provided.
	/// </summary>
	/// <returns>Entity list view.</returns>
	[HttpGet]
	public ActionResult Index()
	{
		//gražinamas darbuotoju sarašo vaizdas
		return View(UzsakymasRepo.List());
	}

	/// <summary>
	/// This is invoked when creation form is first opened in browser.
	/// </summary>
	/// <returns>Creation form view.</returns>
	[HttpGet]
	public ActionResult Create()
	{
		var pr = new UzsakymasCE();
		pr.Uzsak.Data = DateTime.Now;
		PopulateSelections(pr);
		return View(pr);
	}

	/// <summary>
	/// This is invoked when buttons are pressed in the creation form.
	/// </summary>
	/// <param name="darb">Entity model filled with latest data.</param>
	/// <returns>Returns creation from view or redirects back to Index if save is successfull.</returns>
	[HttpPost]
	public ActionResult Create(UzsakymasCE pr)
	{
		//do not allow creation of entity with 'tabelis' field matching existing one
		var match = UzsakymasRepo.Find(pr.Uzsak.ID);

		if( match !=null )
			ModelState.AddModelError("ID", "Field value already exists in database.");

		//form field validation passed?
		if (ModelState.IsValid)
		{
			//NOTE: insert will fail if someone managed to add different 'darbutojas' with same 'tabelis' after the check
			UzsakymasRepo.Insert(pr);

			//save success, go back to the entity list
			return RedirectToAction("Index");
		}
		
		//form field validation failed, go back to the form
		return View(pr);
	}

	/// <summary>
	/// This is invoked when editing form is first opened in browser.
	/// </summary>
	/// <param name="id">ID of the entity to edit.</param>
	/// <returns>Editing form view.</returns>
	[HttpGet]
	public ActionResult Edit(int id)
	{
		var pr = UzsakymasRepo.Find(id);
		PopulateSelections(pr);
		return View(pr);
	}

	/// <summary>
	/// This is invoked when buttons are pressed in the editing form.
	/// </summary>
	/// <param name="id">ID of the entity being edited</param>		
	/// <param name="darb">Entity model filled with latest data.</param>
	/// <returns>Returns editing from view or redirects back to Index if save is successfull.</returns>
	[HttpPost]
	public ActionResult Edit(int id, UzsakymasCE pr)
	{
		//form field validation passed?
		if (ModelState.IsValid)
		{
			UzsakymasRepo.Update(pr);

			//save success, go back to the entity list
			return RedirectToAction("Index");
		}

		//form field validation failed, go back to the form
		return View(pr);
	}

	/// </summary>
	/// <param name="id">ID of the entity to delete.</param>
	/// <returns>Deletion form view.</returns>
	[HttpGet]
	public ActionResult Delete(int id)
	{
		var pr = UzsakymasRepo.FindForDeletion(id);
		return View(pr);
	}

	/// <summary>
	/// This is invoked when deletion is confirmed in deletion form
	/// </summary>
	/// <param name="id">ID of the entity to delete.</param>
	/// <returns>Deletion form view on error, redirects to Index on success.</returns>
	[HttpPost]
	public ActionResult DeleteConfirm(int id)
	{
		//try deleting, this will fail if foreign key constraint fails
		try 
		{
			UzsakymasRepo.Delete(id);

			//deletion success, redired to list form
			return RedirectToAction("Index");
		}
		//entity in use, deletion not permitted
		catch( MySql.Data.MySqlClient.MySqlException )
		{
			//enable explanatory message and show delete form
			ViewData["deletionNotPermitted"] = true;

			var pr = UzsakymasRepo.FindForDeletion(id);
			return View("Delete", pr);
		}
	}

	/// <summary>
	/// Populates select lists used to render drop down controls.
	/// </summary>
	/// <param name="modelisEvm">'Automobilis' view model to append to.</param>
	public void PopulateSelections(UzsakymasCE pr)
	{
		//load entities for the select lists
		var darbutojai = DarbutojasRepo.List();
		var pirkejai = PirkejasRepo.List();

		//build select lists
		pr.Lists.Darbutojai =
			darbutojai.Select(it => {
				return
					new SelectListItem() {
						Value = Convert.ToString(it.ID),
						Text = $"{it.Vardas} {it.Pavarde}"
					};
			})
			.ToList();
		
		pr.Lists.Pirkejai =
			pirkejai.Select(it => {
				return
					new SelectListItem() {
						Value = Convert.ToString(it.Id),
						Text = $"{it.Vardas} {it.Pavarde}"
					};
			})
			.ToList();
			
	}
}
