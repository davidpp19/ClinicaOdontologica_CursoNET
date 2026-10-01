
using ClinicaOdontologica.Consumer;
using ClinicaOdontologica.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[Authorize]

public class RecetasController : Controller
{
    // GET: RECETAS
    public ActionResult Index()    
    {
        var recetas = CRUD<Receta>.GetAll();
        return View(recetas);
    }

    // GET: RECETAS/Details/5
    public ActionResult Details(int id)
    {
        var receta = CRUD<Receta>.GetById(id);
        if (receta == null)
        {
            return NotFound();
        }
        return View(receta);
    }

    // GET: RECETAS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: RECETAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Receta receta)
    {
        try
        {
            CRUD<Receta>.Create(receta);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(receta);
        }
    }

    // GET: RECETAS/Edit/5
    public ActionResult Edit(int id)
    {
        var receta = CRUD<Receta>.GetById(id);

        if (receta == null)
        {
            return NotFound();
        }
        return View(receta);
    }

    // POST: RECETAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Receta receta)
    {
        try
        {
            CRUD<Receta>.Update(id, receta);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(receta);
        }
    }

    // GET: RECETAS/Delete/5
    public ActionResult Delete(int id)
    {
        var receta = CRUD<Receta>.GetById(id);

        if (receta == null)
        {
            return NotFound();
        }
        return View(receta);
    }

    // POST: RECETAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Receta receta)
    {
        try
        {
            CRUD<Receta>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}
