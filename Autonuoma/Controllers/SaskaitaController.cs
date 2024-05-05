namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.Saskaita;


/// <summary>
/// Controller for working with 'darbutojas' entity.
/// </summary>
public class SaskaitaController : Controller
{
	/// <summary>
	/// This is invoked when either 'Index' action is requested or no action is provided.
	/// </summary>
	/// <returns>Entity list view.</returns>
	[HttpGet]
	public ActionResult Index()
	{
		//gražinamas darbuotoju sarašo vaizdas
		return View(SaskaitaRepo.List());
	}

	/// <summary>
	/// This is invoked when creation form is first opened in browser.
	/// </summary>
	/// <returns>Creation form view.</returns>
	[HttpGet]
	public ActionResult Create()
	{
		var pr = new SaskaitaCE();
		pr.Sask.Data = DateTime.Now;
		PopulateSelections(pr);
		return View(pr);
	}

	/// <summary>
	/// This is invoked when buttons are pressed in the creation form.
	/// </summary>
	/// <param name="darb">Entity model filled with latest data.</param>
	/// <returns>Returns creation from view or redirects back to Index if save is successfull.</returns>
	[HttpPost]
	public ActionResult Create(SaskaitaCE pr)
	{
		//do not allow creation of entity with 'tabelis' field matching existing one
		var match = SaskaitaRepo.Find(pr.Sask.ID);

		if( match !=null )
			ModelState.AddModelError("ID", "Field value already exists in database.");

		//form field validation passed?
		if (ModelState.IsValid)
		{
			//NOTE: insert will fail if someone managed to add different 'darbutojas' with same 'tabelis' after the check
			SaskaitaRepo.Insert(pr);

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
		var pr = SaskaitaRepo.Find(id);
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
	public ActionResult Edit(int id, SaskaitaCE pr)
	{
		//form field validation passed?
		if (ModelState.IsValid)
		{
			SaskaitaRepo.Update(pr);

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
		var pr = SaskaitaRepo.FindForDeletion(id);
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
			SaskaitaRepo.Delete(id);

			//deletion success, redired to list form
			return RedirectToAction("Index");
		}
		//entity in use, deletion not permitted
		catch( MySql.Data.MySqlClient.MySqlException )
		{
			//enable explanatory message and show delete form
			ViewData["deletionNotPermitted"] = true;

			var pr = SaskaitaRepo.FindForDeletion(id);
			return View("Delete", pr);
		}
	}

	/// <summary>
	/// Populates select lists used to render drop down controls.
	/// </summary>
	/// <param name="modelisEvm">'Automobilis' view model to append to.</param>
	public void PopulateSelections(SaskaitaCE pr)
	{
		//load entities for the select lists
		var uzsakymai = UzsakymasRepo.ListLeft();
		var busenos = SaskaitaRepo.ListBusena();

		//build select lists
		pr.Lists.Uzsakymai =
			uzsakymai.Select(it => {
				return
					new SelectListItem() {
						Value = Convert.ToString(it.ID),
						Text = Convert.ToString(it.ID)
					};
			})
			.ToList();
			//build select lists

		pr.Lists.Busenos =
			busenos.Select(it => {
				return
					new SelectListItem() {
						Value = Convert.ToString(it.Id),
						Text = it.Pavadinimas
					};
			})
			.ToList();
	}
}
