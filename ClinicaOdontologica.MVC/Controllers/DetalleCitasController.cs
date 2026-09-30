
using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Consumer;
using ClinicaOdontologica.Modelos;

public class DetalleCitasController : Controller
{
    // GET: DETALLECITAS
    public ActionResult Index()    
    {
        var detallecitas = CRUD<DetalleCita>.GetAll();
        return View(detallecitas);
    }
        
    // GET: DETALLECITAS/Details/5
    public ActionResult Details(int id)
    {
        var detallecita = CRUD<DetalleCita>.GetById(id);
        if (detallecita == null)
        {
            return NotFound();
        }
        return View(detallecita);
    }

    // GET: DETALLECITAS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: DETALLECITAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(DetalleCita detallecita)
    {
        try
        {
            CRUD<DetalleCita>.Create(detallecita);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(detallecita);
        }
    }

    // GET: DETALLECITAS/Edit/5
    public ActionResult Edit(int id)
    {
        var detallecitas = CRUD<DetalleCita>.GetById(id);

        if (detallecitas == null)
        {
            return NotFound();
        }
        return View(detallecitas);
    }

    // POST: DETALLECITAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, DetalleCita detallecita)
    {
        try
        {
            CRUD<DetalleCita>.Update(id, detallecita);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(detallecita);
        }
    }

    // GET: DETALLECITAS/Delete/5
    public ActionResult Delete(int id)
    {
        var detallecitas = CRUD<DetalleCita>.GetById(id);

        if (detallecitas == null)
        {
            return NotFound();
        }
        return View(detallecitas);
    }

    // POST: DETALLECITAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, DetalleCita detallecita)
    {
        try
        {
            CRUD<DetalleCita>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }

    }
}
