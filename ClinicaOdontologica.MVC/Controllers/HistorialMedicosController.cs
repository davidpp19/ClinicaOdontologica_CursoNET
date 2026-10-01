
using ClinicaOdontologica.Consumer;
using ClinicaOdontologica.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[Authorize]

public class HistorialMedicosController : Controller
{
    // GET: HISTORIALMEDICOS
    public ActionResult Index()    
    {
        var historialmedico = CRUD<HistorialMedico>.GetAll();
        return View(historialmedico);
    }

    // GET: HISTORIALMEDICOS/Details/5
    public ActionResult Details(int id)
    {
        var historialmedico = CRUD<HistorialMedico>.GetById(id);
        if (historialmedico == null)
        {
            return NotFound();
        }
        return View(historialmedico);
    }

    // GET: HISTORIALMEDICOS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: HISTORIALMEDICOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(HistorialMedico historialmedico)
    {
        try
        {
            CRUD<HistorialMedico>.Create(historialmedico);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(historialmedico);
        }
    }

    // GET: HISTORIALMEDICOS/Edit/5
    public ActionResult Edit(int id)
    {
        var historialmedico = CRUD<HistorialMedico>.GetById(id);

        if (historialmedico == null)
        {
            return NotFound();
        }
        return View(historialmedico);
    }

    // POST: HISTORIALMEDICOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, HistorialMedico historialmedico)
    {
        try
        {
            CRUD<HistorialMedico>.Update(id, historialmedico);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(historialmedico);
        }
    }

    // GET: HISTORIALMEDICOS/Delete/5
    public ActionResult Delete(int id)
    {
        var historialmedico = CRUD<HistorialMedico>.GetById(id);

        if (historialmedico == null)
        {
            return NotFound();
        }
        return View(historialmedico);
    }

    // POST: HISTORIALMEDICOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, HistorialMedico historialmedico)
    {
        try
        {
            CRUD<HistorialMedico>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}
