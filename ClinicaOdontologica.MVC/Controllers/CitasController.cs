using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.Consumer;

public class CitasController : Controller
{
    // GET: CITAS
    public ActionResult Index()    
    {
        var citas = CRUD<Cita>.GetAll();
        return View(citas);
    }

    // GET: CITAS/Details/5
    public ActionResult Details(int idcita)
    {
        var cita = CRUD<Cita>.GetById(idcita);
        if (idcita == null)
        {
            return NotFound();

        }
        return View(cita);
    }

    // GET: CITAS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: CITAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Cita cita)
    {
        try
        {
            CRUD<Cita>.Create(cita);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(cita);
        }
    }

    // GET: CITAS/Edit/5
    public ActionResult Edit(int idcita)
    {
        var cita = CRUD<Cita>.GetById(idcita);
        if (cita == null)
        {
            return NotFound();
        }
        return View(cita);
    }

    // POST: CITAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int idcita, Cita cita)
    {
        try
        {
            CRUD<Cita>.Update(idcita, cita);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(cita);
        }
    }

    // GET: CITAS/Delete/5
    public ActionResult Delete(int idcita)
    {
        var cita = CRUD<Cita>.GetById(idcita);
        if (cita == null)
        {
            return NotFound();
        }
        return View(cita);
    }

    // POST: CITAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int idcita, Cita cita)
    {
        try
        {
            CRUD<Cita>.Delete(idcita);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}
