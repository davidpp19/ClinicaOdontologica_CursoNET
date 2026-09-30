using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.Consumer;
using Microsoft.AspNetCore.Mvc.Rendering;

public class CitasController : Controller
{
    // GET: CITAS
    public ActionResult Index()    
    {
        var citas = CRUD<Cita>.GetAll();
        return View(citas);
    }

    // GET: CITAS/Details/5
    public ActionResult Details(int id)
    {
        var cita = CRUD<Cita>.GetById(id);
        if (cita == null)
        {
            return NotFound();
        }
        return View(cita);
    }

    //Metodo interno para obtener los pacientes.
    private List<SelectListItem> GetPacientes()
    {
        var pacientes = CRUD<Paciente>.GetAll();
        return pacientes.Select(p => new SelectListItem
        {
            Value = p.IdPaciente.ToString(),
            Text = p.nombre + " " + p.apellido
        }).ToList();
    }

    //Metodo interno para obtener los odontologos.
    private List<SelectListItem> GetOdontologos()
    {
        var odontologos = CRUD<Odontologo>.GetAll();
        return odontologos.Select(o => new SelectListItem
        {
            Value = o.IdOdontologo.ToString(),
            Text = o.nombre + " " + o.apellido
        }).ToList();
    }

    //Metodo interno para obtener los Consultorios.
    private List<SelectListItem> GetConsultorios()
    {
        var consultorios = CRUD<Consultorio>.GetAll();
        return consultorios.Select(c => new SelectListItem
        {
            Value = c.IdConsultorio.ToString(),
            Text = c.piso + " - " + c.numeroSala
        }).ToList();
    }

    // GET: CITAS/Create
    public ActionResult Create()
    {
        ViewBag.Pacientes = GetPacientes();
        ViewBag.Odontologos = GetOdontologos();
        ViewBag.Consultorios = GetConsultorios();
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
    public ActionResult Edit(int id)
    {
        var cita = CRUD<Cita>.GetById(id);
        ViewBag.Pacientes = GetPacientes();
        ViewBag.Odontologos = GetOdontologos();
        ViewBag.Consultorios = GetConsultorios();
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
    public ActionResult Edit(int id, Cita cita)
    {
        try
        {
            CRUD<Cita>.Update(id, cita);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(cita);
        }
    }

    // GET: CITAS/Delete/5
    public ActionResult Delete(int id)
    {
        var cita = CRUD<Cita>.GetById(id);
        if (cita == null)
        {
            return NotFound();
        }
        return View(cita);
    }

    // POST: CITAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Cita cita)
    {
        try
        {
            CRUD<Cita>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}
