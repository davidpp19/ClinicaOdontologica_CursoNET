
using ClinicaOdontologica.Consumer;
using ClinicaOdontologica.Modelos;
using Microsoft.AspNetCore.Mvc;

public class PacientesController : Controller
{
    // GET: PACIENTES
    public ActionResult Index()    
    {
        var pacientes = CRUD<Paciente>.GetAll();
        return View(pacientes);
    }

    // GET: PACIENTES/Details/5
    public ActionResult Details(int id)
    {
        var pacientes = CRUD<Paciente>.GetById(id);
        if (pacientes == null)
        {
            return NotFound();
        }
        return View(pacientes);
    }

    // GET: PACIENTES/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: PACIENTES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Paciente paciente)
    {
        try
        {
            CRUD<Paciente>.Create(paciente);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(paciente);
        }
    }

    // GET: PACIENTES/Edit/5
    public ActionResult Edit(int id)
    {
        var pacientes = CRUD<Paciente>.GetById(id);

        if (pacientes == null)
        {
            return NotFound();
        }
        return View(pacientes);
    }

    // POST: PACIENTES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Paciente paciente)
    {
        try
        {
            CRUD<Paciente>.Update(id, paciente);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(paciente);
        }
    }

    // GET: PACIENTES/Delete/5
    public ActionResult Delete(int id)
    {
        var paciente = CRUD<Paciente>.GetById(id);

        if (paciente == null)
        {
            return NotFound();
        }
        return View(paciente);
    }

    // POST: PACIENTES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Paciente paciente)
    {
        try
        {
            CRUD<Paciente>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}
