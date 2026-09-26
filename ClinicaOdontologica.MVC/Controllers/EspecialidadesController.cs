
using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Consumer;
using ClinicaOdontologica.Modelos;

public class EspecialidadesController : Controller
{

    // GET: ESPECIALIDADS
    public ActionResult Index()    
    {
        var especialidades = CRUD<Especialidad>.GetAll();
        return View(especialidades);
    }

    // GET: ESPECIALIDADS/Details/5
    public ActionResult Details(int id)
    {
        var especialidad = CRUD<Especialidad>.GetById(id);
        if (id == null)
        {
            return NotFound();
        }
        return View(especialidad);
    }

    // GET: ESPECIALIDADS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: ESPECIALIDADS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Especialidad especialidad)
    {
        try
        {
            CRUD<Especialidad>.Create(especialidad);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(especialidad);
        }
    }

    // GET: ESPECIALIDADS/Edit/5
    public ActionResult Edit(int id)
    {
        var especialidad = CRUD<Especialidad>.GetById(id);

        if (especialidad == null)
        {
            return NotFound();
        }
        return View(especialidad);
    }

    // POST: ESPECIALIDADS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Especialidad especialidad)
    {
        try
        {
            CRUD<Especialidad>.Update(id, especialidad);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(especialidad);
        }
    }

    // GET: ESPECIALIDADS/Delete/5
    public ActionResult Delete(int id)
    {
        var especialidad = CRUD<Especialidad>.GetById(id);
        if (especialidad == null)
        {
            return NotFound();
        }
        return View(especialidad);
    }

    // POST: ESPECIALIDADS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Especialidad especialidad)
    {
        try
        {
            CRUD<Especialidad>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}
