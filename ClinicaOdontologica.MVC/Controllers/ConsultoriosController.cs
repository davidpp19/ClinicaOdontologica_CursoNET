
using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Consumer;
using ClinicaOdontologica.Modelos;

public class ConsultoriosController : Controller
{
    // GET: CONSULTORIOS
    public ActionResult Index()    
    {
        var consultorio = CRUD<Consultorio>.GetAll();
        return View(consultorio);
    }

    // GET: CONSULTORIOS/Details/5
    public ActionResult Details(int id)
    {
        var consultorio = CRUD<Consultorio>.GetById(id);
        if (consultorio == null)
        {
            return NotFound();
        }
        return View(consultorio);
    }

    // GET: CONSULTORIOS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: CONSULTORIOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Consultorio consultorio)
    {
        try
        {
            CRUD<Consultorio>.Create(consultorio);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(consultorio);
        }
    }

    // GET: CONSULTORIOS/Edit/5
    public ActionResult Edit(int id)
    {
        var consultorio = CRUD<Consultorio>.GetById(id);

        if (consultorio == null)
        {
            return NotFound();
        }
        return View(consultorio);
    }

    // POST: CONSULTORIOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Consultorio consultorio)
    {
        try
        {
            CRUD<Consultorio>.Update(id, consultorio);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(consultorio);
        }
    }

    // GET: CONSULTORIOS/Delete/5
    public ActionResult Delete(int id)
    {
        var consultorio = CRUD<Consultorio>.GetById(id);

        if (consultorio == null)
        {
            return NotFound();
        }
        return View(consultorio);
    }

    // POST: CONSULTORIOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Consultorio consultorio)
    {
        try
        {
            CRUD<Consultorio>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}
