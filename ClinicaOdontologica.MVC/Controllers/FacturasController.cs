
using ClinicaOdontologica.Consumer;
using ClinicaOdontologica.Modelos;
using Microsoft.AspNetCore.Mvc;

public class FacturasController : Controller
{
    // GET: FACTURAS
    public ActionResult Index()    
    {
        var facturas = CRUD<Factura>.GetAll();
        return View(facturas);
    }

    // GET: FACTURAS/Details/5
    public ActionResult Details(int id)
    {
        var facturas = CRUD<Factura>.GetById(id);
        if (facturas == null)
        {
            return NotFound();
        }
        return View(facturas);
    }

    // GET: FACTURAS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: FACTURAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Factura factura)
    {
        try
        {
            CRUD<Factura>.Create(factura);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(factura);
        }
    }

    // GET: FACTURAS/Edit/5
    public ActionResult Edit(int id)
    {
        var factura = CRUD<Factura>.GetById(id);
        if (factura == null)
        {
            return NotFound();
        }
        return View(factura);
    }

    // POST: FACTURAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Factura factura)
    {
        try
        {
            CRUD<Factura>.Update(id, factura);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(factura);
        }
    }

    // GET: FACTURAS/Delete/5
    public ActionResult Delete(int id)
    {
        var factura = CRUD<Factura>.GetById(id);
        if (factura == null)
        {
            return NotFound();
        }
        return View(factura);
    }

    // POST: FACTURAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Factura factura)
    {
        try
        {
            CRUD<Factura>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}
